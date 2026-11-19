using System;
using NUnit.Framework;
using Puzzle15.Common.DomainModel;

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

    [TestCase( 0U, ExpectedResult = "0 ходов")]
    [TestCase( 1U, ExpectedResult = "1 ход")]
    [TestCase(92U, ExpectedResult = "92 хода")]
    public string FormatMoves_ShouldReturnNumberWithWord_WhenMovesGiven(uint moves)
    {
        return Utils.FormatMoves(moves);
    }

    [TestCase(  0,  0,  0,   0, ExpectedResult = "00:00:00")]
    [TestCase(  0,  0,  5,   0, ExpectedResult = "00:00:05")]
    [TestCase(  0,  1, 30,   0, ExpectedResult = "00:01:30")]
    [TestCase( 12, 34, 56,   0, ExpectedResult = "12:34:56")]
    [TestCase( 23, 59, 59,   0, ExpectedResult = "23:59:59")]
    // Доли секунды отбрасываются, а не округляются
    [TestCase(  0,  1, 29, 999, ExpectedResult = "00:01:29")]
    // Сутки не отбрасываются, а входят в часы
    [TestCase( 25,  0,  0,   0, ExpectedResult = "25:00:00")]
    [TestCase(100,  0,  0,   0, ExpectedResult = "100:00:00")]
    public string FormatElapsedTime_ShouldReturnHoursMinutesSeconds_WhenTimeGiven(
        int hours, int minutes, int seconds, int milliseconds)
    {
        return Utils.FormatElapsedTime(new TimeSpan(0, hours, minutes, seconds, milliseconds));
    }

    [Test]
    public void GetWinMessage_ShouldReturnMovesAndTime_WhenScoreGiven()
    {
        // Arrange
        var score = new Score { Moves = 92, Timer = new TimeSpan(0, 0, 11, 25) };

        // Act
        string actual = Utils.GetWinMessage(score);

        // Assert
        Assert.That(actual, Is.EqualTo("Вы выиграли!\n\nВы сделали 92 хода за 00:11:25!"));
    }

    [Test]
    public void GetLoadBestScoresErrorMessage_ShouldReturnMessageWithFileName_WhenFileNameGiven()
    {
        // Act
        string actual = Utils.GetLoadBestScoresErrorMessage(@"C:\Program Files\Puzzle15\Puzzle.dat");

        // Assert
        Assert.That(actual, Is.EqualTo("Не удалось прочитать таблицу рекордов.\n\nФайл: C:\\Program Files\\Puzzle15\\Puzzle.dat"));
    }

    [TestCase(AddBestScoreResult.LoadFailed,
        ExpectedResult = "Не удалось прочитать таблицу рекордов, поэтому результат в неё не записан.\n\nФайл: C:\\Program Files\\Puzzle15\\Puzzle.dat")]
    [TestCase(AddBestScoreResult.SaveFailed,
        ExpectedResult = "Не удалось сохранить таблицу рекордов, поэтому результат в неё не записан.\n\nФайл: C:\\Program Files\\Puzzle15\\Puzzle.dat")]
    public string GetAddBestScoreErrorMessage_ShouldReturnMessageWithFileName_WhenStorageFailed(AddBestScoreResult result)
    {
        return Utils.GetAddBestScoreErrorMessage(result, @"C:\Program Files\Puzzle15\Puzzle.dat");
    }

    // Ни один из этих исходов не ошибка, поэтому предупреждать игрока не о чем
    [TestCase(AddBestScoreResult.Added)]
    [TestCase(AddBestScoreResult.NotBestScore)]
    [TestCase(AddBestScoreResult.PlayerDeclined)]
    public void GetAddBestScoreErrorMessage_ShouldReturnNull_WhenThereIsNothingToReport(AddBestScoreResult result)
    {
        // Act
        string actual = Utils.GetAddBestScoreErrorMessage(result, @"C:\Program Files\Puzzle15\Puzzle.dat");

        // Assert
        Assert.That(actual, Is.Null);
    }
}
