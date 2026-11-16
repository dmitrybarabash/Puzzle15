using System;
using System.Linq;
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
        var exception = Assert.Throws<ArgumentNullException>(() => _ = new Puzzle(null, Random.Shared));
        Assert.That(exception.ParamName, Is.EqualTo("timeProvider"));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenRandomIsNull()
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => _ = new Puzzle(TimeProvider.System, null));
        Assert.That(exception.ParamName, Is.EqualTo("random"));
    }

    [Test]
    public void Constructor_ShouldSetDefaultStateOfGame_WhenPuzzleIsCreated()
    {
        // Arrange & Act
        var puzzle = new Puzzle();

        // Assert
        AssertDefaultStateOfGame(puzzle);
    }

    [Test]
    public void Init_ShouldResetStateOfGame_WhenMovesWereMade()
    {
        // Arrange
        var puzzle = new Puzzle();
        // Два хода из начальной позиции: пустая клетка уходит из угла, а счётчик ходов растёт
        puzzle.Move(3, 2);
        puzzle.Move(2, 2);

        // Act
        puzzle.Init();

        // Assert
        AssertDefaultStateOfGame(puzzle);
    }

    [Test]
    public void Start_ShouldShuffleField_WhenGameIsStarted()
    {
        // Arrange
        // Зерно фиксированное, поэтому тест при каждом запуске проверяет одно и то же перемешивание
        var puzzle = new Puzzle(TimeProvider.System, new Random(1));

        // Act
        puzzle.Start();

        // Assert
        using (Assert.EnterMultipleScope())
        {
            // Перемешивание переставляет клетки, но не теряет и не дублирует их
            Assert.That(puzzle.Cells, Is.EquivalentTo(Enumerable.Range(1, 16).Select(n => (uint)n)));
            Assert.That(puzzle[puzzle.EmptyY, puzzle.EmptyX], Is.EqualTo(puzzle.EmptyCellValue));
            Assert.That(puzzle.MovesCounter, Is.Zero);
            // Вероятность того, что после 1000 случайных ходов поле окажется собранным, ничтожно мала
            Assert.That(puzzle.IsDone(), Is.False);
        }
    }

    // Проверяем 20 перемешиваний: если бы Start переставлял клетки произвольно, а не ходами, несобираемым
    // оказывалось бы примерно каждое второе поле. Зёрна фиксированные, поэтому при каждом запуске
    // проверяются одни и те же поля, а зерно упавшего случая видно в имени теста.
    [Test]
    public void Start_ShouldMakeSolvableField_WhenGameIsStarted([Range(1, 20)] int seed)
    {
        // Arrange
        var puzzle = new Puzzle(TimeProvider.System, new Random(seed));

        // Act
        puzzle.Start();

        // Assert
        Assert.That(IsSolvable(puzzle), Is.True);
    }

    // Start берёт ходы только из переданного генератора, поэтому одинаковое зерно даёт одинаковое поле
    [Test]
    public void Start_ShouldShuffleFieldTheSameWay_WhenRandomsHaveSameSeed()
    {
        // Arrange
        var puzzle1 = new Puzzle(TimeProvider.System, new Random(1));
        var puzzle2 = new Puzzle(TimeProvider.System, new Random(1));

        // Act
        puzzle1.Start();
        puzzle2.Start();

        // Assert
        Assert.That(puzzle1.Cells, Is.EqualTo(puzzle2.Cells));
    }

    [TestCase(1U, 1U, 0U, 1U)]  // Пустая клетка в середине поля, клетка сверху от неё
    [TestCase(1U, 1U, 1U, 0U)]  // Слева
    [TestCase(1U, 1U, 1U, 2U)]  // Справа
    [TestCase(1U, 1U, 2U, 1U)]  // Снизу
    [TestCase(0U, 0U, 0U, 1U)]  // Пустая клетка в левом верхнем углу
    [TestCase(0U, 0U, 1U, 0U)]
    [TestCase(3U, 3U, 2U, 3U)]  // Пустая клетка в правом нижнем углу
    [TestCase(3U, 3U, 3U, 2U)]
    public void Move_ShouldSwapTileWithEmptyCell_WhenTileIsNextToEmptyCell(uint emptyY, uint emptyX, uint y, uint x)
    {
        // Arrange
        var puzzle = CreatePuzzleWithEmptyCellAt(emptyY, emptyX);
        var expected = (uint[,])puzzle.Cells.Clone();
        expected[emptyY, emptyX] = puzzle[y, x];
        expected[y, x] = puzzle.EmptyCellValue;

        // Act
        puzzle.Move(y, x);

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(puzzle.Cells, Is.EqualTo(expected));
            Assert.That(puzzle.EmptyY, Is.EqualTo(y));
            Assert.That(puzzle.EmptyX, Is.EqualTo(x));
            Assert.That(puzzle.MovesCounter, Is.EqualTo(1U));
        }
    }

    [TestCase(1U, 1U, 1U, 1U)]  // Пустая клетка в середине поля, нажата она сама
    [TestCase(1U, 1U, 0U, 0U)]  // По диагонали
    [TestCase(1U, 1U, 0U, 2U)]
    [TestCase(1U, 1U, 2U, 0U)]
    [TestCase(1U, 1U, 2U, 2U)]
    [TestCase(1U, 1U, 1U, 3U)]  // В той же строке через клетку
    [TestCase(1U, 1U, 3U, 1U)]  // В том же столбце через клетку
    [TestCase(1U, 1U, 0U, 3U)]  // Далеко
    [TestCase(1U, 1U, 2U, 3U)]
    [TestCase(0U, 0U, 0U, 0U)]  // Пустая клетка в левом верхнем углу
    [TestCase(0U, 0U, 1U, 1U)]
    [TestCase(0U, 0U, 2U, 3U)]
    [TestCase(3U, 3U, 3U, 3U)]  // Пустая клетка в правом нижнем углу
    [TestCase(3U, 3U, 2U, 2U)]
    public void Move_ShouldNotChangeStateOfGame_WhenCellIsNotNextToEmptyCell(uint emptyY, uint emptyX, uint y, uint x)
    {
        // Arrange
        var puzzle = CreatePuzzleWithEmptyCellAt(emptyY, emptyX);
        var expected = (uint[,])puzzle.Cells.Clone();

        // Act
        puzzle.Move(y, x);

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(puzzle.Cells, Is.EqualTo(expected));
            Assert.That(puzzle.EmptyY, Is.EqualTo(emptyY));
            Assert.That(puzzle.EmptyX, Is.EqualTo(emptyX));
            Assert.That(puzzle.MovesCounter, Is.Zero);
        }
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

    [TestCase(1U, 1U, 0U, 0U, ExpectedResult = false)]  // Пустая клетка в середине поля
    [TestCase(1U, 1U, 0U, 1U, ExpectedResult = true)]
    [TestCase(1U, 1U, 0U, 2U, ExpectedResult = false)]
    [TestCase(1U, 1U, 0U, 3U, ExpectedResult = false)]
    [TestCase(1U, 1U, 1U, 0U, ExpectedResult = true)]
    [TestCase(1U, 1U, 1U, 1U, ExpectedResult = false)]
    [TestCase(1U, 1U, 1U, 2U, ExpectedResult = true)]
    [TestCase(1U, 1U, 1U, 3U, ExpectedResult = false)]
    [TestCase(1U, 1U, 2U, 0U, ExpectedResult = false)]
    [TestCase(1U, 1U, 2U, 1U, ExpectedResult = true)]
    [TestCase(1U, 1U, 2U, 2U, ExpectedResult = false)]
    [TestCase(1U, 1U, 2U, 3U, ExpectedResult = false)]
    [TestCase(0U, 0U, 0U, 0U, ExpectedResult = false)]  // Пустая клетка в левом верхнем углу
    [TestCase(0U, 0U, 0U, 1U, ExpectedResult = true)]
    [TestCase(0U, 0U, 1U, 0U, ExpectedResult = true)]
    [TestCase(0U, 0U, 1U, 1U, ExpectedResult = false)]
    [TestCase(0U, 0U, 2U, 3U, ExpectedResult = false)]
    public bool IsMoveable_ShouldReturnTrueOnlyForNeighboursOfEmptyCell_WhenCellCoordsGiven(
        uint emptyY, uint emptyX, uint y, uint x)
    {
        // Arrange
        var puzzle = CreatePuzzleWithEmptyCellAt(emptyY, emptyX);

        // Act
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
        // Пустая клетка на своём месте, значит, поле собрано
        var puzzle = CreatePuzzleWithEmptyCellAt(3, 3);

        // Act
        bool actual = puzzle.IsDone();

        // Assert
        Assert.That(actual, Is.True);
    }

    [Test]
    public void IsDone_ShouldReturnFalse_WhenNotDoneYet()
    {
        // Arrange
        // До сборки остался один ход: пустая клетка стоит слева от 15
        var puzzle = CreatePuzzleWithEmptyCellAt(3, 2);

        // Act
        bool actual = puzzle.IsDone();

        // Assert
        Assert.That(actual, Is.False);
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
        var puzzle = new Puzzle(timeProvider, Random.Shared);

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
        var puzzle = new Puzzle(timeProvider, Random.Shared);
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
        var puzzle = new Puzzle(timeProvider, Random.Shared);
        puzzle.Start();
        // До сборки остался один ход: пустая клетка стоит слева от 15
        SetFieldWithEmptyCellAt(puzzle, 3, 2);
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
        var puzzle = new Puzzle(timeProvider, Random.Shared);
        puzzle.Start();
        timeProvider.Advance(TimeSpan.FromSeconds(90));

        // Act
        puzzle.Init();
        timeProvider.Advance(TimeSpan.FromSeconds(30));

        // Assert
        Assert.That(puzzle.ElapsedTime, Is.EqualTo(TimeSpan.Zero));
    }

    [Test]
    public void ElapsedTime_ShouldBeZero_WhenGameIsReinitializedAfterWin()
    {
        // Arrange
        var timeProvider = new ManualTimeProvider();
        var puzzle = new Puzzle(timeProvider, Random.Shared);
        puzzle.Start();
        // До сборки остался один ход: пустая клетка стоит слева от 15
        SetFieldWithEmptyCellAt(puzzle, 3, 2);
        timeProvider.Advance(TimeSpan.FromSeconds(90));
        puzzle.Move(3, 3);

        // Act
        puzzle.Init();

        // Assert
        Assert.That(puzzle.ElapsedTime, Is.EqualTo(TimeSpan.Zero));
    }

    // Собранное поле, в котором пустая клетка поменялась местами с клеткой (emptyY, emptyX)
    private static Puzzle CreatePuzzleWithEmptyCellAt(uint emptyY, uint emptyX)
    {
        var puzzle = new Puzzle();
        SetFieldWithEmptyCellAt(puzzle, emptyY, emptyX);
        return puzzle;
    }

    // То же поле в уже созданной игре: например, после Start, чтобы таймер партии продолжал идти
    private static void SetFieldWithEmptyCellAt(Puzzle puzzle, uint emptyY, uint emptyX)
    {
        for (uint y = 0; y < puzzle.FieldSideSize; y++)
            for (uint x = 0; x < puzzle.FieldSideSize; x++)
                puzzle[y, x] = y * puzzle.FieldSideSize + x + 1;
        uint last = puzzle.FieldSideSize - 1;
        puzzle[last, last] = puzzle[emptyY, emptyX];
        puzzle[emptyY, emptyX] = puzzle.EmptyCellValue;
        puzzle.EmptyY = emptyY;
        puzzle.EmptyX = emptyX;
    }

    // Ходами из собранного поля получается только половина всех раскладок. Каждый ход меняет местами
    // пустую клетку и соседнюю клетку: чётность числа инверсий меняется, и на единицу меняется расстояние
    // от пустой клетки до правого нижнего угла. Поэтому у собираемой раскладки эти две чётности совпадают.
    private static bool IsSolvable(Puzzle puzzle)
    {
        var cells = puzzle.Cells.Cast<uint>().ToArray();
        int inversions = 0;
        for (int i = 0; i < cells.Length; i++)
            for (int j = i + 1; j < cells.Length; j++)
                if (cells[i] > cells[j])
                    inversions++;
        uint last = puzzle.FieldSideSize - 1;
        uint distance = last - puzzle.EmptyY + (last - puzzle.EmptyX);
        return inversions % 2 == distance % 2;
    }

    // Начальное состояние: поле собрано, пустая клетка в правом нижнем углу, ходов не было
    private static void AssertDefaultStateOfGame(Puzzle puzzle)
    {
        uint[,] expected =
        {
            {  1,  2,  3,  4 },
            {  5,  6,  7,  8 },
            {  9, 10, 11, 12 },
            { 13, 14, 15, 16 },
        };
        using (Assert.EnterMultipleScope())
        {
            Assert.That(puzzle.Cells, Is.EqualTo(expected));
            Assert.That(puzzle.EmptyY, Is.EqualTo(3U));
            Assert.That(puzzle.EmptyX, Is.EqualTo(3U));
            Assert.That(puzzle.MovesCounter, Is.Zero);
        }
    }

    // Часы для тестов: время идёт, только когда вызывают Advance
    public class ManualTimeProvider : TimeProvider
    {
        private long _timestamp;

        public override long TimestampFrequency => TimeSpan.TicksPerSecond;

        public override long GetTimestamp() => _timestamp;

        public void Advance(TimeSpan time) => _timestamp += time.Ticks;
    }
}

