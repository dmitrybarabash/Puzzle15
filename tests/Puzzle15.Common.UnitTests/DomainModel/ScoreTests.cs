using System;
using NUnit.Framework;
using Puzzle15.DomainModel;

namespace Puzzle15.UnitTests.DomainModel;

[TestFixture]
class ScoreTests
{
    [Test]
    public void EqualOperator_EqualOperands_ReturnsTrue()
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
    public void EqualOperator_LeftOperandIsNull_ReturnsFalse()
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
    public void EqualOperator_RightOperandIsNull_ReturnsFalse()
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
    public void EqualOperator_BothOperandsAreNull_ReturnsTrue()
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
    public void EqualOperator_BothOperandsReferToTheSameObject_ReturnsTrue()
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
    public void EqualOperator_NotEqualOperandsWithGreaterMoves_ReturnsFalse()
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
    public void EqualOperator_NotEqualOperandsWithLessMoves_ReturnsFalse()
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
    public void EqualOperator_NotEqualOperandsWithGreaterTimer_ReturnsFalse()
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
    public void EqualOperator_NotEqualOperandsWithLessTimer_ReturnsFalse()
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
    public void CompareTo_EqualObject_Returns0()
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
    public void CompareTo_ObjectWithGreaterMoves_ReturnsMinus1()
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
    public void CompareTo_ObjectWithEqualMovesAndGreaterTimer_ReturnsMinus1()
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
    public void CompareTo_ObjectWithLessMoves_Returns1()
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
    public void CompareTo_ObjectWithEqualMovesAndLessTimer_Returns1()
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
