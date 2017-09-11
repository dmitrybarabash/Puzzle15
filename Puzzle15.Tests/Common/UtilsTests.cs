using NUnit.Framework;
using Puzzle15.Common;

namespace Puzzle15.Tests.Common
{
    [TestFixture]
    class UtilsTests
    {
        [TestCase( 1U, "ход", Result = true)]
        [TestCase( 2U, "хода", Result = true)]
        [TestCase( 3U, "хода", Result = true)]
        [TestCase( 4U, "хода", Result = true)]
        [TestCase( 5U, "ходов", Result = true)]
        [TestCase( 6U, "ходов", Result = true)]
        [TestCase( 7U, "ходов", Result = true)]
        [TestCase( 8U, "ходов", Result = true)]
        [TestCase( 9U, "ходов", Result = true)]
        [TestCase(10U, "ходов", Result = true)]
        [TestCase(14U, "ходов", Result = true)]
        [TestCase(15U, "ходов", Result = true)]
        [TestCase(20U, "ходов", Result = true)]
        [TestCase(21U, "ход", Result = true)]
        [TestCase(22U, "хода", Result = true)]
        [TestCase(23U, "хода", Result = true)]
        [TestCase(24U, "хода", Result = true)]
        [TestCase(25U, "ходов", Result = true)]
        public bool GetMovesWord_Moves_ReturnsWord(uint moves, string result)
        {
            return Utils.GetMovesWord(moves) == result;
        }
    }
}
