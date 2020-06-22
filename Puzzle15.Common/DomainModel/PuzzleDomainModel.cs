using Puzzle15.Common;

namespace Puzzle15.DomainModel
{
    public class PuzzleDomainModel : IPuzzleDomainModel
    {
        private readonly IPuzzle puzzle = new Puzzle();
        private readonly IBestScores bestScores = new BestScores();
        private readonly IBestScoresStorage bestScoresStorage = new BestScoresStorage(Options.BestScoresStorageFileName);

        #region IPuzzleDomainModel implementation

        public IPuzzle Puzzle => puzzle;
        public IBestScores BestScores => bestScores;
        public IBestScoresStorage BestScoresStorage => bestScoresStorage;

        #endregion
    }
}