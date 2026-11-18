namespace Puzzle15.Wpf.Mvvm.ViewModels;

// Одна строка таблицы рекордов в том виде, в котором ее показывает окно
public record BestScoreRowViewModel(int Place, string Name, string Moves, string Timer);
