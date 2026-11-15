using Puzzle15.Common;
using Puzzle15.Common.DomainModel;

namespace Puzzle15.WinForms.Mvp.UnitTests.Stubs;

public class StubPuzzleDomainModel : PuzzleDomainModel
{
    public StubPuzzleDomainModel()
        : base(new StubPuzzle(), new StubBestScores(), new StubBestScoresStorage(Options.BestScoresStorageFileName))
    {
    }
}
