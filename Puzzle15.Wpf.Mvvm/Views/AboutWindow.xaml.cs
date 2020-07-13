using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

namespace Puzzle15.Wpf.Mvvm.Views
{
    public partial class AboutWindow : Window
    {
        public AboutWindow() =>
            InitializeComponent();

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // Открываем интернет-ссылку. Вместо простого Process.Start(e.Uri.AbsoluteUri)
            // используем workaround из-за вот этого бага в .NET Core:
            // https://github.com/dotnet/corefx/issues/10361.
            Process.Start(new ProcessStartInfo
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true
            });
            e.Handled = true;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e) =>
            Close();
    }
}
