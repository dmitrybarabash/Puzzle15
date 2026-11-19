using System;

namespace Puzzle15.WinForms.Mvp.Views;

// Координаты клетки поля, которую нажал игрок
public class CellClickedEventArgs(uint y, uint x) : EventArgs
{
    public uint Y { get; } = y;
    public uint X { get; } = x;
}
