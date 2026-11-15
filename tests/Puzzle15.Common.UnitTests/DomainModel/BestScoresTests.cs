using System;
using NUnit.Framework;
using Puzzle15.Common.DomainModel;

namespace Puzzle15.Common.UnitTests.DomainModel;

[TestFixture]
public class BestScoresTests
{
    [Test]
    public void CanBeAdded_ShouldReturnTrue_WhenScoreIsOneOfTheBest()
    {
        // Arrange

        // Best scores
        var bestScores = new BestScores();
        bestScores.Add(new Score { Name = "A", Moves = 1, Timer = new TimeSpan(0, 0, 10, 25) });
        bestScores.Add(new Score { Name = "A", Moves = 2, Timer = new TimeSpan(0, 0, 10, 25) });
        bestScores.Add(new Score { Name = "A", Moves = 3, Timer = new TimeSpan(0, 0, 10, 25) });
        bestScores.Add(new Score { Name = "A", Moves = 4, Timer = new TimeSpan(0, 0, 10, 25) });
        bestScores.Add(new Score { Name = "A", Moves = 5, Timer = new TimeSpan(0, 0, 10, 25) });
        bestScores.Add(new Score { Name = "A", Moves = 6, Timer = new TimeSpan(0, 0, 10, 25) });
        bestScores.Add(new Score { Name = "A", Moves = 7, Timer = new TimeSpan(0, 0, 10, 25) });
        bestScores.Add(new Score { Name = "A", Moves = 8, Timer = new TimeSpan(0, 0, 10, 25) });
        bestScores.Add(new Score { Name = "A", Moves = 9, Timer = new TimeSpan(0, 0, 10, 25) });
        bestScores.Add(new Score { Name = "A", Moves = 10, Timer = new TimeSpan(0, 0, 10, 25) });
        // New score
        var score = new Score { Name = "Dmitrik", Moves = 5, Timer = new TimeSpan(0, 0, 10, 25) };

        // Act
        bool actual = bestScores.CanBeAdded(score);

        // Assert
        Assert.That(actual, Is.True);
    }

    [Test]
    public void CanBeAdded_ShouldReturnFalse_WhenScoreIsNotOneOfTheBest()
    {
        // Arrange

        // Best scores
        var bestScores = new BestScores();
        bestScores.Add(new Score { Name = "A", Moves = 1, Timer = new TimeSpan(0, 0, 10, 25) });
        bestScores.Add(new Score { Name = "A", Moves = 2, Timer = new TimeSpan(0, 0, 10, 25) });
        bestScores.Add(new Score { Name = "A", Moves = 3, Timer = new TimeSpan(0, 0, 10, 25) });
        bestScores.Add(new Score { Name = "A", Moves = 4, Timer = new TimeSpan(0, 0, 10, 25) });
        bestScores.Add(new Score { Name = "A", Moves = 5, Timer = new TimeSpan(0, 0, 10, 25) });
        bestScores.Add(new Score { Name = "A", Moves = 6, Timer = new TimeSpan(0, 0, 10, 25) });
        bestScores.Add(new Score { Name = "A", Moves = 7, Timer = new TimeSpan(0, 0, 10, 25) });
        bestScores.Add(new Score { Name = "A", Moves = 8, Timer = new TimeSpan(0, 0, 10, 25) });
        bestScores.Add(new Score { Name = "A", Moves = 9, Timer = new TimeSpan(0, 0, 10, 25) });
        bestScores.Add(new Score { Name = "A", Moves = 10, Timer = new TimeSpan(0, 0, 10, 25) });
        // New score
        var score = new Score { Name = "Dmitrik", Moves = 11, Timer = new TimeSpan(0, 0, 10, 25) };

        // Act
        bool actual = bestScores.CanBeAdded(score);

        // Assert
        Assert.That(actual, Is.False);
    }

    [Test]
    public void CanBeAdded_ShouldReturnFalseForWorstScore_WhenMoreThanMaxCountScores()
    {
        // Arrange

        // Рекорды (больше MaxCount, например прочитанные из файла, отредактированного вручную)
        var bestScores = new BestScores();
        for (uint i = 1; i <= BestScores.MaxCount + 2; i++)
            bestScores.Scores.Add(new Score { Name = "A", Moves = i, Timer = new TimeSpan(0, 0, 10, 25) });
        // New score
        var score = new Score { Name = "Dmitrik", Moves = BestScores.MaxCount + 5, Timer = new TimeSpan(0, 0, 10, 25) };

        // Act
        bool actual = bestScores.CanBeAdded(score);

        // Assert
        Assert.That(actual, Is.False);
    }

    [TestCase(0, 1U, 0, ExpectedResult = true)]
    [TestCase(1, 0U, 0, ExpectedResult = true)]
    [TestCase(1, 1U, 0, ExpectedResult = true)]
    [TestCase(1, 2U, 1, ExpectedResult = true)]
    [TestCase(2, 1U, 0, ExpectedResult = true)]
    [TestCase(2, 2U, 1, ExpectedResult = true)]
    [TestCase(2, 3U, 2, ExpectedResult = true)]
    [TestCase(9, 5U, 4, ExpectedResult = true)]
    [TestCase(9, 9U, 8, ExpectedResult = true)]
    [TestCase(9, 10U, 9, ExpectedResult = true)]
    [TestCase(10, 5U, 4, ExpectedResult = true)]
    [TestCase(10, 10U, 9, ExpectedResult = true)]
    [TestCase(10, 11U, 9, ExpectedResult = false)]
    public bool Add_ShouldAddAtExpectedIndex_WhenExistingScoresGiven(int existingScores, uint moves, int expectedIndex)
    {
        // Arrange
        var bestScores = new BestScores();
        for (uint i = 0; i < existingScores; i++)
            bestScores.Add(new Score { Name = i.ToString(), Moves = i + 1, Timer = new TimeSpan(0, 1, 2, 3) });
        var score = new Score { Name = "Dmitrik", Moves = moves, Timer = new TimeSpan(0, 0, 1, 30) };

        // Act
        bestScores.Add(score);

        // Assert
        return bestScores.Scores[expectedIndex] == score;
    }

    [Test]
    public void Add_ShouldKeepMaxCountScores_WhenMoreThanMaxCountScores()
    {
        // Arrange

        // Рекорды (больше MaxCount, например прочитанные из файла, отредактированного вручную)
        var bestScores = new BestScores();
        for (uint i = 2; i <= BestScores.MaxCount + 3; i++)
            bestScores.Scores.Add(new Score { Name = "A", Moves = i, Timer = new TimeSpan(0, 0, 10, 25) });
        // New score
        var score = new Score { Name = "Dmitrik", Moves = 1, Timer = new TimeSpan(0, 0, 10, 25) };

        // Act
        bestScores.Add(score);

        // Assert
        Assert.That(bestScores.Count, Is.EqualTo(BestScores.MaxCount));
        Assert.That(bestScores[0], Is.SameAs(score));
    }
}
