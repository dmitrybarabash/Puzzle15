using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using NUnit.Framework;
using Puzzle15.Common.DomainModel;

namespace Puzzle15.Common.UnitTests.DomainModel;

[TestFixture]
public class BestScoresStorageTests
{
    private string _tempFileName;

    [SetUp]
    public void SetUp() =>
        _tempFileName = Path.Combine(Path.GetTempPath(), $"Puzzle15.{Guid.NewGuid():N}.dat");

    [TearDown]
    public void TearDown()
    {
        if (File.Exists(_tempFileName))
        {
            File.SetAttributes(_tempFileName, FileAttributes.Normal);
            File.Delete(_tempFileName);
        }
    }

    [Test]
    public void Save_ShouldSave_When10BestScores()
    {
        // Arrange
        var bestScores = new BestScores();
        bestScores.Add(new Score { Name = "Aaaaaaaaaa", Moves = 92, Timer = new TimeSpan(0, 0, 11, 25) });
        bestScores.Add(new Score { Name = "Bbbbbbbbb", Moves = 102, Timer = new TimeSpan(0, 0, 12, 25) });
        bestScores.Add(new Score { Name = "Cccccc", Moves = 103, Timer = new TimeSpan(0, 0, 13, 25) });
        bestScores.Add(new Score { Name = "Dmitrik", Moves = 124, Timer = new TimeSpan(0, 0, 14, 25) });
        bestScores.Add(new Score { Name = "Eeeeee", Moves = 135, Timer = new TimeSpan(0, 0, 15, 25) });
        bestScores.Add(new Score { Name = "Ffffffffffff", Moves = 146, Timer = new TimeSpan(0, 0, 16, 25) });
        bestScores.Add(new Score { Name = "Gggg", Moves = 147, Timer = new TimeSpan(0, 1, 17, 25) });
        bestScores.Add(new Score { Name = "Hhhhhhh", Moves = 158, Timer = new TimeSpan(0, 1, 18, 25) });
        bestScores.Add(new Score { Name = "Iiiiiiii", Moves = 159, Timer = new TimeSpan(0, 1, 19, 25) });
        bestScores.Add(new Score { Name = "Jjjjjjj", Moves = 200, Timer = new TimeSpan(0, 1, 20, 25) });

        // Act
        var bestScoresStoragePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\{Options.BestScoresStorageFileName}";
        new BestScoresStorage(bestScoresStoragePath).Save(bestScores);
        bool actual = File.Exists(bestScoresStoragePath);

        // Assert
        Assert.That(actual, Is.True);
    }

    [Test]
    public void Load_ShouldLoad_When10BestScores()
    {
        // Arrange
        var bestScores = new BestScores();
        bestScores.Add(new Score { Name = "Aaaaaaaaaa", Moves = 92, Timer = new TimeSpan(0, 0, 11, 25) });
        bestScores.Add(new Score { Name = "Bbbbbbbbb", Moves = 102, Timer = new TimeSpan(0, 0, 12, 25) });
        bestScores.Add(new Score { Name = "Cccccc", Moves = 103, Timer = new TimeSpan(0, 0, 13, 25) });
        bestScores.Add(new Score { Name = "Dmitrik", Moves = 124, Timer = new TimeSpan(0, 0, 14, 25) });
        bestScores.Add(new Score { Name = "Eeeeee", Moves = 135, Timer = new TimeSpan(0, 0, 15, 25) });
        bestScores.Add(new Score { Name = "Ffffffffffff", Moves = 146, Timer = new TimeSpan(0, 0, 16, 25) });
        bestScores.Add(new Score { Name = "Gggg", Moves = 147, Timer = new TimeSpan(0, 1, 17, 25) });
        bestScores.Add(new Score { Name = "Hhhhhhh", Moves = 158, Timer = new TimeSpan(0, 1, 18, 25) });
        bestScores.Add(new Score { Name = "Iiiiiiii", Moves = 159, Timer = new TimeSpan(0, 1, 19, 25) });
        bestScores.Add(new Score { Name = "Jjjjjjj", Moves = 200, Timer = new TimeSpan(0, 1, 20, 25) });

        // Act
        var bestScoresStoragePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\{Options.BestScoresStorageFileName}";
        var bestScoresStorage = new BestScoresStorage(bestScoresStoragePath);
        bestScoresStorage.Save(bestScores);

        var loadBestScores = new BestScores();
        bestScoresStorage.Load(loadBestScores);

        // Assert

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Вариант на случай отсутствия перегруженного метода Score.Equals
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //if (bestScores.Count != loadBestScores.Count)
        //    Assert.Fail();
        //bool equals = true;
        //for (int i = 0; i < bestScores.Count; i++)
        //{
        //    if (bestScores[i].Name != loadBestScores[i].Name ||
        //        bestScores[i].Moves != loadBestScores[i].Moves ||
        //        bestScores[i].Timer != loadBestScores[i].Timer)
        //    {
        //        equals = false;
        //        break;
        //    }
        //}
        //Assert.That(equals, Is.True);

        Assert.That(loadBestScores.Scores, Is.EqualTo(bestScores.Scores));
    }

    [Test]
    public void Load_ShouldLoad_WhenFileIsReadOnly()
    {
        // Arrange
        var bestScores = new BestScores();
        bestScores.Add(new Score { Name = "Aaaaaaaaaa", Moves = 92, Timer = new TimeSpan(0, 0, 11, 25) });
        bestScores.Add(new Score { Name = "Bbbbbbbbb", Moves = 102, Timer = new TimeSpan(0, 0, 12, 25) });
        var bestScoresStorage = new BestScoresStorage(_tempFileName);
        bestScoresStorage.Save(bestScores);
        File.SetAttributes(_tempFileName, FileAttributes.ReadOnly);

        // Act
        var loadBestScores = new BestScores();
        bestScoresStorage.Load(loadBestScores);

        // Assert
        Assert.That(loadBestScores.Scores, Is.EqualTo(bestScores.Scores));
    }

    [Test]
    public void Load_ShouldLoadMaxCountBestScoresSorted_WhenMoreThanMaxCountUnsortedScores()
    {
        // Arrange

        // Неотсортированный файл, в котором больше MaxCount результатов (например, отредактированный вручную)
        uint[] moves = [12, 3, 7, 1, 11, 5, 9, 2, 10, 4, 8, 6];
        var fileScores = moves
            .Select(m => new Score { Name = m.ToString(), Moves = m, Timer = new TimeSpan(0, 0, 10, 25) })
            .ToList();
        using (var fileStream = File.Create(_tempFileName))
            new XmlSerializer(typeof(List<Score>)).Serialize(fileStream, fileScores);

        // Act
        var loadBestScores = new BestScores();
        new BestScoresStorage(_tempFileName).Load(loadBestScores);

        // Assert
        Assert.That(loadBestScores.Scores.Select(s => s.Moves), Is.EqualTo(new uint[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }));
    }
}
