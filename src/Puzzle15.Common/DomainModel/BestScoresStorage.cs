using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Puzzle15.Common.DomainModel;

public class BestScoresStorage : IBestScoresStorage
{
    public BestScoresStorage(string fileName)
    {
        FileName = fileName;
    }

    #region IBestScoresStorage implementation

    public string FileName { get; set; }

    public void Save(IBestScores bestScores)
    {
        // Сначала пишем во временный файл рядом с основным и только потом подменяем им основной.
        // Если запись прервётся (сбой, нехватка места, исключение при сериализации),
        // прежний файл с рекордами останется целым.
        var tempFileName = $"{FileName}.tmp";
        // Создаём файл до try: если создать его не удалось, он не наш (например, его сейчас
        // пишет другой экземпляр игры), и удалять его при ошибке нельзя
        var fileStream = new FileStream(tempFileName, FileMode.Create, FileAccess.Write, FileShare.None);
        try
        {
            using (fileStream)
            {
                var serializer = new XmlSerializer(typeof(List<Score>));
                serializer.Serialize(fileStream, bestScores.Scores);
                // Сбрасываем данные на диск до переименования, иначе при отключении питания
                // можно получить уже переименованный, но пустой файл
                fileStream.Flush(flushToDisk: true);
            }
            // Временный файл лежит на том же диске, поэтому это просто переименование:
            // основной файл в любой момент либо старый, либо новый, но не наполовину записанный
            File.Move(tempFileName, FileName, overwrite: true);
        }
        catch
        {
            // Сохранить не удалось, и недописанный временный файл больше не нужен
            TryDeleteFile(tempFileName);
            throw;
        }
    }

    public void Load(IBestScores bestScores)
    {
        // Нет файла — нет рекордов: либо их ещё не было, либо файл удалили, чтобы их сбросить.
        // Таблицу в памяти всё равно надо очистить, иначе при следующем сохранении
        // удалённые рекорды вернутся в файл.
        List<Score> scores = File.Exists(FileName) ? ReadScores() : [];

        // Если файл повреждён, ReadScores бросит InvalidOperationException ещё до очистки,
        // и неудачная загрузка не изменит таблицу в памяти. Исключение перехватывает PuzzleDomainModel.TryLoadBestScores.
        bestScores.Scores.Clear();
        // Add (а не AddRange), чтобы даже из файла с неотсортированными или лишними результатами
        // получался отсортированный список не более чем из MaxCount лучших результатов
        foreach (var score in scores)
        {
            // Add не принимает null, а в отредактированном вручную файле
            // могут оказаться пустые записи (<Score xsi:nil="true" />)
            if (score is not null)
                bestScores.Add(score);
        }
    }

    #endregion

    private List<Score> ReadScores()
    {
        using var fileStream = File.OpenRead(FileName);
        var serializer = new XmlSerializer(typeof(List<Score>));
        return (List<Score>)serializer.Deserialize(fileStream);
    }

    private static void TryDeleteFile(string fileName)
    {
        try
        {
            File.Delete(fileName);
        }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException)
        {
            // Ошибку удаления не пробрасываем, чтобы она не подменила собой исходную ошибку сохранения
        }
    }
}
