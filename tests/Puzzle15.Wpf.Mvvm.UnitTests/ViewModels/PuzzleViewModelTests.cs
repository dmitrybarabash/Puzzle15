using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Puzzle15.Common.DomainModel;
using Puzzle15.Wpf.Mvvm.UnitTests.Fakes;
using Puzzle15.Wpf.Mvvm.ViewModels;

namespace Puzzle15.Wpf.Mvvm.UnitTests.ViewModels;

[TestFixture]
public class PuzzleViewModelTests
{
    private ManualTimeProvider _timeProvider;
    private FakeBestScoresStorage _bestScoresStorage;
    private FakeDialogService _dialogService;
    private PuzzleDomainModel _model;
    private PuzzleViewModel _viewModel;

    [SetUp]
    public void SetUp()
    {
        _timeProvider = new ManualTimeProvider();
        _bestScoresStorage = new FakeBestScoresStorage();
        _dialogService = new FakeDialogService();
        _model = new PuzzleDomainModel(new Puzzle(_timeProvider, new Random(1)), new BestScores(), _bestScoresStorage);
        _viewModel = new PuzzleViewModel(_model, _dialogService);
    }

    [Test]
    public void Cells_ShouldGoRowByRow_WhenViewModelIsCreated()
    {
        // Assert
        using (Assert.EnterMultipleScope())
        {
            // На собранном поле числа по строкам идут от 1 до 16, а пустая клетка стоит последней
            Assert.That(_viewModel.Cells.Select(c => c.Value), Is.EqualTo(Enumerable.Range(1, 16).Select(n => (uint)n)));
            Assert.That(_viewModel.Cells.Select(c => c.IsEmpty), Is.EqualTo(Enumerable.Repeat(false, 15).Append(true)));
        }
    }

