using Puzzle15.Common;
using Puzzle15.DomainModel;

namespace Puzzle15.Tests.Stubs
{
    public class StubPuzzleDomainModel : IPuzzleDomainModel
    {
        private readonly IPuzzle puzzle = new StubPuzzle();
        private readonly IBestScores bestScores = new StubBestScores();
        private readonly IBestScoresStorage bestScoresStorage = new StubBestScoresStorage(Utils.BestScoresStorageFileName);

        #region IPuzzleDomainModel Implementation

        public IPuzzle Puzzle { get { return puzzle; } }
        public IBestScores BestScores { get { return bestScores; } }
        public IBestScoresStorage BestScoresStorage { get { return bestScoresStorage; } }

        #endregion
    }
}