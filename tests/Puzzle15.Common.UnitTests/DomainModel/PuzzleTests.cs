using System;
using NUnit.Framework;
using Puzzle15.Common.DomainModel;

namespace Puzzle15.Common.UnitTests.DomainModel;

[TestFixture]
public class PuzzleTests
{
    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenTimeProviderIsNull()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => _ = new Puzzle(null));
    }

    [Test]
    public void Init_ShouldSetDefaultStateOfGame_WhenPuzzleIsCreated()
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
        Assert.That(puzzle.MovesCounter, Is.Zero);
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
    public bool Move_ShouldReturnResult_WhenCellCoordsGiven(uint y, uint x)
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

    [TestCase(0U, 1U, ExpectedResult = true)]
    [TestCase(1U, 0U, ExpectedResult = true)]
    [TestCase(1U, 1U, ExpectedResult = false)]
    [TestCase(2U, 3U, ExpectedResult = false)]
    public bool Move_ShouldReturnResult_WhenEmptyCellIsInCorner(uint y, uint x)
    {
        // Arrange
        var puzzle = new Puzzle();
        puzzle[0, 0] = 16; puzzle[0, 1] =  2; puzzle[0, 2] =  3; puzzle[0, 3] =  4;
        puzzle[1, 0] =  5; puzzle[1, 1] =  6; puzzle[1, 2] =  7; puzzle[1, 3] =  8;
        puzzle[2, 0] =  9; puzzle[2, 1] = 10; puzzle[2, 2] = 11; puzzle[2, 3] = 12;
        puzzle[3, 0] = 13; puzzle[3, 1] = 14; puzzle[3, 2] = 15; puzzle[3, 3] =  1;
        puzzle.EmptyY = 0;
        puzzle.EmptyX = 0;

        // Act
        puzzle.Move(y, x);

        // Assert
        return puzzle[y, x] == puzzle.EmptyCellValue;
    }

    [TestCase(4U, 0U, "y")]
    [TestCase(0U, 4U, "x")]
    public void Move_ShouldThrowArgumentOutOfRangeException_WhenCellIsOutsideField(uint y, uint x, string paramName)
    {
        // Arrange
        var puzzle = new Puzzle();

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => puzzle.Move(y, x));
        Assert.That(exception.ParamName, Is.EqualTo(paramName));
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
    public bool IsMoveable_ShouldReturnResult_WhenCellCoordsGiven(uint y, uint x)
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
    public bool IsMoveable_ShouldReturnResult_WhenEmptyCellIsInCorner(uint y, uint x)
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

    [TestCase(4U, 0U, "y")]
    [TestCase(0U, 4U, "x")]
    public void IsMoveable_ShouldThrowArgumentOutOfRangeException_WhenCellIsOutsideField(uint y, uint x, string paramName)
    {
        // Arrange
        var puzzle = new Puzzle();

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => puzzle.IsMoveable(y, x));
        Assert.That(exception.ParamName, Is.EqualTo(paramName));
    }

    [Test]
    public void IsDone_ShouldReturnTrue_WhenReallyDone()
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
    public void IsDone_ShouldReturnFalse_WhenNotDoneYet()
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

    [TestCase(4U, 0U, "indexY")]
    [TestCase(0U, 4U, "indexX")]
    public void Indexer_ShouldThrowArgumentOutOfRangeException_WhenGettingCellOutsideField(uint y, uint x, string paramName)
    {
        // Arrange
        var puzzle = new Puzzle();

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => _ = puzzle[y, x]);
        Assert.That(exception.ParamName, Is.EqualTo(paramName));
    }

    [TestCase(4U, 0U, "indexY")]
    [TestCase(0U, 4U, "indexX")]
    public void Indexer_ShouldThrowArgumentOutOfRangeException_WhenSettingCellOutsideField(uint y, uint x, string paramName)
    {
        // Arrange
        var puzzle = new Puzzle();

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => puzzle[y, x] = 1);
        Assert.That(exception.ParamName, Is.EqualTo(paramName));
    }

    [Test]
    public void EmptyY_ShouldThrowArgumentOutOfRangeException_WhenValueIsOutsideField()
    {
        // Arrange
        var puzzle = new Puzzle();

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => puzzle.EmptyY = puzzle.FieldSideSize);
        Assert.That(exception.ParamName, Is.EqualTo("value"));
    }

    [Test]
    public void EmptyX_ShouldThrowArgumentOutOfRangeException_WhenValueIsOutsideField()
    {
        // Arrange
        var puzzle = new Puzzle();

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => puzzle.EmptyX = puzzle.FieldSideSize);
        Assert.That(exception.ParamName, Is.EqualTo("value"));
    }

    [Test]
    public void ElapsedTime_ShouldBeZero_WhenGameIsNotStarted()
    {
        // Arrange
        var timeProvider = new ManualTimeProvider();
        var puzzle = new Puzzle(timeProvider);

        // Act
        timeProvider.Advance(TimeSpan.FromSeconds(90));

        // Assert
        Assert.That(puzzle.ElapsedTime, Is.EqualTo(TimeSpan.Zero));
    }

    [Test]
    public void ElapsedTime_ShouldReturnTimeSinceStart_WhenGameIsInProgress()
    {
        // Arrange
        var timeProvider = new ManualTimeProvider();
        var puzzle = new Puzzle(timeProvider);
        // Время до начала партии не должно попасть в результат
        timeProvider.Advance(TimeSpan.FromMinutes(5));
        puzzle.Start();

        // Act
        timeProvider.Advance(TimeSpan.FromSeconds(90));

        // Assert
        Assert.That(puzzle.ElapsedTime, Is.EqualTo(TimeSpan.FromSeconds(90)));
    }

    [Test]
    public void ElapsedTime_ShouldStopCounting_WhenPuzzleIsDone()
    {
        // Arrange
        var timeProvider = new ManualTimeProvider();
        var puzzle = new Puzzle(timeProvider);
        puzzle.Start();
        // До сборки остался один ход: пустая клетка стоит слева от 15
        puzzle[0, 0] =  1; puzzle[0, 1] =  2; puzzle[0, 2] =  3; puzzle[0, 3] =  4;
        puzzle[1, 0] =  5; puzzle[1, 1] =  6; puzzle[1, 2] =  7; puzzle[1, 3] =  8;
        puzzle[2, 0] =  9; puzzle[2, 1] = 10; puzzle[2, 2] = 11; puzzle[2, 3] = 12;
        puzzle[3, 0] = 13; puzzle[3, 1] = 14; puzzle[3, 2] = 16; puzzle[3, 3] = 15;
        puzzle.EmptyY = 3;
        puzzle.EmptyX = 2;
        timeProvider.Advance(TimeSpan.FromSeconds(90));

        // Act
        puzzle.Move(3, 3);
        // Время, прошедшее после победы, не должно попасть в результат
        timeProvider.Advance(TimeSpan.FromMinutes(1));

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(puzzle.IsDone(), Is.True);
            Assert.That(puzzle.ElapsedTime, Is.EqualTo(TimeSpan.FromSeconds(90)));
        }
    }

    [Test]
    public void ElapsedTime_ShouldBeZero_WhenGameIsReinitialized()
    {
        // Arrange
        var timeProvider = new ManualTimeProvider();
        var puzzle = new Puzzle(timeProvider);
        puzzle.Start();
        timeProvider.Advance(TimeSpan.FromSeconds(90));

        // Act
        puzzle.Init();
        timeProvider.Advance(TimeSpan.FromSeconds(30));

        // Assert
        Assert.That(puzzle.ElapsedTime, Is.EqualTo(TimeSpan.Zero));
    }

    // Ручные часы для тестов: время идёт, только когда вызывают Advance
    public class ManualTimeProvider : TimeProvider
    {
        private long _timestamp;

        public override long TimestampFrequency => TimeSpan.TicksPerSecond;

        public override long GetTimestamp() => _timestamp;

        public void Advance(TimeSpan time) => _timestamp += time.Ticks;
    }
}

