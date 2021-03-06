﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Puzzle15.Common;
using Puzzle15.DomainModel;

namespace Puzzle15.Wpf.NoMvvm.Views
{
    public partial class PuzzleWindow : Window
    {
        private IPuzzleDomainModel Model { get; }
        private DispatcherTimer TimerGame { get; }

        public PuzzleWindow(IPuzzleDomainModel model)
        {
            InitializeComponent();

            Model = model;

            TimerGame = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            TimerGame.Tick += (s, e) => textBlockTimer.Text = (DateTime.Now - Model.Puzzle.StartTime).ToString(@"hh\:mm\:ss");
        }

        private void CellButton_Click(object sender, RoutedEventArgs e)
        {
            uint clickedNumber = uint.Parse((sender as Button).Name.Remove(0, 10));
            uint y = (clickedNumber - 1) / Model.Puzzle.FieldSideSize;
            uint x = (clickedNumber - 1) % Model.Puzzle.FieldSideSize;
            if (Model.Puzzle.IsMoveable(y, x))
            {
                Model.Puzzle.Move(y, x);
                UpdateButtons(true);
                textBlockMoves.Text = Model.Puzzle.MovesCounter.ToString();

                if (Model.Puzzle.IsDone())
                {
                    StopTimer();
                    var score = new Score
                    {
                        Moves = Model.Puzzle.MovesCounter,
                        Timer = DateTime.Now - Model.Puzzle.StartTime
                    };

                    MessageBox.Show(
                        $"Вы выиграли!\n\nВы сделали {Model.Puzzle.MovesCounter} {Utils.GetMovesWord(Model.Puzzle.MovesCounter)} за {textBlockTimer.Text}!",
                        "Молодец!", MessageBoxButton.OK, MessageBoxImage.Information);

                    try
                    {
                        Model.BestScoresStorage.Load(Model.BestScores);
                        if (Model.BestScores.CanBeAdded(score))
                        {
                            var bestScoredPlayerNameWindow = new BestScoredPlayerNameWindow { Owner = this };
                            if (bestScoredPlayerNameWindow.ShowDialog() == true)
                            {
                                score.Name = bestScoredPlayerNameWindow.PlayerName;
                                Model.BestScores.Add(score);
                                Model.BestScoresStorage.Save(Model.BestScores);
                            }
                        }
                    }
                    catch
                    {
                        // Ничего не делаем, пользователю ничего не говорим.
                        // Не получилось прочитать/записать файл с рекордами — ок, просто пропускаем эту часть.
                    }

                    Model.Puzzle.Init();
                    UpdateButtons(false);
                    StopTimer();
                    UpdateGameLabels(false);
                }
            }
        }

        private void UpdateButtons(bool active)
        {
            //
            // Подробный вариант
            //
            // Получаем все дочерние контролы сетки в виде коллекции UIElementCollection
            //UIElementCollection elementCollection = cellButtonsGrid.Children;
            // Преобразуем полученную коллекцию в List<FrameworkElement>
            //List<FrameworkElement> elementList = elementCollection.Cast<FrameworkElement>().ToList();
            // Выделяем из этого списка всех контролов только кнопки
            //IEnumerable<Button> buttonList = elementList.OfType<Button>();

            //
            // Этот же вариант покороче
            //
            var buttonList = cellButtonsGrid.Children.Cast<FrameworkElement>().ToList().OfType<Button>();

            foreach (Button button in buttonList)
            {
                button.IsEnabled = active;
                uint number = uint.Parse(button.Name.Remove(0, 10));
                uint cellValue = Model.Puzzle[(number - 1) / Model.Puzzle.FieldSideSize, (number - 1) % Model.Puzzle.FieldSideSize];
                button.Content = cellValue.ToString();
                button.Visibility = cellValue != Model.Puzzle.EmptyCellValue ? Visibility.Visible : Visibility.Hidden;
            }
        }

        private void StartTimer() =>
            TimerGame.Start();

        private void StopTimer() =>
            TimerGame.Stop();

        private void UpdateGameLabels(bool active)
        {
            textBlockTimer.Text = "00:00:00";
            textBlockTimer.IsEnabled = active;
            textBlockMoves.Text = "0";
            textBlockMoves.IsEnabled = active;
        }

        private void NewGameCommand_Executed(object sender, RoutedEventArgs e)
        {
            Model.Puzzle.Start();
            UpdateButtons(true);
            StartTimer();
            UpdateGameLabels(true);
        }

        private void BestScoresCommand_Executed(object sender, RoutedEventArgs e) =>
            new BestScoresWindow(Model) { Owner = this }.ShowDialog();

        private void AboutCommand_Executed(object sender, RoutedEventArgs e) =>
            new AboutWindow { Owner = this }.ShowDialog();

        private void ExitCommand_Executed(object sender, RoutedEventArgs e) =>
            Application.Current.Shutdown();
    }
}
