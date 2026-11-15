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
    private string _tempDirectory;
    private string _tempFileName;

    [SetUp]
    public void SetUp()
    {
        // Отдельная временная папка на каждый тест: в TearDown удаляется всё,
        // что в ней оказалось, включая временный файл, который создаёт Save
        _tempDirectory = Path.Combine(Path.GetTempPath(), $"Puzzle15.{Guid.NewGuid():N}");
        Directory.CreateDirectory(_tempDirectory);
        _tempFileName = Path.Combine(_tempDirectory, Options.BestScoresStorageFileName);
    }

    [TearDown]
    public void TearDown()
    {
        // Снимаем атрибут «только чтение», иначе файл может не удалиться
        foreach (var fileName in Directory.EnumerateFiles(_tempDirectory))
            File.SetAttributes(fileName, FileAttributes.Normal);
        Directory.Delete(_tempDirectory, recursive: true);
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
        new BestScoresStorage(_tempFileName).Save(bestScores);

        // Assert
        Assert.That(ReadScoresFile(), Is.EqualTo(bestScores.Scores));
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
        WriteScoresFile(bestScores.Scores);

        // Act
        var loadBestScores = new BestScores();
        new BestScoresStorage(_tempFileName).Load(loadBestScores);

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
    public void Save_ShouldReplacePreviousFile_WhenFileExists()
    {
        // Arrange
        var bestScoresStorage = new BestScoresStorage(_tempFileName);
        var previousBestScores = new BestScores();
        previousBestScores.Add(new Score { Name = "Aaaaaaaaaa", Moves = 92, Timer = new TimeSpan(0, 0, 11, 25) });
        bestScoresStorage.Save(previousBestScores);

        var bestScores = new BestScores();
        bestScores.Add(new Score { Name = "Bbbbbbbbb", Moves = 102, Timer = new TimeSpan(0, 0, 12, 25) });
        bestScores.Add(new Score { Name = "Cccccc", Moves = 103, Timer = new TimeSpan(0, 0, 13, 25) });

        // Act
        bestScoresStorage.Save(bestScores);

        // Assert
        var loadBestScores = new BestScores();
        bestScoresStorage.Load(loadBestScores);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(loadBestScores.Scores, Is.EqualTo(bestScores.Scores));
            // После успешного сохранения рядом не должно остаться временных файлов
            Assert.That(Directory.GetFiles(_tempDirectory), Is.EqualTo([_tempFileName]));
        }
    }

    [Test]
    public void Save_ShouldKeepPreviousFile_WhenSerializationFails()
    {
        // Arrange
        var bestScoresStorage = new BestScoresStorage(_tempFileName);
        var bestScores = new BestScores();
        bestScores.Add(new Score { Name = "Aaaaaaaaaa", Moves = 92, Timer = new TimeSpan(0, 0, 11, 25) });
        bestScoresStorage.Save(bestScores);

        // XmlSerializer не знает о типе-наследнике и бросает исключение посреди записи
        var brokenBestScores = new BestScores();
        brokenBestScores.Scores.Add(new UnknownScore { Name = "Bbbbbbbbb", Moves = 102, Timer = new TimeSpan(0, 0, 12, 25) });

        // Act
        Assert.That(() => bestScoresStorage.Save(brokenBestScores), Throws.InvalidOperationException);

        // Assert
        var loadBestScores = new BestScores();
        bestScoresStorage.Load(loadBestScores);
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
        WriteScoresFile(fileScores);

        // Act
        var loadBestScores = new BestScores();
        new BestScoresStorage(_tempFileName).Load(loadBestScores);

        // Assert
        Assert.That(loadBestScores.Scores.Select(s => s.Moves), Is.EqualTo(new uint[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }));
    }

    // Запись и чтение файла напрямую через XmlSerializer, в обход BestScoresStorage:
    // так тест Save не зависит от Load, а тесты Load не зависят от Save
    private void WriteScoresFile(List<Score> scores)
    {
        using var fileStream = File.Create(_tempFileName);
        new XmlSerializer(typeof(List<Score>)).Serialize(fileStream, scores);
    }

    private List<Score> ReadScoresFile()
    {
        using var fileStream = File.OpenRead(_tempFileName);
        return (List<Score>)new XmlSerializer(typeof(List<Score>)).Deserialize(fileStream);
    }

    // Наследник Score, о котором XmlSerializer не знает: его сериализация завершается исключением
    public class UnknownScore : Score
    {
    }
}
