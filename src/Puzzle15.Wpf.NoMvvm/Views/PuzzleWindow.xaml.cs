using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Puzzle15.Common;
using Puzzle15.Common.DomainModel;

namespace Puzzle15.Wpf.NoMvvm.Views;

public partial class PuzzleWindow : Window
{
    private IPuzzleDomainModel Model { get; }
    private DispatcherTimer TimerGame { get; }

    public PuzzleWindow(IPuzzleDomainModel model)
    {
        InitializeComponent();

        Model = model;

        // DispatcherTimer отсчитывает следующий тик от конца предыдущего, поэтому отставание копится.
        // При интервале в 1 с таймер из-за этого иногда перескакивает через секунду, а при 200 мс — нет.
        TimerGame = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(200) };
        TimerGame.Tick += (s, e) => textBlockTimer.Text = Utils.FormatElapsedTime(Model.Puzzle.ElapsedTime);
    }

    private void CellButton_Click(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        uint y = (uint)Grid.GetRow(button);
        uint x = (uint)Grid.GetColumn(button);
        if (Model.TryMove(y, x, out Score finishedGameScore))
        {
            UpdateButtons(true);
            textBlockMoves.Text = Model.Puzzle.MovesCounter.ToString();

            if (finishedGameScore is not null)
            {
                StopTimer();
                textBlockTimer.Text = Utils.FormatElapsedTime(finishedGameScore.Timer);

                MessageBox.Show(Utils.GetWinMessage(finishedGameScore),
                    "Молодец!", MessageBoxButton.OK, MessageBoxImage.Information);

                AddBestScoreResult result = Model.AddBestScore(finishedGameScore, () =>
                {
                    var bestScoredPlayerNameWindow = new BestScoredPlayerNameWindow { Owner = this };
                    return bestScoredPlayerNameWindow.ShowDialog() == true ? bestScoredPlayerNameWindow.PlayerName : null;
                });
                string errorMessage = Utils.GetAddBestScoreErrorMessage(result, Model.BestScoresStorage.FileName);
                if (errorMessage is not null)
                    MessageBox.Show(errorMessage, "Пятнашки", MessageBoxButton.OK, MessageBoxImage.Warning);

                Model.Puzzle.Init();
                UpdateButtons(false);
                UpdateGameLabels(false);
            }
        }
    }

    private void UpdateButtons(bool active)
    {
        // Из всех дочерних контролов сетки получаем все кнопки
        var buttonList = cellButtonsGrid.Children.OfType<Button>();

        foreach (Button button in buttonList)
        {
            uint cellValue = Model.Puzzle[(uint)Grid.GetRow(button), (uint)Grid.GetColumn(button)];
            button.IsEnabled = active;
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
        textBlockTimer.Text = Utils.FormatElapsedTime(TimeSpan.Zero);
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
