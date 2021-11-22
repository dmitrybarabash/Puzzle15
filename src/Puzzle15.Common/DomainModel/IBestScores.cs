using System.Collections.Generic;

namespace Puzzle15.DomainModel;

public interface IBestScores
{
    List<Score> Scores { get; }
    int Count { get; }
    Score this[int index] { get; set; }
    bool CanBeAdded(Score score);
    void Add(Score score);
}
