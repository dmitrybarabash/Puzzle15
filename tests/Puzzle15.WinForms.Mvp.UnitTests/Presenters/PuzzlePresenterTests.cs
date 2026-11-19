using System;
using NUnit.Framework;
using Puzzle15.Common.DomainModel;
using Puzzle15.TestUtilities;
using Puzzle15.WinForms.Mvp.Presenters;
using Puzzle15.WinForms.Mvp.UnitTests.Fakes;

namespace Puzzle15.WinForms.Mvp.UnitTests.Presenters;

[TestFixture]
public class PuzzlePresenterTests
{
    // Собранное поле так, как его видит игрок: кнопка пустой клетки в правом нижнем углу спрятана
    private static readonly string[,] AssembledField =
    {
        {  "1",  "2",  "3",  "4" },
        {  "5",  "6",  "7",  "8" },
        {  "9", "10", "11", "12" },
        { "13", "14", "15", null },
    };

    private ManualTimeProvider _timeProvider;
    private FakeBestScoresStorage _bestScoresStorage;
    private PuzzleDomainModel _model;
    private FakePuzzleView _view;

    [SetUp]
    public void SetUp()
    {
        _timeProvider = new ManualTimeProvider();
        // Путь к файлу попадает в текст предупреждений
        _bestScoresStorage = new FakeBestScoresStorage { FileName = @"C:\Program Files\Puzzle15\Puzzle.dat" };
        _model = new PuzzleDomainModel(new Puzzle(_timeProvider, new Random(1)), new BestScores(), _bestScoresStorage);
        _view = new FakePuzzleView();
        new PuzzlePresenter(_model, _view);
    }

