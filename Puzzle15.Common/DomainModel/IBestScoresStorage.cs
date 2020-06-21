namespace Puzzle15.DomainModel
{
    public interface IBestScoresStorage
    {
        string FileName { get; set; }
        void Save(IBestScores bestScores);
        void Load(IBestScores bestScores);
    }
}