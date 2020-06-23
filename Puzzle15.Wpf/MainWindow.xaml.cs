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

        private void BestScores_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            // Свойство Owner для модального диалога необходимо установить для того, чтобы диалог
            // действительно стал модальным относительно родительского окна и не был виден по Alt+Tab
            new AboutWindow { Owner = this }.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
