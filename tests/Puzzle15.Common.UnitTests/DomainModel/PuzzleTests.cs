using NUnit.Framework;
using Puzzle15.DomainModel;

namespace Puzzle15.UnitTests.DomainModel;

[TestFixture]
public class PuzzleTests
{
    [Test]
    public void Init_None_DefaultStateOfGame()
    {
        // Arrange & Act
        var puzzle = new Puzzle();   // Init() is called in the constructor

        // Assert
        for (uint y = 0; y < puzzle.FieldSideSize; y++)
            for (uint x = 0; x < puzzle.FieldSideSize; x++)
                if (puzzle[y, x] != y * puzzle.FieldSideSize + x + 1)
                    Assert.Fail();
        Assert.That(puzzle.EmptyY, Is.EqualTo(puzzle.FieldSideSize - 1));
        Assert.That(puzzle.EmptyX, Is.EqualTo(puzzle.FieldSideSize - 1));
        Assert.That(puzzle.MovesCounter, Is.EqualTo(0));
    }

    [TestCase(0U, 0U, ExpectedResult = false)]
    [TestCase(0U, 1U, ExpectedResult = true)]
    [TestCase(0U, 2U, ExpectedResult = false)]
    [TestCase(0U, 3U, ExpectedResult = false)]
    [TestCase(1U, 0U, ExpectedResult = true)]
    [TestCase(1U, 2U, ExpectedResult = true)]
    [TestCase(1U, 3U, ExpectedResult = false)]
    [TestCase(2U, 0U, ExpectedResult = false)]
    [TestCase(2U, 1U, ExpectedResult = true)]
    [TestCase(2U, 2U, ExpectedResult = false)]
    [TestCase(2U, 3U, ExpectedResult = false)]
    public bool Move_CellCoords_ReturnsResult(uint y, uint x)
    {
        // Arrange
        var puzzle = new Puzzle();
        puzzle[0, 0] =  1; puzzle[0, 1] =  2; puzzle[0, 2] =  3; puzzle[0, 3] =  4;
        puzzle[1, 0] =  5; puzzle[1, 1] = 16; puzzle[1, 2] =  7; puzzle[1, 3] =  8;
        puzzle[2, 0] =  9; puzzle[2, 1] = 10; puzzle[2, 2] = 11; puzzle[2, 3] = 12;
        puzzle[3, 0] = 13; puzzle[3, 1] = 14; puzzle[3, 2] = 15; puzzle[3, 3] =  6;
        puzzle.EmptyY = 1;
        puzzle.EmptyX = 1;

        // Act
        puzzle.Move(y, x);

        // Assert
        return puzzle[y, x] == puzzle.EmptyCellValue;
    }

    [TestCase(0U, 0U, ExpectedResult = false)]
    [TestCase(0U, 1U, ExpectedResult = true)]
    [TestCase(0U, 2U, ExpectedResult = false)]
    [TestCase(0U, 3U, ExpectedResult = false)]
    [TestCase(1U, 0U, ExpectedResult = true)]
    [TestCase(1U, 1U, ExpectedResult = false)]
    [TestCase(1U, 2U, ExpectedResult = true)]
    [TestCase(1U, 3U, ExpectedResult = false)]
    [TestCase(2U, 0U, ExpectedResult = false)]
    [TestCase(2U, 1U, ExpectedResult = true)]
    [TestCase(2U, 2U, ExpectedResult = false)]
    [TestCase(2U, 3U, ExpectedResult = false)]
    public bool IsMoveable_CellCoords_ReturnsResult(uint y, uint x)
    {
        // Arrange
        var puzzle = new Puzzle();
        puzzle[0, 0] =  1; puzzle[0, 1] =  2; puzzle[0, 2] =  3; puzzle[0, 3] =  4;
        puzzle[1, 0] =  5; puzzle[1, 1] = 16; puzzle[1, 2] =  7; puzzle[1, 3] =  8;
        puzzle[2, 0] =  9; puzzle[2, 1] = 10; puzzle[2, 2] = 11; puzzle[2, 3] = 12;
        puzzle[3, 0] = 13; puzzle[3, 1] = 14; puzzle[3, 2] = 15; puzzle[3, 3] =  6;
        puzzle.EmptyY = 1;
        puzzle.EmptyX = 1;

        // Act & Assert
        return puzzle.IsMoveable(y, x);
    }

    [TestCase(0U, 0U, ExpectedResult = false)]
    [TestCase(0U, 1U, ExpectedResult = true)]
    [TestCase(1U, 0U, ExpectedResult = true)]
    [TestCase(1U, 1U, ExpectedResult = false)]
    [TestCase(2U, 3U, ExpectedResult = false)]
    public bool IsMoveable_CellCoordsAroundCorner_ReturnsResult(uint y, uint x)
    {
        // Arrange
        var puzzle = new Puzzle();
        puzzle[0, 0] = 16; puzzle[0, 1] =  2; puzzle[0, 2] =  3; puzzle[0, 3] =  4;
        puzzle[1, 0] =  5; puzzle[1, 1] =  6; puzzle[1, 2] =  7; puzzle[1, 3] =  8;
        puzzle[2, 0] =  9; puzzle[2, 1] = 10; puzzle[2, 2] = 11; puzzle[2, 3] = 12;
        puzzle[3, 0] = 13; puzzle[3, 1] = 14; puzzle[3, 2] = 15; puzzle[3, 3] =  1;
        puzzle.EmptyY = 0;
        puzzle.EmptyX = 0;

        // Act & Assert
        return puzzle.IsMoveable(y, x);
    }

    [Test]
    public void IsDone_RealyDone_ReturnsTrue()
    {
        // Arrange
        var puzzle = new Puzzle();
        puzzle[0, 0] =  1; puzzle[0, 1] =  2; puzzle[0, 2] =  3; puzzle[0, 3] =  4;
        puzzle[1, 0] =  5; puzzle[1, 1] =  6; puzzle[1, 2] =  7; puzzle[1, 3] =  8;
        puzzle[2, 0] =  9; puzzle[2, 1] = 10; puzzle[2, 2] = 11; puzzle[2, 3] = 12;
        puzzle[3, 0] = 13; puzzle[3, 1] = 14; puzzle[3, 2] = 15; puzzle[3, 3] = 16;
        puzzle.EmptyY = 3;
        puzzle.EmptyX = 3;

        // Act
        bool actual = puzzle.IsDone();

        // Assert
        Assert.That(actual, Is.True);
    }

    [Test]
    public void IsDone_NotDoneYet_ReturnsFalse()
    {
        // Arrange
        var puzzle = new Puzzle();
        puzzle[0, 0] =  1; puzzle[0, 1] =  2; puzzle[0, 2] =  3; puzzle[0, 3] =  4;
        puzzle[1, 0] =  5; puzzle[1, 1] =  6; puzzle[1, 2] =  7; puzzle[1, 3] =  8;
        puzzle[2, 0] =  9; puzzle[2, 1] = 10; puzzle[2, 2] = 11; puzzle[2, 3] = 12;
        puzzle[3, 0] = 13; puzzle[3, 1] = 14; puzzle[3, 2] = 16; puzzle[3, 3] = 15;
        puzzle.EmptyY = 3;
        puzzle.EmptyX = 2;

        // Act
        bool actual = puzzle.IsDone();

        // Assert
        Assert.That(actual, Is.Not.True);
    }
}

