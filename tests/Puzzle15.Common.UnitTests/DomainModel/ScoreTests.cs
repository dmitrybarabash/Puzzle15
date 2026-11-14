using System;
using NUnit.Framework;
using Puzzle15.Common.DomainModel;

namespace Puzzle15.Common.UnitTests.DomainModel;

[TestFixture]
class ScoreTests
{
    [Test]
    public void EqualOperator_ShouldReturnTrue_WhenOperandsAreEqual()
    {
        // Arrange
        var score = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        var anotherScore = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        const bool expected = true;

        // Act
        bool actual = score == anotherScore;

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void EqualOperator_ShouldReturnFalse_WhenLeftOperandIsNull()
    {
        // Arrange
        var score = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        var anotherScore = (Score)null;
        const bool expected = false;

        // Act
        bool actual = score == anotherScore;

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void EqualOperator_ShouldReturnFalse_WhenRightOperandIsNull()
    {
        // Arrange
        var score = (Score)null;
        var anotherScore = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        const bool expected = false;

        // Act
        bool actual = score == anotherScore;

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void EqualOperator_ShouldReturnTrue_WhenBothOperandsAreNull()
    {
        // Arrange
        var score = (Score)null;
        var anotherScore = (Score)null;
        const bool expected = true;

        // Act
        bool actual = score == anotherScore;

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void EqualOperator_ShouldReturnTrue_WhenBothOperandsReferToTheSameObject()
    {
        // Arrange
        var score = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        var anotherScore = score;
        const bool expected = true;

        // Act
        bool actual = score == anotherScore;

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void EqualOperator_ShouldReturnFalse_WhenRightOperandHasGreaterMoves()
    {
        // Arrange
        var score = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        var anotherScore = new Score { Name = "Dmitrik", Moves = 200, Timer = new TimeSpan(0, 0, 1, 30) };
        const bool expected = false;

        // Act
        bool actual = score == anotherScore;

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void EqualOperator_ShouldReturnFalse_WhenRightOperandHasLessMoves()
    {
        // Arrange
        var score = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        var anotherScore = new Score { Name = "Dmitrik", Moves = 50, Timer = new TimeSpan(0, 0, 1, 30) };
        const bool expected = false;

        // Act
        bool actual = score == anotherScore;

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void EqualOperator_ShouldReturnFalse_WhenRightOperandHasGreaterTimer()
    {
        // Arrange
        var score = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        var anotherScore = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 3, 00) };
        const bool expected = false;

        // Act
        bool actual = score == anotherScore;

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void EqualOperator_ShouldReturnFalse_WhenRightOperandHasLessTimer()
    {
        // Arrange
        var score = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        var anotherScore = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 0, 45) };
        const bool expected = false;

        // Act
        bool actual = score == anotherScore;

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CompareTo_ShouldReturn0_WhenObjectIsEqual()
    {
        // Arrange
        var score = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        var anotherScore = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        const int expected = 0;

        // Act
        var actual = score.CompareTo(anotherScore);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CompareTo_ShouldReturnMinus1_WhenObjectHasGreaterMoves()
    {
        // Arrange
        var score = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        var anotherScore = new Score { Name = "Dmitrik", Moves = 200, Timer = new TimeSpan(0, 0, 1, 30) };
        const int expected = -1;

        // Act
        var actual = score.CompareTo(anotherScore);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CompareTo_ShouldReturnMinus1_WhenObjectHasEqualMovesAndGreaterTimer()
    {
        // Arrange
        var score = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        var anotherScore = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 3, 00) };
        const int expected = -1;

        // Act
        var actual = score.CompareTo(anotherScore);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CompareTo_ShouldReturn1_WhenObjectHasLessMoves()
    {
        // Arrange
        var score = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        var anotherScore = new Score { Name = "Dmitrik", Moves = 50, Timer = new TimeSpan(0, 0, 1, 30) };
        const int expected = 1;

        // Act
        var actual = score.CompareTo(anotherScore);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CompareTo_ShouldReturn1_WhenObjectHasEqualMovesAndLessTimer()
    {
        // Arrange
        var score = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        var anotherScore = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 0, 45) };
        const int expected = 1;

        // Act
        var actual = score.CompareTo(anotherScore);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}
