using Puzzle15.Common;

namespace Puzzle15.DomainModel
{
    public class PuzzleDomainModel : IPuzzleDomainModel
    {
        private readonly IPuzzle _puzzle = new Puzzle();
        private readonly IBestScores _bestScores = new BestScores();
        private readonly IBestScoresStorage _bestScoresStorage = new BestScoresStorage(Utils.BestScoresStorageFileName);

        public IPuzzle Puzzle { get { return _puzzle; } }
        public IBestScores BestScores { get { return _bestScores; } }
        public IBestScoresStorage BestScoresStorage { get { return _bestScoresStorage; } }
    }
}