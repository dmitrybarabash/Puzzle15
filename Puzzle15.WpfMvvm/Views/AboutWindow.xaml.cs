using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

namespace Puzzle15.Wpf.Views
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // Открываем URL. Вместо простого Process.Start(url)
            // используем workaround из-за вот этого бага в .NET Core:
            // https://github.com/dotnet/corefx/issues/10361.
            Process.Start(new ProcessStartInfo
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true
            });
            e.Handled = true;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
