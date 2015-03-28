using System.Collections.Generic;

namespace Puzzle15.DomainModel
{
    public interface IBestScoresStorage
    {
        void Save(List<Score> scores);
        List<Score> Load();
    }
}