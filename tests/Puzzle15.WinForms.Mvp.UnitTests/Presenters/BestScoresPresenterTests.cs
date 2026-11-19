using System;
using System.IO;
using NUnit.Framework;
using Puzzle15.Common.DomainModel;
using Puzzle15.TestUtilities;
using Puzzle15.WinForms.Mvp.Presenters;
using Puzzle15.WinForms.Mvp.UnitTests.Fakes;

namespace Puzzle15.WinForms.Mvp.UnitTests.Presenters;

[TestFixture]
public class BestScoresPresenterTests
{
    private FakeBestScoresStorage _bestScoresStorage;
    private PuzzleDomainModel _model;
    private FakeBestScoresView _view;

    [SetUp]
    public void SetUp()
    {
        _bestScoresStorage = new FakeBestScoresStorage();
        _model = new PuzzleDomainModel(new Puzzle(), new BestScores(), _bestScoresStorage);
        _view = new FakeBestScoresView();
    }

    // Заглушка реализует IDisposable вслед за IBestScoresView, поэтому анализатор NUnit требует ее освобождать
    [TearDown]
    public void TearDown()
    {
        _view.Dispose();
    }

    [Test]
    public void Constructor_ShouldShowLoadedScores_WhenTableIsPartlyFilled()
    {
        // Arrange
        _bestScoresStorage.Scores.Add(new Score { Name = "Aaaaaaaaaa", Moves = 92, Timer = new TimeSpan(0, 0, 11, 25) });
        _bestScoresStorage.Scores.Add(new Score { Name = "Bbbbbbbbb", Moves = 101, Timer = new TimeSpan(0, 1, 12, 25) });

        // Act
        new BestScoresPresenter(_model, _view);

        // Assert
        // В остальных строках таблицы остается то, что задано в дизайнере
        Assert.That(_view.Rows, Is.EqualTo(
        [
            new FakeBestScoresView.Row(0, "Aaaaaaaaaa", "92 хода", "00:11:25"),
            new FakeBestScoresView.Row(1, "Bbbbbbbbb", "101 ход", "01:12:25")
        ]));
    }

    [Test]
    public void Constructor_ShouldShowNothing_WhenStorageCannotBeRead()
    {
        // Arrange
        _bestScoresStorage.LoadException = new IOException("Файл недоступен");

        // Act
        new BestScoresPresenter(_model, _view);

        // Assert
        Assert.That(_view.Rows, Is.Empty);
    }
}
