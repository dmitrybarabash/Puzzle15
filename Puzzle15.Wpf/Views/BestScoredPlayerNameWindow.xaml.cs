using System.Windows;

namespace Puzzle15.Wpf.Views
{
    /// <summary>
    /// Interaction logic for BestScoredPlayerNameWindow.xaml
    /// </summary>
    public partial class BestScoredPlayerNameWindow : Window
    {
        public string PlayerName => textBoxName.Text.Trim();

        public BestScoredPlayerNameWindow()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void textBoxName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            buttonOk.IsEnabled = !string.IsNullOrEmpty(PlayerName);
        }
    }
}
