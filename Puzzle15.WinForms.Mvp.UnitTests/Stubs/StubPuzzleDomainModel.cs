using Puzzle15.Common;
using Puzzle15.DomainModel;

namespace Puzzle15.WinForms.Mvp.UnitTests.Stubs
{
    public class StubPuzzleDomainModel : IPuzzleDomainModel
    {
        private readonly IPuzzle puzzle = new StubPuzzle();
        private readonly IBestScores bestScores = new StubBestScores();
        private readonly IBestScoresStorage bestScoresStorage = new StubBestScoresStorage(Options.BestScoresStorageFileName);

        #region IPuzzleDomainModel implementation

        public IPuzzle Puzzle { get => puzzle; }
        public IBestScores BestScores { get => bestScores; }
        public IBestScoresStorage BestScoresStorage { get => bestScoresStorage; }

        #endregion
    }
}