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

    public bool TryMove(uint y, uint x, out Score finishedGameScore)
    {
        finishedGameScore = null;
        if (!Puzzle.IsMoveable(y, x))
            return false;

        Puzzle.Move(y, x);
        if (Puzzle.IsDone())
            finishedGameScore = new Score { Moves = Puzzle.MovesCounter, Timer = Puzzle.ElapsedTime };
        return true;
    }

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

    public AddBestScoreResult AddBestScore(Score score, Func<string> askPlayerName)
    {
        ArgumentNullException.ThrowIfNull(score);
        ArgumentNullException.ThrowIfNull(askPlayerName);

        // Перечитываем таблицу, потому что в памяти она могла ещё не загружаться или устареть
        if (!TryLoadBestScores())
            return AddBestScoreResult.LoadFailed;
        if (!BestScores.CanBeAdded(score))
            return AddBestScoreResult.NotBestScore;

        string playerName = askPlayerName();
        if (playerName is null)
            return AddBestScoreResult.PlayerDeclined;

        score.Name = playerName;
        BestScores.Add(score);
        try
        {
            BestScoresStorage.Save(BestScores);
            return AddBestScoreResult.Added;
        }
        catch (Exception e) when (IsStorageError(e))
        {
            return AddBestScoreResult.SaveFailed;
        }
    }

    #endregion

    // Ошибки чтения и записи файла: не читается или не сохраняется.
    // Ошибки парсинга: XmlSerializer сообщает о повреждённом файле через InvalidOperationException.
    private static bool IsStorageError(Exception e) =>
        e is IOException or UnauthorizedAccessException or InvalidOperationException;
}
