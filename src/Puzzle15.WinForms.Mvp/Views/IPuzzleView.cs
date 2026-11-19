using System;
using Puzzle15.Common;

namespace Puzzle15.WinForms.Mvp.Views;

public interface IPuzzleView : IView
{
    event EventHandler NewGame;
    event EventHandler Timer;
    event EventHandler<CellClickedEventArgs> CellClicked;
    event EventHandler BestScores;

    // Показывает на клетке (y, x) текст или прячет клетку
    void ShowCell(uint y, uint x, string text, bool visible);
    void SetFieldEnabled(bool enabled);

    void ShowElapsedTime(string time);
    void ShowMoves(string moves);
    void SetGameLabelsEnabled(bool enabled);

    void StartTimer();
    void StopTimer();

    void ShowWinMessage(string message);

    // Спрашивает имя игрока для таблицы рекордов. Возвращает null, если игрок отказался.
    string AskPlayerName();

    // Окно рекордов создает представление, а презентер к нему подключает PuzzlePresenter.
    // Поэтому презентер не знает, какое окно откроется, и в тестах его можно подменить заглушкой.
    IBestScoresView CreateBestScoresView();
}
