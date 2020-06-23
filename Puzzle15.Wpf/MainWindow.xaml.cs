using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void ButtonNewGame_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void ButtonAbout_Click(object sender, RoutedEventArgs e)
        {
            // Свойство Owner для модального диалога необходимо установить для того, чтобы диалог
            // действительно стал модальным относительно родительского окна и не был виден по Alt+Tab
            new AboutWindow { Owner = this }.ShowDialog();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
