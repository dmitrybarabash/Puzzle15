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
        // прежний файл с рекордами останется целым
        var tempFileName = $"{FileName}.tmp";
        using (var fileStream = new FileStream(tempFileName, FileMode.Create, FileAccess.Write, FileShare.None))
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

    public void Load(IBestScores bestScores)
    {
        if (!File.Exists(FileName))
            return;

        using var fileStream = File.OpenRead(FileName);
        var serializer = new XmlSerializer(typeof(List<Score>));
        var scores = (List<Score>)serializer.Deserialize(fileStream);
        bestScores.Scores.Clear();
        // Add (а не AddRange), чтобы даже из файла с неотсортированными или лишними результатами
        // получался отсортированный список не более чем из MaxCount лучших результатов
        foreach (var score in scores)
        {
            if (score is not null)
                bestScores.Add(score);
        }
    }

    #endregion
}
