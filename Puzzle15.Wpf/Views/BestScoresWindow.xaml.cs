﻿using System.Windows;

namespace Puzzle15.Wpf.Views
{
    /// <summary>
    /// Interaction logic for BestScoresWindow.xaml
    /// </summary>
    public partial class BestScoresWindow : Window
    {
        public BestScoresWindow()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
