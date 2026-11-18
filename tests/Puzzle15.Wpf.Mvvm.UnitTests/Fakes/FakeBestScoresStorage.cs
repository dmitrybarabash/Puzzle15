using System;
using System.Collections.Generic;
using Puzzle15.Common.DomainModel;

namespace Puzzle15.Wpf.Mvvm.UnitTests.Fakes;

// Хранит таблицу рекордов в памяти вместо файла
public class FakeBestScoresStorage : IBestScoresStorage
{
    public List<Score> Scores { get; } = [];
    public Exception LoadException { get; set; }

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
        Scores.Clear();
        Scores.AddRange(bestScores.Scores);
    }

    #endregion
}
