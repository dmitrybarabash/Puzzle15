using Puzzle15.Wpf.Mvvm.ViewModels;
using System.Windows;

namespace Puzzle15.Wpf.Mvvm.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewGameCommand_Executed(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWindowViewModel).NewGameCommand.Execute(null);
        }

        private void BestScoresCommand_Executed(object sender, RoutedEventArgs e)
        {
            new BestScoresWindow() { Owner = this }.ShowDialog();
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
