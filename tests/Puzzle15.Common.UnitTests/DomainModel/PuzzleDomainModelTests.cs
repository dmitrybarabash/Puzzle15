using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Puzzle15.Common.DomainModel;

namespace Puzzle15.Common.UnitTests.DomainModel;

[TestFixture]
public class PuzzleDomainModelTests
{
    private FakeBestScoresStorage _bestScoresStorage;
    private PuzzleDomainModel _model;

    [SetUp]
    public void SetUp()
    {
        _bestScoresStorage = new FakeBestScoresStorage();
        _model = new PuzzleDomainModel(new Puzzle(), new BestScores(), _bestScoresStorage);
    }

    [Test]
    public void TryLoadBestScores_ShouldLoadScoresFromStorage_WhenStorageIsReadable()
    {
        // Arrange
        _bestScoresStorage.Scores.Add(new Score { Name = "Aaaaaaaaaa", Moves = 92, Timer = new TimeSpan(0, 0, 11, 25) });
        _bestScoresStorage.Scores.Add(new Score { Name = "Bbbbbbbbb", Moves = 102, Timer = new TimeSpan(0, 0, 12, 25) });

        // Act
        bool actual = _model.TryLoadBestScores();

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(actual, Is.True);
            Assert.That(_model.BestScores.Scores, Is.EqualTo(_bestScoresStorage.Scores));
        }
    }

    [TestCase(typeof(IOException))]
    [TestCase(typeof(UnauthorizedAccessException))]
    [TestCase(typeof(InvalidOperationException))]
    public void TryLoadBestScores_ShouldReturnFalse_WhenStorageCannotBeRead(Type exceptionType)
    {
        // Arrange
        _bestScoresStorage.LoadException = (Exception)Activator.CreateInstance(exceptionType);

        // Act
        bool actual = _model.TryLoadBestScores();

        // Assert
        Assert.That(actual, Is.False);
    }

    [Test]
    public void TryLoadBestScores_ShouldThrow_WhenErrorIsNotStorageError()
    {
        // Arrange
        // Перехватываются только ошибки работы с файлом, остальные ошибки нельзя молча проглатывать
        _bestScoresStorage.LoadException = new ArgumentException();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _model.TryLoadBestScores());
    }

    [Test]
    public void TryAddBestScore_ShouldAddAndSaveScore_WhenScoreIsOneOfTheBestAndNameGiven()
    {
        // Arrange
        var score = new Score { Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };

        // Act
        bool actual = _model.TryAddBestScore(score, () => "Dmitrik");

        // Assert
        var expected = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        using (Assert.EnterMultipleScope())
        {
            Assert.That(actual, Is.True);
            Assert.That(_bestScoresStorage.Scores, Is.EqualTo(new[] { expected }));
        }
    }

    [Test]
    public void TryAddBestScore_ShouldNotAskPlayerName_WhenScoreIsNotOneOfTheBest()
    {
        // Arrange
        // В хранилище MaxCount результатов лучше нового, а таблица в памяти пуста:
        // модель должна перечитать таблицу из хранилища, прежде чем решать
        for (uint i = 1; i <= BestScores.MaxCount; i++)
            _bestScoresStorage.Scores.Add(new Score { Name = "A", Moves = i, Timer = new TimeSpan(0, 0, 10, 25) });
        var score = new Score { Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        bool isPlayerNameAsked = false;

        // Act
        bool actual = _model.TryAddBestScore(score, () => { isPlayerNameAsked = true; return "Dmitrik"; });

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(actual, Is.False);
            Assert.That(isPlayerNameAsked, Is.False);
            Assert.That(_bestScoresStorage.Scores, Has.Count.EqualTo(BestScores.MaxCount));
        }
    }

    [Test]
    public void TryAddBestScore_ShouldNotSave_WhenPlayerDeclinedToEnterName()
    {
        // Arrange
        var score = new Score { Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };

        // Act
        bool actual = _model.TryAddBestScore(score, () => null);

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(actual, Is.False);
            Assert.That(_bestScoresStorage.SaveCount, Is.Zero);
        }
    }

    [TestCase(typeof(IOException))]
    [TestCase(typeof(UnauthorizedAccessException))]
    [TestCase(typeof(InvalidOperationException))]
    public void TryAddBestScore_ShouldNotAskPlayerName_WhenStorageCannotBeRead(Type exceptionType)
    {
        // Arrange
        _bestScoresStorage.LoadException = (Exception)Activator.CreateInstance(exceptionType);
        var score = new Score { Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        bool isPlayerNameAsked = false;

        // Act
        bool actual = _model.TryAddBestScore(score, () => { isPlayerNameAsked = true; return "Dmitrik"; });

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(actual, Is.False);
            Assert.That(isPlayerNameAsked, Is.False);
        }
    }

    [TestCase(typeof(IOException))]
    [TestCase(typeof(UnauthorizedAccessException))]
    [TestCase(typeof(InvalidOperationException))]
    public void TryAddBestScore_ShouldReturnFalse_WhenStorageCannotBeWritten(Type exceptionType)
    {
        // Arrange
        _bestScoresStorage.SaveException = (Exception)Activator.CreateInstance(exceptionType);
        var score = new Score { Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };

        // Act
        bool actual = _model.TryAddBestScore(score, () => "Dmitrik");

        // Assert
        Assert.That(actual, Is.False);
    }

    [Test]
    public void TryAddBestScore_ShouldThrow_WhenAskPlayerNameThrows()
    {
        // Arrange
        // Ошибка в окне ввода имени — это ошибка в коде приложения, её нельзя молча проглатывать,
        // даже если её тип совпадает с типом ошибки работы с файлом
        var score = new Score { Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };

        // Act & Assert
        Assert.Throws<InvalidOperationException>(
            () => _model.TryAddBestScore(score, () => throw new InvalidOperationException()));
    }

    // Хранилище рекордов в памяти. Если задано исключение, бросает его, как при ошибке работы с файлом.
    public class FakeBestScoresStorage : IBestScoresStorage
    {
        public List<Score> Scores { get; } = [];
        public int SaveCount { get; private set; }
        public Exception LoadException { get; set; }
        public Exception SaveException { get; set; }

        public string FileName { get; set; }

        public void Load(IBestScores bestScores)
        {
            if (LoadException is not null)
                throw LoadException;
            bestScores.Scores.Clear();
            bestScores.Scores.AddRange(Scores);
        }

        public void Save(IBestScores bestScores)
        {
            if (SaveException is not null)
                throw SaveException;
            Scores.Clear();
            Scores.AddRange(bestScores.Scores);
            SaveCount++;
        }
    }
}
