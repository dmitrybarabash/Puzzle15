using Puzzle15.Common;
using Puzzle15.Common.DomainModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Puzzle15.Wpf.NoMvvm.Views;

public partial class BestScoresWindow : Window
{
    private const int NameColumn = 1;
    private const int MovesColumn = 2;
    private const int TimerColumn = 3;

    private IPuzzleDomainModel Model { get; }

    public BestScoresWindow(IPuzzleDomainModel model)
    {
        InitializeComponent();

        Model = model;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        //
        // Загружаем лучшие результаты из файла
        //
        if (!Model.TryLoadBestScores())
        {
            // Окно рекордов уже на экране, поэтому делаем его владельцем, чтобы сообщение появилось поверх него
            MessageBox.Show(this, Utils.GetLoadBestScoresErrorMessage(Model.BestScoresStorage.FileName),
                "Пятнашки", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        //
        // Раскладываем их по TextBlock'ам в сетке
        //

        // Из всех дочерних контролов сетки получаем все TextBlock'и
        var textBlockList = gridBestScores.Children.OfType<TextBlock>();

        foreach (TextBlock textBlock in textBlockList)
        {
            int row = Grid.GetRow(textBlock);
            if (row >= Model.BestScores.Count)
                continue;

            Score score = Model.BestScores[row];
            switch (Grid.GetColumn(textBlock))
            {
                case NameColumn:
                    textBlock.Text = score.Name;
                    break;
                case MovesColumn:
                    textBlock.Text = Utils.FormatMoves(score.Moves);
                    break;
                case TimerColumn:
                    textBlock.Text = Utils.FormatElapsedTime(score.Timer);
                    break;
            }
        }
    }
}
