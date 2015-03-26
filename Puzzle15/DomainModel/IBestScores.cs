using System.Collections.Generic;

namespace Puzzle15.DomainModel
{
    public interface IBestScores : IEnumerable<Score>
    {
        int Count { get; }
        bool CanBeAdded(Score score);
        void Add(Score score);
    }
}