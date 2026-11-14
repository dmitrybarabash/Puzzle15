namespace Puzzle15.Common.DomainModel;

public interface IPuzzleDomainModel
{
    IPuzzle Puzzle { get; }
    IBestScores BestScores { get; }
    IBestScoresStorage BestScoresStorage { get; }
}
