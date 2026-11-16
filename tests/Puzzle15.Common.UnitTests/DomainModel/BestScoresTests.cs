using System;
using System.Linq;
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
        var bestScores = CreateBestScores(BestScores.MaxCount);
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
        var bestScores = CreateBestScores(BestScores.MaxCount);
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
        var score = new Score { Name = "Dmitrik", Moves = BestScores.MaxCount + 5, Timer = new TimeSpan(0, 0, 10, 25) };

        // Act
        bool actual = bestScores.CanBeAdded(score);

        // Assert
        Assert.That(actual, Is.False);
    }

    [Test]
    public void CanBeAdded_ShouldReturnFalse_WhenScoreEqualsWorstOfMaxCountScores()
    {
        // Arrange
        var bestScores = CreateBestScores(BestScores.MaxCount);
        // Те же ходы и время, что у последнего результата: при равенстве новый встаёт после имеющихся
        var score = new Score { Name = "Dmitrik", Moves = BestScores.MaxCount, Timer = new TimeSpan(0, 0, 10, 25) };

        // Act
        bool actual = bestScores.CanBeAdded(score);

        // Assert
        Assert.That(actual, Is.False);
    }

    [Test]
    public void CanBeAdded_ShouldThrowArgumentNullException_WhenScoreIsNull()
    {
        // Arrange
        var bestScores = new BestScores();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => bestScores.CanBeAdded(null));
    }

    [TestCase(0, 1U, ExpectedResult = 0)]
    [TestCase(1, 0U, ExpectedResult = 0)]
    [TestCase(1, 1U, ExpectedResult = 0)]
    [TestCase(1, 2U, ExpectedResult = 1)]
    [TestCase(2, 1U, ExpectedResult = 0)]
    [TestCase(2, 2U, ExpectedResult = 1)]
    [TestCase(2, 3U, ExpectedResult = 2)]
    [TestCase(9, 5U, ExpectedResult = 4)]
    [TestCase(9, 9U, ExpectedResult = 8)]
    [TestCase(9, 10U, ExpectedResult = 9)]
    [TestCase(10, 5U, ExpectedResult = 4)]
    [TestCase(10, 10U, ExpectedResult = 9)]
    public int Add_ShouldAddAtExpectedIndex_WhenExistingScoresGiven(int existingScores, uint moves)
    {
        // Arrange
        var bestScores = CreateBestScores(existingScores);
        var score = new Score { Name = "Dmitrik", Moves = moves, Timer = new TimeSpan(0, 0, 1, 30) };

        // Act
        bestScores.Add(score);

        // Assert
        return bestScores.Scores.IndexOf(score);
    }

    [Test]
    public void Add_ShouldPlaceScoreAfterEqualScores_WhenEqualScoresExist()
    {
        // Arrange
        var bestScores = new BestScores();
        bestScores.Add(new Score { Name = "A", Moves = 1, Timer = new TimeSpan(0, 0, 10, 25) });
        bestScores.Add(new Score { Name = "B", Moves = 2, Timer = new TimeSpan(0, 0, 10, 25) });
        bestScores.Add(new Score { Name = "C", Moves = 2, Timer = new TimeSpan(0, 0, 10, 25) });
        bestScores.Add(new Score { Name = "D", Moves = 3, Timer = new TimeSpan(0, 0, 10, 25) });
        // Те же ходы и время, что у B и C
        var score = new Score { Name = "Dmitrik", Moves = 2, Timer = new TimeSpan(0, 0, 10, 25) };

        // Act
        bestScores.Add(score);

        // Assert
        // При равенстве выше стоит тот, кто показал результат раньше
        Assert.That(bestScores.Scores.Select(s => s.Name), Is.EqualTo(["A", "B", "C", "Dmitrik", "D"]));
    }

    [TestCase(10U)]  // Равен худшему результату в таблице
    [TestCase(11U)]  // Хуже худшего результата в таблице
    public void Add_ShouldNotChangeBestScores_WhenScoreIsNotOneOfTheBest(uint moves)
    {
        // Arrange
        var bestScores = CreateBestScores(BestScores.MaxCount);
        var expected = bestScores.Scores.ToArray();
        var score = new Score { Name = "Dmitrik", Moves = moves, Timer = new TimeSpan(0, 0, 10, 25) };

        // Act
        bestScores.Add(score);

        // Assert
        // Новый результат не должен попасть ни на одно место, а имеющиеся — ни сдвинуться, ни пропасть
        Assert.That(bestScores.Scores, Is.EqualTo(expected));
    }

    [Test]
    public void Add_ShouldKeepMaxCountScores_WhenMoreThanMaxCountScores()
    {
        // Arrange
        // Рекорды (больше MaxCount, например прочитанные из файла, отредактированного вручную)
        var bestScores = new BestScores();
        for (uint i = 2; i <= BestScores.MaxCount + 3; i++)
            bestScores.Scores.Add(new Score { Name = "A", Moves = i, Timer = new TimeSpan(0, 0, 10, 25) });
        var score = new Score { Name = "Dmitrik", Moves = 1, Timer = new TimeSpan(0, 0, 10, 25) };

        // Act
        bestScores.Add(score);

        // Assert
        Assert.That(bestScores.Count, Is.EqualTo(BestScores.MaxCount));
        Assert.That(bestScores[0], Is.SameAs(score));
    }

    [Test]
    public void Add_ShouldThrowArgumentNullException_WhenScoreIsNull()
    {
        // Arrange
        var bestScores = new BestScores();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => bestScores.Add(null));
        Assert.That(bestScores.Scores, Is.Empty);
    }

    // Таблица из count результатов: 1, 2, …, count ходов за одинаковое время
    private static BestScores CreateBestScores(int count)
    {
        var bestScores = new BestScores();
        for (uint moves = 1; moves <= count; moves++)
            bestScores.Add(new Score { Name = moves.ToString(), Moves = moves, Timer = new TimeSpan(0, 0, 10, 25) });
        return bestScores;
    }
}
