namespace Puzzle15.DomainModel;

public interface IPuzzleDomainModel
{
    IPuzzle Puzzle { get; }
    IBestScores BestScores { get; }
    IBestScoresStorage BestScoresStorage { get; }
}
