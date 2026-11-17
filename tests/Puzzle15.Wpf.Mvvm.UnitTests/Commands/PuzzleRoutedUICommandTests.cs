using NUnit.Framework;
using Puzzle15.Wpf.Mvvm.Commands;

namespace Puzzle15.Wpf.Mvvm.UnitTests.Commands;

[TestFixture]
public class PuzzleRoutedUICommandTests
{
    [TestCase("_Новая игра", ExpectedResult = "Новая игра")]
    [TestCase("О _программе...", ExpectedResult = "О программе...")]
    [TestCase("Выход", ExpectedResult = "Выход")]
    public string ToString_ShouldReturnTextWithoutUnderscore_WhenTextGiven(string text)
    {
        return new PuzzleRoutedUICommand(text, "Test", typeof(PuzzleRoutedUICommandTests)).ToString();
    }
}
