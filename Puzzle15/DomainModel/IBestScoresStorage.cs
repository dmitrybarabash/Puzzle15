namespace Puzzle15.DomainModel
{
    public interface IBestScoresStorage
    {
        void Save(IBestScores bestScores);
        void Load(IBestScores bestScores);
    }
}