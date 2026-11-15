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
    public void EqualOperator_ShouldReturnFalse_WhenRightOperandIsNull()
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
    public void EqualOperator_ShouldReturnFalse_WhenLeftOperandIsNull()
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
    public void Equals_ShouldReturnFalse_WhenNamesDiffer()
    {
        // Arrange
        var score = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        var anotherScore = new Score { Name = "Aaaaaaaaaa", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        const bool expected = false;

        // Act
        bool actual = score.Equals(anotherScore);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Equals_ShouldReturnFalse_WhenNamesDifferOnlyInCharacterComposition()
    {
        // Arrange
        // «Å» одним символом (U+00C5) и «A» с отдельным знаком кружка (U+030A) выглядят одинаково,
        // но это разные строки, а сравнение с учётом культуры считает их равными
        var score = new Score { Name = "Åke", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        var anotherScore = new Score { Name = "Åke", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        const bool expected = false;

        // Act
        bool actual = score.Equals(anotherScore);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Equals_ShouldReturnTrue_WhenEqualScoreIsPassedAsObject()
    {
        // Arrange
        var score = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        object anotherScore = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        const bool expected = true;

        // Act
        bool actual = score.Equals(anotherScore);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Equals_ShouldReturnFalse_WhenObjectIsNotScore()
    {
        // Arrange
        var score = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        object anotherObject = "Dmitrik";
        const bool expected = false;

        // Act
        bool actual = score.Equals(anotherObject);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GetHashCode_ShouldReturnSameValue_WhenObjectsAreEqual()
    {
        // Arrange
        var score = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        var anotherScore = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };

        // Act
        int hashCode = score.GetHashCode();
        int anotherHashCode = anotherScore.GetHashCode();

        // Assert
        Assert.That(hashCode, Is.EqualTo(anotherHashCode));
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

    [Test]
    public void CompareTo_ShouldReturn1_WhenObjectIsNull()
    {
        // Arrange
        var score = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        const int expected = 1;

        // Act
        var actual = score.CompareTo(null);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void LessOperator_ShouldReturnFalse_WhenRightOperandIsNull()
    {
        // Arrange
        var score = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        var anotherScore = (Score)null;
        const bool expected = false;

        // Act
        bool actual = score < anotherScore;

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void LessOrEqualOperator_ShouldReturnFalse_WhenRightOperandIsNull()
    {
        // Arrange
        var score = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        var anotherScore = (Score)null;
        const bool expected = false;

        // Act
        bool actual = score <= anotherScore;

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GreaterOperator_ShouldReturnTrue_WhenRightOperandIsNull()
    {
        // Arrange
        var score = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        var anotherScore = (Score)null;
        const bool expected = true;

        // Act
        bool actual = score > anotherScore;

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GreaterOrEqualOperator_ShouldReturnTrue_WhenRightOperandIsNull()
    {
        // Arrange
        var score = new Score { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
        var anotherScore = (Score)null;
        const bool expected = true;

        // Act
        bool actual = score >= anotherScore;

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}
