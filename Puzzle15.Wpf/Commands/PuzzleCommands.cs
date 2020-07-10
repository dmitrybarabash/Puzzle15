﻿using System;
using System.Windows.Input;

namespace Puzzle15.Wpf.Commands
{
	//
	// Для своих команд ради переопределения метода ToString() делаем свой потомок RoutedUICommand
	//
	public class PuzzleRoutedUICommand : RoutedUICommand
    {
		// Определяем такие же конструкторы, что и в базовом классе RoutedUICommand,
		// чтобы можно было пользоваться нашим классом точно так же, как и базовым
		public PuzzleRoutedUICommand(string text, string name, Type ownerType)
			: base(text, name, ownerType) { }
		public PuzzleRoutedUICommand(string text, string name, Type ownerType, InputGestureCollection inputGestures)
			: base(text, name, ownerType, inputGestures) { }

		// Собственно, то, ради чего делаем этот класс. Если этого не сделать, то по умолчанию ToString()
		// будет возвращать полное имя класса, а нам нужно, чтобы он возвращал текст команды.
		public override string ToString() => Text.Remove(Text.IndexOf('_'), 1);
    }

	//
	// Статический класс с собственными командами
	//
	public static class PuzzleCommands
	{
		public static readonly RoutedUICommand BestScores = new PuzzleRoutedUICommand("_Лучшие результаты",
			"BestScores", typeof(PuzzleCommands));

		public static readonly RoutedUICommand Exit = new PuzzleRoutedUICommand("_Выход", "Exit",
			typeof(PuzzleCommands), new InputGestureCollection { new KeyGesture(Key.X, ModifierKeys.Alt) });

		public static readonly RoutedUICommand NewGame = new PuzzleRoutedUICommand("_Новая игра", "NewGame",
			typeof(PuzzleCommands), new InputGestureCollection { new KeyGesture(Key.N, ModifierKeys.Control) });

		public static readonly RoutedUICommand About = new PuzzleRoutedUICommand("О _программе...", "About",
			typeof(PuzzleCommands));
	}
}
