using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Puzzle15.Common.DomainModel;
using Puzzle15.TestUtilities;
using Puzzle15.Wpf.Mvvm.UnitTests.Fakes;
using Puzzle15.Wpf.Mvvm.ViewModels;

namespace Puzzle15.Wpf.Mvvm.UnitTests.ViewModels;

[TestFixture]
public class BestScoresViewModelTests
{
    private FakeBestScoresStorage _bestScoresStorage;
    private FakeDialogService _dialogService;
    private PuzzleDomainModel _model;

    [SetUp]
    public void SetUp()
    {
        // Путь к файлу попадает в текст предупреждения
        _bestScoresStorage = new FakeBestScoresStorage { FileName = @"C:\Program Files\Puzzle15\Puzzle.dat" };
        _dialogService = new FakeDialogService();
        _model = new PuzzleDomainModel(new Puzzle(), new BestScores(), _bestScoresStorage);
    }

    [Test]
    public void Rows_ShouldShowScoresAndPlaceholders_WhenTableIsPartlyFilled()
    {
        // Arrange
        _bestScoresStorage.Scores.Add(new Score { Name = "Aaaaaaaaaa", Moves = 92, Timer = new TimeSpan(0, 0, 11, 25) });
        _bestScoresStorage.Scores.Add(new Score { Name = "Bbbbbbbbb", Moves = 101, Timer = new TimeSpan(0, 1, 12, 25) });

        // Act
        var viewModel = new BestScoresViewModel(_model, _dialogService);

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(viewModel.Rows, Is.EqualTo(
            [
                new BestScoreRowViewModel(1, "Aaaaaaaaaa", "92 хода", "00:11:25"),
                new BestScoreRowViewModel(2, "Bbbbbbbbb", "101 ход", "01:12:25"),
                new BestScoreRowViewModel(3, "<best player>", "0 ходов", "00:00:00"),
                new BestScoreRowViewModel(4, "<best player>", "0 ходов", "00:00:00"),
                new BestScoreRowViewModel(5, "<best player>", "0 ходов", "00:00:00"),
                new BestScoreRowViewModel(6, "<best player>", "0 ходов", "00:00:00"),
                new BestScoreRowViewModel(7, "<best player>", "0 ходов", "00:00:00"),
                new BestScoreRowViewModel(8, "<best player>", "0 ходов", "00:00:00"),
                new BestScoreRowViewModel(9, "<best player>", "0 ходов", "00:00:00"),
                new BestScoreRowViewModel(10, "<best player>", "0 ходов", "00:00:00")
            ]));
            Assert.That(_dialogService.Warnings, Is.Empty);
        }
    }

    [Test]
    public void Rows_ShouldShowOnlyPlaceholdersAndWarning_WhenStorageCannotBeRead()
    {
        // Arrange
        _bestScoresStorage.LoadException = new IOException("Файл недоступен");

        // Act
        var viewModel = new BestScoresViewModel(_model, _dialogService);

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(viewModel.Rows.Select(r => r.Place), Is.EqualTo(Enumerable.Range(1, 10)));
            Assert.That(viewModel.Rows.Select(r => r.Name), Is.All.EqualTo("<best player>"));
            Assert.That(_dialogService.Warnings,
                Is.EqualTo(["Не удалось прочитать таблицу рекордов.\n\nФайл: C:\\Program Files\\Puzzle15\\Puzzle.dat"]));
        }
    }

    [Test]
    public void Rows_ShouldNotShowScoresLeftInMemory_WhenStorageCannotBeRead()
    {
        // Arrange
        // Первое открытие окна загрузило таблицу в память, а ко второму файл испортился
        _bestScoresStorage.Scores.Add(new Score { Name = "Aaaaaaaaaa", Moves = 92, Timer = new TimeSpan(0, 0, 11, 25) });
        _model.TryLoadBestScores();
        _bestScoresStorage.LoadException = new InvalidOperationException();

        // Act
        var viewModel = new BestScoresViewModel(_model, _dialogService);

        // Assert
        Assert.That(viewModel.Rows.Select(r => r.Name), Is.All.EqualTo("<best player>"));
    }
}
