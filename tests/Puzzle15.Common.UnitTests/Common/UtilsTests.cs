using NUnit.Framework;

namespace Puzzle15.Common.UnitTests.Common;

[TestFixture]
public class UtilsTests
{
    [TestCase(   0U, ExpectedResult = "ходов")]
    [TestCase(   1U, ExpectedResult = "ход")]
    [TestCase(   2U, ExpectedResult = "хода")]
    [TestCase(   3U, ExpectedResult = "хода")]
    [TestCase(   4U, ExpectedResult = "хода")]
    [TestCase(   5U, ExpectedResult = "ходов")]
    [TestCase(   6U, ExpectedResult = "ходов")]
    [TestCase(   7U, ExpectedResult = "ходов")]
    [TestCase(   8U, ExpectedResult = "ходов")]
    [TestCase(   9U, ExpectedResult = "ходов")]
    [TestCase(  10U, ExpectedResult = "ходов")]
    // От 11 до 14 — «ходов», хотя последняя цифра от 1 до 4
    [TestCase(  11U, ExpectedResult = "ходов")]
    [TestCase(  12U, ExpectedResult = "ходов")]
    [TestCase(  13U, ExpectedResult = "ходов")]
    [TestCase(  14U, ExpectedResult = "ходов")]
    [TestCase(  15U, ExpectedResult = "ходов")]
    [TestCase(  20U, ExpectedResult = "ходов")]
    [TestCase(  21U, ExpectedResult = "ход")]
    [TestCase(  22U, ExpectedResult = "хода")]
    [TestCase(  23U, ExpectedResult = "хода")]
    [TestCase(  24U, ExpectedResult = "хода")]
    [TestCase(  25U, ExpectedResult = "ходов")]
    // Начиная с сотни, решают только две последние цифры
    [TestCase( 100U, ExpectedResult = "ходов")]
    [TestCase( 101U, ExpectedResult = "ход")]
    [TestCase( 102U, ExpectedResult = "хода")]
    [TestCase( 105U, ExpectedResult = "ходов")]
    [TestCase( 111U, ExpectedResult = "ходов")]
    [TestCase( 112U, ExpectedResult = "ходов")]
    [TestCase( 114U, ExpectedResult = "ходов")]
    [TestCase( 121U, ExpectedResult = "ход")]
    [TestCase(1011U, ExpectedResult = "ходов")]
    [TestCase(uint.MaxValue, ExpectedResult = "ходов")]  // 4294967295
    public string GetMovesWord_ShouldReturnWord_WhenMovesGiven(uint moves)
    {
        return Utils.GetMovesWord(moves);
    }
}
