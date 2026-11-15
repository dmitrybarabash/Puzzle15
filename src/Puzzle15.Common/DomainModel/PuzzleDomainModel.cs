using System;
using System.IO;

namespace Puzzle15.Common.DomainModel;

public class PuzzleDomainModel : IPuzzleDomainModel
{
    public PuzzleDomainModel()
        : this(new Puzzle(), new BestScores(), new BestScoresStorage(Options.BestScoresStoragePath))
    {
    }

    // Нужен для тестов: части модели можно будет подменить
    public PuzzleDomainModel(IPuzzle puzzle, IBestScores bestScores, IBestScoresStorage bestScoresStorage)
    {
        Puzzle = puzzle;
        BestScores = bestScores;
        BestScoresStorage = bestScoresStorage;
    }

    #region IPuzzleDomainModel implementation

    public IPuzzle Puzzle { get; }
    public IBestScores BestScores { get; }
    public IBestScoresStorage BestScoresStorage { get; }

    public bool TryLoadBestScores()
    {
        try
        {
            BestScoresStorage.Load(BestScores);
            return true;
        }
        catch (Exception e) when (IsStorageError(e))
        {
            return false;
        }
    }

    public bool TryAddBestScore(Score score, Func<string> askPlayerName)
    {
        ArgumentNullException.ThrowIfNull(score);
        ArgumentNullException.ThrowIfNull(askPlayerName);

        // Перечитываем таблицу, потому что в памяти она могла ещё не загружаться или устареть
        if (!TryLoadBestScores() || !BestScores.CanBeAdded(score))
            return false;

        string playerName = askPlayerName();
        if (playerName is null)
            return false;

        score.Name = playerName;
        BestScores.Add(score);
        try
        {
            BestScoresStorage.Save(BestScores);
            return true;
        }
        catch (Exception e) when (IsStorageError(e))
        {
            return false;
        }
    }

    #endregion

    // Ошибки чтения и записи файла: не читается или не сохраняется.
    // Ошибки парсинга: XmlSerializer сообщает о повреждённом файле через InvalidOperationException.
    private static bool IsStorageError(Exception e) =>
        e is IOException or UnauthorizedAccessException or InvalidOperationException;
}
