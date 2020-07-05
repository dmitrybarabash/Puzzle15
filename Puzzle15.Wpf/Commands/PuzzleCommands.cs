using System.Windows.Input;

namespace Puzzle15.Wpf.Commands
{
	public static class PuzzleCommands
	{
		public static readonly RoutedUICommand BestScores = new RoutedUICommand("_Лучшие результаты",
			"BestScores", typeof(PuzzleCommands));

		public static readonly RoutedUICommand Exit = new RoutedUICommand("_Выход", "Exit",
			typeof(PuzzleCommands), new InputGestureCollection() { new KeyGesture(Key.X, ModifierKeys.Alt) });

		public static readonly RoutedUICommand NewGame = new RoutedUICommand("_Новая игра", "NewGame",
			typeof(PuzzleCommands), new InputGestureCollection() { new KeyGesture(Key.N, ModifierKeys.Control) });

		public static readonly RoutedUICommand About = new RoutedUICommand("О _программе...", "About",
			typeof(PuzzleCommands));
	}
}
