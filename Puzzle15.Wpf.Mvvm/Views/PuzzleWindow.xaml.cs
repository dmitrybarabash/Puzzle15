using Puzzle15.Wpf.Mvvm.ViewModels;
using System.Windows;

namespace Puzzle15.Wpf.Mvvm.Views
{
    public partial class PuzzleWindow : Window
    {
        public PuzzleWindow()
        {
            InitializeComponent();
        }

        private void NewGameCommand_Executed(object sender, RoutedEventArgs e)
        {
            (DataContext as PuzzleViewModel).NewGameCommand.Execute(null);
        }

        private void BestScoresCommand_Executed(object sender, RoutedEventArgs e)
        {
            new BestScoresWindow() { Owner = this, DataContext = new BestScoresViewModel() }.ShowDialog();
        }

        private void AboutCommand_Executed(object sender, RoutedEventArgs e)
        {
            new AboutWindow { Owner = this }.ShowDialog();
        }

        private void ExitCommand_Executed(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
