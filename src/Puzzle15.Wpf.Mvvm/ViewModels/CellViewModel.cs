using Puzzle15.Common;
using Puzzle15.Common.DomainModel;

namespace Puzzle15.Wpf.Mvvm.ViewModels;

// Одна клетка поля. Ее положение не меняется, а число на ней каждый раз берется из модели.
public class CellViewModel : BaseViewModel
{
    private IPuzzle Puzzle { get; }


    public CellViewModel(IPuzzle puzzle, uint y, uint x)
    {
        Puzzle = puzzle;
        Y = y;
        X = x;
    }


    public uint Y { get; }
    public uint X { get; }

    // Сообщает представлению, что число на клетке могло измениться
    public void Refresh()
    {
        OnPropertyChanged(nameof(Value));
        OnPropertyChanged(nameof(IsEmpty));
    }


    #region Binding properties (свойства привязки)

    // Свойство привязки содержимого кнопки
    public uint Value => Puzzle[Y, X];

    // Свойство привязки видимости кнопки: кнопку пустой клетки представление прячет
    public bool IsEmpty => Value == Puzzle.EmptyCellValue;

    #endregion
}
