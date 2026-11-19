namespace Puzzle15.Common.DomainModel;

public interface IBestScoresStorage
{
    string FileName { get; set; }
    void Save(IBestScores bestScores);
    void Load(IBestScores bestScores);
}