    [Test]
    public void Constructor_ShouldResetGameLabelsAndDisableMoves_WhenViewModelIsCreated()
    {
        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_viewModel.IsGameStarted, Is.False);
            Assert.That(_viewModel.MoveCommand.CanExecute(GetCell(3, 2)), Is.False);
            Assert.That(_viewModel.GameTimerText, Is.EqualTo("00:00:00"));
            Assert.That(_viewModel.GameMovesText, Is.EqualTo("0"));
        }
    }

    [Test]
    public void NewGameCommand_ShouldEnableMoves_WhenExecuted()
    {
        // Arrange
        int canExecuteChangedCount = 0;
        _viewModel.MoveCommand.CanExecuteChanged += (s, e) => canExecuteChangedCount++;

        // Act
        _viewModel.NewGameCommand.Execute(null);

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_viewModel.IsGameStarted, Is.True);
            Assert.That(_viewModel.MoveCommand.CanExecute(GetCell(3, 2)), Is.True);
            // Кнопки клеток узнают, что команда стала доступна, только из этого события
            Assert.That(canExecuteChangedCount, Is.EqualTo(1));
        }
    }

    [Test]
    public void NewGameCommand_ShouldNotifyAllCells_WhenExecuted()
    {
        // Arrange
        var changedProperties = new List<string>();
        foreach (CellViewModel cell in _viewModel.Cells)
            cell.PropertyChanged += (s, e) => changedProperties.Add(e.PropertyName);

        // Act
        _viewModel.NewGameCommand.Execute(null);

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(changedProperties.Count(p => p == nameof(CellViewModel.Value)), Is.EqualTo(16));
            Assert.That(changedProperties.Count(p => p == nameof(CellViewModel.IsEmpty)), Is.EqualTo(16));
        }
    }

    [Test]
    public void MoveCommand_ShouldMoveCellAndCountMove_WhenCellIsMoveable()
    {
        // Arrange
        StartGameWithOneMoveLeft();
        CellViewModel clickedCell = GetCell(3, 1);
        var changedProperties = new List<string>();
        clickedCell.PropertyChanged += (s, e) => changedProperties.Add(e.PropertyName);

        // Act
        _viewModel.MoveCommand.Execute(clickedCell);

        // Assert
        using (Assert.EnterMultipleScope())
        {
            // Число 14 переехало на место пустой клетки, а пустая клетка встала на место нажатой
            Assert.That(GetCell(3, 2).Value, Is.EqualTo(14U));
            Assert.That(clickedCell.IsEmpty, Is.True);
            Assert.That(changedProperties, Is.EquivalentTo([nameof(CellViewModel.Value), nameof(CellViewModel.IsEmpty)]));
            Assert.That(_viewModel.GameMovesText, Is.EqualTo("1"));
            Assert.That(_dialogService.WinMessageScore, Is.Null);
        }
    }

    [Test]
    public void MoveCommand_ShouldNotCountMove_WhenCellIsNotMoveable()
    {
        // Arrange
        StartGameWithOneMoveLeft();

        // Act
        _viewModel.MoveCommand.Execute(GetCell(0, 0));

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(GetCell(0, 0).Value, Is.EqualTo(1U));
            Assert.That(_viewModel.GameMovesText, Is.EqualTo("0"));
        }
    }

    [Test]
    public void MoveCommand_ShouldShowWinMessageAndSaveBestScore_WhenMoveFinishesGame()
    {
        // Arrange
        StartGameWithOneMoveLeft();
        _timeProvider.Advance(TimeSpan.FromSeconds(90));
        _dialogService.PlayerName = "Player";

        // Act
        _viewModel.MoveCommand.Execute(GetCell(3, 3));

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_dialogService.WinMessageScore, Is.EqualTo(new Score { Moves = 1, Timer = TimeSpan.FromSeconds(90) }));
            Assert.That(_bestScoresStorage.Scores,
                Is.EqualTo([new Score { Name = "Player", Moves = 1, Timer = TimeSpan.FromSeconds(90) }]));
        }
    }

    [Test]
    public void MoveCommand_ShouldNotSaveBestScore_WhenPlayerDeclinedToGiveName()
    {
        // Arrange
        StartGameWithOneMoveLeft();
        _dialogService.PlayerName = null;

        // Act
        _viewModel.MoveCommand.Execute(GetCell(3, 3));

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_dialogService.AskPlayerNameCount, Is.EqualTo(1));
            Assert.That(_bestScoresStorage.Scores, Is.Empty);
        }
    }

    [Test]
    public void MoveCommand_ShouldResetGame_WhenMoveFinishesGame()
    {
        // Arrange
        StartGameWithOneMoveLeft();
        _timeProvider.Advance(TimeSpan.FromSeconds(90));

        // Act
        _viewModel.MoveCommand.Execute(GetCell(3, 3));

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_viewModel.IsGameStarted, Is.False);
            Assert.That(_viewModel.MoveCommand.CanExecute(GetCell(3, 2)), Is.False);
            Assert.That(_viewModel.GameTimerText, Is.EqualTo("00:00:00"));
            Assert.That(_viewModel.GameMovesText, Is.EqualTo("0"));
            Assert.That(_model.Puzzle.MovesCounter, Is.Zero);
        }
    }

    private CellViewModel GetCell(uint y, uint x) =>
        _viewModel.Cells.Single(c => c.Y == y && c.X == x);

    // Начинает партию и раскладывает поле так, что до сборки остается один ход: пустая клетка стоит слева от 15
    private void StartGameWithOneMoveLeft()
    {
        _viewModel.NewGameCommand.Execute(null);

        IPuzzle puzzle = _model.Puzzle;
        for (uint y = 0; y < puzzle.FieldSideSize; y++)
            for (uint x = 0; x < puzzle.FieldSideSize; x++)
                puzzle[y, x] = y * puzzle.FieldSideSize + x + 1;
        puzzle[3, 3] = 15;
        puzzle[3, 2] = puzzle.EmptyCellValue;
        puzzle.EmptyY = 3;
        puzzle.EmptyX = 2;
    }
}
