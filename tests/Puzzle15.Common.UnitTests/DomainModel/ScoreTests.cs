using System;
using NUnit.Framework;
using Puzzle15.Common.DomainModel;

namespace Puzzle15.Common.UnitTests.DomainModel;

[TestFixture]
public class ScoreTests
{
    // != всегда возвращает противоположное ==
    [TestCase(100U, 100U, true)]   // Равные результаты
    [TestCase(100U, 200U, false)]  // Разные результаты
    [TestCase(null, 100U, false)]  // Слева null
    [TestCase(100U, null, false)]  // Справа null
    [TestCase(null, null, true)]   // С обеих сторон null
    public void EqualityOperators_ShouldReturnExpectedResult_WhenOperandsGiven(uint? moves, uint? anotherMoves, bool areEqual)
    {
        // Arrange
        var score = CreateScoreOrNull("Dmitrik", moves);
        var anotherScore = CreateScoreOrNull("Dmitrik", anotherMoves);

        // Act & Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(score == anotherScore, Is.EqualTo(areEqual), "==");
            Assert.That(score != anotherScore, Is.EqualTo(!areEqual), "!=");
        }
    }

    [TestCase("Aaaaaaaaaa", 100U, 90)]  // Другое имя
    [TestCase("Dmitrik", 200U, 90)]     // Другие ходы
    [TestCase("Dmitrik", 100U, 180)]    // Другое время
    public void Equals_ShouldReturnFalse_WhenAnyFieldDiffers(string anotherName, uint anotherMoves, int anotherSeconds)
    {
        // Arrange
        var score = CreateScore("Dmitrik", 100, 90);
        var anotherScore = CreateScore(anotherName, anotherMoves, anotherSeconds);

        // Act
        bool actual = score.Equals(anotherScore);

        // Assert
        Assert.That(actual, Is.False);
    }

    [TestCase("Dmitrik", "Dmitrik", ExpectedResult = true)]
    // «Å» одним символом и «A» с отдельным знаком кружка выглядят одинаково,
    // но это разные строки, а сравнение с учётом культуры считает их равными
    [TestCase("Åke", "Åke", ExpectedResult = false)]
    // Name по умолчанию null: например, у результата, которому ещё не дали имя игрока
    [TestCase(null, null, ExpectedResult = true)]
    [TestCase(null, "Dmitrik", ExpectedResult = false)]
    [TestCase("Dmitrik", null, ExpectedResult = false)]
    public bool Equals_ShouldCompareNamesOrdinally_WhenOtherFieldsAreEqual(string name, string anotherName)
    {
        // Arrange
        var score = CreateScore(name, 100, 90);
        var anotherScore = CreateScore(anotherName, 100, 90);

        // Act
        return score.Equals(anotherScore);
    }

    [Test]
    public void Equals_ShouldReturnTrue_WhenEqualScoreIsPassedAsObject()
    {
        // Arrange
        var score = CreateScore("Dmitrik", 100, 90);
        object anotherScore = CreateScore("Dmitrik", 100, 90);

        // Act
        bool actual = score.Equals(anotherScore);

        // Assert
        Assert.That(actual, Is.True);
    }

    [Test]
    public void Equals_ShouldReturnFalse_WhenObjectIsNotScore()
    {
        // Arrange
        var score = CreateScore("Dmitrik", 100, 90);
        object anotherObject = "Dmitrik";

        // Act
        bool actual = score.Equals(anotherObject);

        // Assert
        Assert.That(actual, Is.False);
    }

    [Test]
    public void Equals_ShouldReturnFalse_WhenOtherScoreIsOfDerivedType()
    {
        // Arrange
        var score = CreateScore("Dmitrik", 100, 90);
        var derivedScore = new DerivedScore { Name = "Dmitrik", Moves = 100, Timer = TimeSpan.FromSeconds(90) };

        // Act
        bool actual = score.Equals(derivedScore);
        bool actualReversed = derivedScore.Equals(score);

        // Assert
        // Результаты разных типов не равны, причём в обе стороны одинаково
        using (Assert.EnterMultipleScope())
        {
            Assert.That(actual, Is.False);
            Assert.That(actualReversed, Is.False);
        }
    }

    [Test]
    public void GetHashCode_ShouldReturnSameValue_WhenObjectsAreEqual()
    {
        // Arrange
        var score = CreateScore("Dmitrik", 100, 90);
        var anotherScore = CreateScore("Dmitrik", 100, 90);

        // Act
        int hashCode = score.GetHashCode();
        int anotherHashCode = anotherScore.GetHashCode();

        // Assert
        Assert.That(hashCode, Is.EqualTo(anotherHashCode));
    }

    // Имена у результатов разные: CompareTo их не учитывает, место в таблице рекордов зависит только от ходов и времени
    //        ходы время ходы время
    [TestCase(100U,  90, 100U,  90, ExpectedResult =  0)]  // Одинаковые ходы и время
    [TestCase(100U,  90, 200U,  90, ExpectedResult = -1)]  // Справа больше ходов
    [TestCase(100U,  90,  50U,  90, ExpectedResult =  1)]  // Справа меньше ходов
    [TestCase(100U,  90, 100U, 180, ExpectedResult = -1)]  // Ходы равны, справа больше времени
    [TestCase(100U,  90, 100U,  45, ExpectedResult =  1)]  // Ходы равны, справа меньше времени
    [TestCase(100U, 180, 200U,  90, ExpectedResult = -1)]  // Справа больше ходов, хотя меньше времени: ходы важнее
    [TestCase(200U,  90, 100U, 180, ExpectedResult =  1)]  // Справа меньше ходов, хотя больше времени: ходы важнее
    public int CompareTo_ShouldCompareMovesThenTimer_WhenOtherScoreGiven(uint moves, int seconds, uint anotherMoves, int anotherSeconds)
    {
        // Arrange
        var score = CreateScore("Dmitrik", moves, seconds);
        var anotherScore = CreateScore("Aaaaaaaaaa", anotherMoves, anotherSeconds);

        // Act
        return score.CompareTo(anotherScore);
    }

    [Test]
    public void CompareTo_ShouldReturn1_WhenObjectIsNull()
    {
        // Arrange
        var score = CreateScore("Dmitrik", 100, 90);

        // Act
        int actual = score.CompareTo(null);

        // Assert
        Assert.That(actual, Is.EqualTo(1));
    }

    // Как и CompareTo, операторы сравнения учитывают только ходы и время, а null меньше любого результата
    //        ходы  ходы  <      <=     >      >=
    [TestCase(100U, 200U, true,  true,  false, false)]  // Левый результат лучше
    [TestCase(100U, 100U, false, true,  false, true)]   // Одинаковые ходы и время, хотя имена разные
    [TestCase(200U, 100U, false, false, true,  true)]   // Левый результат хуже
    [TestCase(null, 100U, true,  true,  false, false)]  // Слева null
    [TestCase(100U, null, false, false, true,  true)]   // Справа null
    [TestCase(null, null, false, true,  false, true)]   // С обеих сторон null
    public void ComparisonOperators_ShouldReturnExpectedResult_WhenOperandsGiven(
        uint? moves, uint? anotherMoves, bool less, bool lessOrEqual, bool greater, bool greaterOrEqual)
    {
        // Arrange
        var score = CreateScoreOrNull("Dmitrik", moves);
        var anotherScore = CreateScoreOrNull("Aaaaaaaaaa", anotherMoves);

        // Act & Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(score < anotherScore, Is.EqualTo(less), "<");
            Assert.That(score <= anotherScore, Is.EqualTo(lessOrEqual), "<=");
            Assert.That(score > anotherScore, Is.EqualTo(greater), ">");
            Assert.That(score >= anotherScore, Is.EqualTo(greaterOrEqual), ">=");
        }
    }

    private static Score CreateScore(string name, uint moves, int seconds) =>
        new() { Name = name, Moves = moves, Timer = TimeSpan.FromSeconds(seconds) };

    // Если вместо ходов передан null, то и результата нет: так в TestCase можно передать пустой операнд
    private static Score CreateScoreOrNull(string name, uint? moves) =>
        moves is uint m ? CreateScore(name, m, 90) : null;

    // Наследник Score без новых полей
    public class DerivedScore : Score
    {
    }
}
