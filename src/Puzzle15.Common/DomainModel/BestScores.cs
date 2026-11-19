using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzle15.Common.DomainModel;

public class BestScores : IBestScores
{
    public const int MaxCount = 10;

    #region IBestScores implementation

    public List<Score> Scores { get; } = [];

    public int Count => Scores.Count;

    public Score this[int index] => Scores[index];

    // Новый результат встаёт после всех имеющихся результатов, которые лучше него или равны ему,
    // поэтому он попадает в список, только если таких результатов меньше MaxCount
    public bool CanBeAdded(Score score)
    {
        ArgumentNullException.ThrowIfNull(score);
        return CountBetterOrEqual(score) < MaxCount;
    }

    // Поддерживает Scores отсортированным и не длиннее MaxCount
    public void Add(Score score)
    {
        ArgumentNullException.ThrowIfNull(score);

        int index = CountBetterOrEqual(score);
        if (index >= MaxCount)
            return;

        Scores.Insert(index, score);
        if (Scores.Count > MaxCount)
            Scores.RemoveRange(MaxCount, Scores.Count - MaxCount);
    }

    #endregion IBestScores implementation

    private int CountBetterOrEqual(Score score) =>
        Scores.Count(s => s.CompareTo(score) <= 0);
}
