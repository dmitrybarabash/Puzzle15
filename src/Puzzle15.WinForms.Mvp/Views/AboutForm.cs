using System.Diagnostics;
using System.Windows.Forms;

namespace Puzzle15.WinForms.Mvp.Views
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void linkLabelWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Открываем веб-ссылку. Вместо простого Process.Start("...")
            // используем workaround из-за вот этого бага в .NET Core:
            // https://github.com/dotnet/corefx/issues/10361.
            Process.Start(new ProcessStartInfo
            {
                FileName = linkLabelWebsite.Text,
                UseShellExecute = true
            });
        }

        private void linkLabelEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Открываем почтовую ссылку. Вместо простого Process.Start("...")
            // используем workaround из-за вот этого бага в .NET Core:
            // https://github.com/dotnet/corefx/issues/10361.
            Process.Start(new ProcessStartInfo
            {
                FileName = $"mailto:{linkLabelEmail.Text}",
                UseShellExecute = true
            });
        }
    }
}
