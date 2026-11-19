using System;
using System.Collections.Generic;
using Puzzle15.WinForms.Mvp.Views;

namespace Puzzle15.WinForms.Mvp.UnitTests.Fakes;

// Вместо главного окна запоминает, что презентер показал бы игроку, и умеет изображать действия игрока
public class FakePuzzleView : IPuzzleView
{
    // Что игрок видит на клетках поля: текст кнопки или null, если кнопка спрятана
    public string[,] Cells { get; } = new string[4, 4];

    public bool IsFieldEnabled { get; private set; }
    public string ElapsedTime { get; private set; }
    public string Moves { get; private set; }
    public bool AreGameLabelsEnabled { get; private set; }
    public bool IsTimerRunning { get; private set; }
    public List<string> WinMessages { get; } = [];

    // Имя, которое «введет» игрок, или null, если он откажется
    public string PlayerName { get; set; }

    public int AskPlayerNameCount { get; private set; }

    // Окно рекордов, которое представление отдаст презентеру
    public FakeBestScoresView BestScoresView { get; } = new();

    public void ClickNewGame() =>
        NewGame?.Invoke(this, EventArgs.Empty);

    public void ClickCell(uint y, uint x) =>
        CellClicked?.Invoke(this, new CellClickedEventArgs(y, x));

    public void TickTimer() =>
        Timer?.Invoke(this, EventArgs.Empty);

    public void ClickBestScores() =>
        BestScores?.Invoke(this, EventArgs.Empty);

    #region IPuzzleView implementation

    public event EventHandler NewGame;
    public event EventHandler Timer;
    public event EventHandler<CellClickedEventArgs> CellClicked;
    public event EventHandler BestScores;

    public void ShowCell(uint y, uint x, string text, bool visible) =>
        Cells[y, x] = visible ? text : null;

    public void SetFieldEnabled(bool enabled) =>
        IsFieldEnabled = enabled;

    public void ShowElapsedTime(string time) =>
        ElapsedTime = time;

    public void ShowMoves(string moves) =>
        Moves = moves;

    public void SetGameLabelsEnabled(bool enabled) =>
        AreGameLabelsEnabled = enabled;

    public void StartTimer() =>
        IsTimerRunning = true;

    public void StopTimer() =>
        IsTimerRunning = false;

    public void ShowWinMessage(string message) =>
        WinMessages.Add(message);

    public string AskPlayerName()
    {
        AskPlayerNameCount++;
        return PlayerName;
    }

    public IBestScoresView CreateBestScoresView() =>
        BestScoresView;

    #endregion
}
