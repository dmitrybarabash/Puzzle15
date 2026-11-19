using System;
using Puzzle15.Common;

namespace Puzzle15.WinForms.Mvp.Views;

// IDisposable нужен, чтобы окно рекордов можно было освободить через using, не зная, что это форма
public interface IBestScoresView : IView, IDisposable
{
    // Показывает результат в строке таблицы с номером index, строки считаются с нуля
    void ShowScore(int index, string name, string moves, string time);
    void ShowModal();
}