    [Test]
    public void Constructor_ShouldShowAssembledDisabledField()
    {
        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_view.Cells, Is.EqualTo(AssembledField));
            Assert.That(_view.IsFieldEnabled, Is.False);
        }
    }

    [Test]
    public void Constructor_ShouldResetAndDisableGameLabels()
    {
        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_view.ElapsedTime, Is.EqualTo("00:00:00"));
            Assert.That(_view.Moves, Is.EqualTo("0"));
            Assert.That(_view.AreGameLabelsEnabled, Is.False);
            Assert.That(_view.IsTimerRunning, Is.False);
        }
    }

    [Test]
    public void NewGame_ShouldShowShuffledFieldAndEnableIt()
    {
        // Act
        _view.ClickNewGame();

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_view.Cells, Is.EqualTo(GetModelFieldAsSeenByPlayer()));
            Assert.That(_view.IsFieldEnabled, Is.True);
        }
    }

    [Test]
    public void NewGame_ShouldEnableGameLabelsAndStartTimer()
    {
        // Act
        _view.ClickNewGame();

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_view.AreGameLabelsEnabled, Is.True);
            Assert.That(_view.IsTimerRunning, Is.True);
        }
    }

    [Test]
    public void NewGame_ShouldResetMovesAndTime_WhenGameIsInProgress()
    {
        // Arrange
        StartGameWithOneMoveLeft();
        _view.ClickCell(3, 1);
        _timeProvider.Advance(TimeSpan.FromSeconds(90));
        _view.TickTimer();

        // Act
        _view.ClickNewGame();

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_view.ElapsedTime, Is.EqualTo("00:00:00"));
            Assert.That(_view.Moves, Is.EqualTo("0"));
        }
    }

    [Test]
    public void Timer_ShouldShowElapsedTime_WhenGameIsInProgress()
    {
        // Arrange
        _view.ClickNewGame();
        _timeProvider.Advance(new TimeSpan(1, 2, 3));

        // Act
        _view.TickTimer();

        // Assert
        Assert.That(_view.ElapsedTime, Is.EqualTo("01:02:03"));
    }

    [Test]
    public void CellClicked_ShouldMoveCellAndShowMoves_WhenCellIsMoveable()
    {
        // Arrange
        StartGameWithOneMoveLeft();

        // Act
        _view.ClickCell(3, 1);

        // Assert
        using (Assert.EnterMultipleScope())
        {
            // Число 14 переехало на место пустой клетки, а кнопку нажатой клетки спрятали
            Assert.That(_view.Cells[3, 2], Is.EqualTo("14"));
            Assert.That(_view.Cells[3, 1], Is.Null);
            Assert.That(_view.Moves, Is.EqualTo("1"));
            Assert.That(_view.WinMessages, Is.Empty);
        }
    }

    [Test]
    public void CellClicked_ShouldIgnoreClick_WhenCellIsNotMoveable()
    {
        // Arrange
        StartGameWithOneMoveLeft();
        var cellsBeforeClick = (string[,])_view.Cells.Clone();

        // Act
        _view.ClickCell(0, 0);

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_view.Cells, Is.EqualTo(cellsBeforeClick));
            Assert.That(_view.Moves, Is.EqualTo("0"));
            Assert.That(_model.Puzzle.MovesCounter, Is.Zero);
        }
    }

    [Test]
    public void CellClicked_ShouldStopTimerAndShowWinMessage_WhenMoveFinishesGame()
    {
        // Arrange
        StartGameWithOneMoveLeft();
        _timeProvider.Advance(TimeSpan.FromSeconds(90));

        // Act
        _view.ClickCell(3, 3);

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_view.IsTimerRunning, Is.False);
            Assert.That(_view.WinMessages, Is.EqualTo(["Вы выиграли!\n\nВы сделали 1 ход за 00:01:30!"]));
        }
    }

    [Test]
    public void CellClicked_ShouldSaveBestScore_WhenPlayerGaveName()
    {
        // Arrange
        StartGameWithOneMoveLeft();
        _timeProvider.Advance(TimeSpan.FromSeconds(90));
        _view.PlayerName = "Player";

        // Act
        _view.ClickCell(3, 3);

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_bestScoresStorage.Scores,
                Is.EqualTo([new Score { Name = "Player", Moves = 1, Timer = TimeSpan.FromSeconds(90) }]));
            Assert.That(_view.Warnings, Is.Empty);
        }
    }

    [Test]
    public void CellClicked_ShouldNotSaveBestScore_WhenPlayerDeclinedToGiveName()
    {
        // Arrange
        StartGameWithOneMoveLeft();
        _view.PlayerName = null;

        // Act
        _view.ClickCell(3, 3);

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_view.AskPlayerNameCount, Is.EqualTo(1));
            Assert.That(_bestScoresStorage.Scores, Is.Empty);
            // Отказ игрока — это не ошибка, предупреждать не о чем
            Assert.That(_view.Warnings, Is.Empty);
        }
    }

    [Test]
    public void CellClicked_ShouldShowWarning_WhenBestScoreCannotBeSaved()
    {
        // Arrange
        // Так бывает, если игра установлена в Program Files: обычному пользователю писать туда нельзя
        _bestScoresStorage.SaveException = new UnauthorizedAccessException();
        StartGameWithOneMoveLeft();
        _view.PlayerName = "Player";

        // Act
        _view.ClickCell(3, 3);

        // Assert
        Assert.That(_view.Warnings, Is.EqualTo(
        [
            "Не удалось сохранить таблицу рекордов, поэтому результат в неё не записан.\n\nФайл: C:\\Program Files\\Puzzle15\\Puzzle.dat"
        ]));
    }

    [Test]
    public void CellClicked_ShouldShowWarningWithoutAskingName_WhenBestScoresCannotBeRead()
    {
        // Arrange
        // Так XmlSerializer сообщает об испорченном файле
        _bestScoresStorage.LoadException = new InvalidOperationException();
        StartGameWithOneMoveLeft();

        // Act
        _view.ClickCell(3, 3);

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_view.AskPlayerNameCount, Is.Zero);
            Assert.That(_view.Warnings, Is.EqualTo(
            [
                "Не удалось прочитать таблицу рекордов, поэтому результат в неё не записан.\n\nФайл: C:\\Program Files\\Puzzle15\\Puzzle.dat"
            ]));
        }
    }

    [Test]
    public void CellClicked_ShouldResetGame_WhenMoveFinishesGame()
    {
        // Arrange
        StartGameWithOneMoveLeft();
        _timeProvider.Advance(TimeSpan.FromSeconds(90));

        // Act
        _view.ClickCell(3, 3);

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_view.Cells, Is.EqualTo(AssembledField));
            Assert.That(_view.IsFieldEnabled, Is.False);
            Assert.That(_view.ElapsedTime, Is.EqualTo("00:00:00"));
            Assert.That(_view.Moves, Is.EqualTo("0"));
            Assert.That(_view.AreGameLabelsEnabled, Is.False);
            Assert.That(_model.Puzzle.MovesCounter, Is.Zero);
        }
    }

    [Test]
    public void BestScores_ShouldShowBestScoresViewAndDisposeIt()
    {
        // Arrange
        _bestScoresStorage.Scores.Add(new Score { Name = "Aaaaaaaaaa", Moves = 92, Timer = new TimeSpan(0, 0, 11, 25) });

        // Act
        _view.ClickBestScores();

        // Assert
        using (Assert.EnterMultipleScope())
        {
            // Таблицу заполнил BestScoresPresenter, которого PuzzlePresenter подключил к окну рекордов
            Assert.That(_view.BestScoresView.Rows, Is.EqualTo([new FakeBestScoresView.Row(0, "Aaaaaaaaaa", "92 хода", "00:11:25")]));
            Assert.That(_view.BestScoresView.ShowModalCount, Is.EqualTo(1));
            Assert.That(_view.BestScoresView.IsDisposed, Is.True);
        }
    }

    // Начинает партию и раскладывает поле так, что до сборки остается один ход: пустая клетка стоит слева от 15
    private void StartGameWithOneMoveLeft()
    {
        _view.ClickNewGame();
        _model.Puzzle.SetFieldWithEmptyCellAt(3, 2);
    }

    // Поле модели так, как его должен видеть игрок: кнопка пустой клетки спрятана
    private string[,] GetModelFieldAsSeenByPlayer()
    {
        IPuzzle puzzle = _model.Puzzle;
        var cells = new string[puzzle.FieldSideSize, puzzle.FieldSideSize];
        for (uint y = 0; y < puzzle.FieldSideSize; y++)
            for (uint x = 0; x < puzzle.FieldSideSize; x++)
                cells[y, x] = puzzle[y, x] == puzzle.EmptyCellValue ? null : puzzle[y, x].ToString();
        return cells;
    }
}
