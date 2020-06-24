using System.Windows;

namespace Puzzle15.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CellButton_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void BestScoresCommand_Executed(object sender, RoutedEventArgs e)
        {
            //
        }

        private void NewGameCommand_Executed(object sender, RoutedEventArgs e)
        {
            //
        }

        private void AboutCommand_Executed(object sender, RoutedEventArgs e)
        {
            // Свойство Owner для модального диалога необходимо установить для того, чтобы диалог
            // действительно стал модальным относительно родительского окна и не был виден по Alt+Tab
            new AboutWindow { Owner = this }.ShowDialog();
        }

        private void ExitCommand_Executed(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
