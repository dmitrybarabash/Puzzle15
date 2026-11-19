using System;
using System.Collections.Generic;
using Puzzle15.WinForms.Mvp.Views;

namespace Puzzle15.WinForms.Mvp.UnitTests.Fakes;

// Вместо окна рекордов запоминает, какие результаты и предупреждения презентер показал бы игроку
public class FakeBestScoresView : IBestScoresView
{
    public record Row(int Index, string Name, string Moves, string Time);

    public List<Row> Rows { get; } = [];
    public List<string> Warnings { get; } = [];
    public int ShowModalCount { get; private set; }
    public bool IsDisposed { get; private set; }

    #region IBestScoresView implementation

    public void ShowScore(int index, string name, string moves, string time) =>
        Rows.Add(new Row(index, name, moves, time));

    public void ShowWarning(string message) =>
        Warnings.Add(message);

    // Освобожденное окно показать уже нельзя, поэтому ошибку в порядке вызовов тест заметит
    public void ShowModal()
    {
        ObjectDisposedException.ThrowIf(IsDisposed, this);
        ShowModalCount++;
    }

    public void Dispose() =>
        IsDisposed = true;

    #endregion
}
