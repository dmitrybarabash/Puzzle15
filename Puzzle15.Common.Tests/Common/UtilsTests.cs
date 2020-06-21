using NUnit.Framework;
using Puzzle15.Common;

namespace Puzzle15.Tests.Common
{
    [TestFixture]
    class UtilsTests
    {
        [TestCase( 1U, "ход", ExpectedResult = true)]
        [TestCase( 2U, "хода", ExpectedResult = true)]
        [TestCase( 3U, "хода", ExpectedResult = true)]
        [TestCase( 4U, "хода", ExpectedResult = true)]
        [TestCase( 5U, "ходов", ExpectedResult = true)]
        [TestCase( 6U, "ходов", ExpectedResult = true)]
        [TestCase( 7U, "ходов", ExpectedResult = true)]
        [TestCase( 8U, "ходов", ExpectedResult = true)]
        [TestCase( 9U, "ходов", ExpectedResult = true)]
        [TestCase(10U, "ходов", ExpectedResult = true)]
        [TestCase(14U, "ходов", ExpectedResult = true)]
        [TestCase(15U, "ходов", ExpectedResult = true)]
        [TestCase(20U, "ходов", ExpectedResult = true)]
        [TestCase(21U, "ход", ExpectedResult = true)]
        [TestCase(22U, "хода", ExpectedResult = true)]
        [TestCase(23U, "хода", ExpectedResult = true)]
        [TestCase(24U, "хода", ExpectedResult = true)]
        [TestCase(25U, "ходов", ExpectedResult = true)]
        public bool GetMovesWord_Moves_ReturnsWord(uint moves, string result)
        {
            return Utils.GetMovesWord(moves) == result;
        }
    }
}
