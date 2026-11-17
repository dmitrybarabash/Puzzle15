using System.Windows;
using System.Windows.Controls;
using Puzzle15.Common.DomainModel;

namespace Puzzle15.Wpf.Mvvm.Views;

public partial class BestScoredPlayerNameWindow : Window
{
    public string PlayerName => textBoxPlayerName.Text.Trim();

    public BestScoredPlayerNameWindow()
    {
        InitializeComponent();
        textBoxPlayerName.MaxLength = Score.MaxNameLength;
    }

    private void ButtonOk_Click(object sender, RoutedEventArgs e) =>
        DialogResult = true;

    private void ButtonCancel_Click(object sender, RoutedEventArgs e) =>
        DialogResult = false;

    private void textBoxPlayerName_TextChanged(object sender, TextChangedEventArgs e) =>
        buttonOk.IsEnabled = !string.IsNullOrEmpty(PlayerName);
}
