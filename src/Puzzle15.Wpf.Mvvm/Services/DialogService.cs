using System.Windows;
using Puzzle15.Common;
using Puzzle15.Common.DomainModel;
using Puzzle15.Wpf.Mvvm.Views;

namespace Puzzle15.Wpf.Mvvm.Services;

public class DialogService : IDialogService
{
    #region IDialogService implementation

    public void ShowWinMessage(Score score) =>
        MessageBox.Show(Utils.GetWinMessage(score), "Молодец!", MessageBoxButton.OK, MessageBoxImage.Information);

    public string AskPlayerName()
    {
        var bestScoredPlayerNameWindow = new BestScoredPlayerNameWindow { Owner = Application.Current.MainWindow };
        return bestScoredPlayerNameWindow.ShowDialog() == true ? bestScoredPlayerNameWindow.PlayerName : null;
    }

    #endregion
}
