using System.Collections.Generic;

namespace Puzzle15.DomainModel
{
    public interface IBestScores
    {
        List<Score> Scores { get; }
        bool CanBeAdded(Score score);
        void Add(Score score);
    }
}