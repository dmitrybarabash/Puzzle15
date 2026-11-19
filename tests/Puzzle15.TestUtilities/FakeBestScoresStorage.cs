using System;
using System.Collections.Generic;
using Puzzle15.Common.DomainModel;

namespace Puzzle15.TestUtilities;

// Хранилище рекордов в памяти. Если задано исключение, бросает его, как при ошибке работы с файлом.
public class FakeBestScoresStorage : IBestScoresStorage
{
    public List<Score> Scores { get; } = [];
    public int SaveCount { get; private set; }
    public Exception LoadException { get; set; }
    public Exception SaveException { get; set; }

    #region IBestScoresStorage implementation

    public string FileName { get; set; }

    public void Load(IBestScores bestScores)
    {
        if (LoadException is not null)
            throw LoadException;
        bestScores.Scores.Clear();
        bestScores.Scores.AddRange(Scores);
    }

    public void Save(IBestScores bestScores)
    {
        if (SaveException is not null)
            throw SaveException;
        Scores.Clear();
        Scores.AddRange(bestScores.Scores);
        SaveCount++;
    }

    #endregion
}
