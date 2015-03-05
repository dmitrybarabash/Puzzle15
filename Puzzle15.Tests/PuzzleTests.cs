using NUnit.Framework;

namespace Puzzle15.Tests
{
    [TestFixture]
    public class PuzzleTests
    {
        [TestCase(0, 0, Result = false)]
        [TestCase(0, 1, Result = true)]
        [TestCase(0, 2, Result = false)]
        [TestCase(0, 3, Result = false)]
        [TestCase(1, 0, Result = true)]
        [TestCase(1, 2, Result = true)]
        [TestCase(1, 3, Result = false)]
        [TestCase(2, 0, Result = false)]
        [TestCase(2, 1, Result = true)]
        [TestCase(2, 2, Result = false)]
        [TestCase(2, 3, Result = false)]
        public bool IsMoveable_CellCoords_ReturnsResult(int y, int x)
        {
            var puzzle = new Puzzle();
            puzzle.Cells[0, 0] =  1; puzzle.Cells[0, 1] =  2; puzzle.Cells[0, 2] =  3; puzzle.Cells[0, 3] =  4;
            puzzle.Cells[1, 0] =  5; puzzle.Cells[1, 1] = 16; puzzle.Cells[1, 2] =  7; puzzle.Cells[1, 3] =  8;
            puzzle.Cells[2, 0] =  9; puzzle.Cells[2, 1] = 10; puzzle.Cells[2, 2] = 11; puzzle.Cells[2, 3] = 12;
            puzzle.Cells[3, 0] = 13; puzzle.Cells[3, 1] = 14; puzzle.Cells[3, 2] = 15; puzzle.Cells[3, 3] =  6;
            puzzle.EmptyY = 1;
            puzzle.EmptyX = 1;

            return puzzle.IsMoveable(y, x);
        }

        [Test]
        public void IsDone_RealyDone_ReturnsTrue()
        {
            var puzzle = new Puzzle();
            puzzle.Cells[0, 0] =  1; puzzle.Cells[0, 1] =  2; puzzle.Cells[0, 2] =  3; puzzle.Cells[0, 3] =  4;
            puzzle.Cells[1, 0] =  5; puzzle.Cells[1, 1] =  6; puzzle.Cells[1, 2] =  7; puzzle.Cells[1, 3] =  8;
            puzzle.Cells[2, 0] =  9; puzzle.Cells[2, 1] = 10; puzzle.Cells[2, 2] = 11; puzzle.Cells[2, 3] = 12;
            puzzle.Cells[3, 0] = 13; puzzle.Cells[3, 1] = 14; puzzle.Cells[3, 2] = 15; puzzle.Cells[3, 3] = 16;
            puzzle.EmptyY = 1;
            puzzle.EmptyX = 1;

            bool actual = puzzle.IsDone();

            Assert.That(actual, Is.True);
        }

        [Test]
        public void IsDone_NotDoneYet_ReturnsFalse()
        {
            var puzzle = new Puzzle();
            puzzle.Cells[0, 0] =  1; puzzle.Cells[0, 1] =  2; puzzle.Cells[0, 2] =  3; puzzle.Cells[0, 3] =  4;
            puzzle.Cells[1, 0] =  5; puzzle.Cells[1, 1] =  6; puzzle.Cells[1, 2] =  7; puzzle.Cells[1, 3] =  8;
            puzzle.Cells[2, 0] =  9; puzzle.Cells[2, 1] = 10; puzzle.Cells[2, 2] = 11; puzzle.Cells[2, 3] = 12;
            puzzle.Cells[3, 0] = 13; puzzle.Cells[3, 1] = 14; puzzle.Cells[3, 2] = 16; puzzle.Cells[3, 3] = 15;
            puzzle.EmptyY = 1;
            puzzle.EmptyX = 1;

            bool actual = puzzle.IsDone();

            Assert.That(actual, Is.Not.True);
        }
    }
}
