using System;
using System.Windows;
using System.Windows.Threading;

namespace Puzzle15.Wpf.Views
{
    /// <summary>
    /// Interaction logic for SplashScreenWindow.xaml
    /// </summary>
    public partial class SplashScreenWindow : Window
    {
        public SplashScreenWindow()
        {
            InitializeComponent();

            // Используем специальный DispatcherTimer для WPF
            var opacityTimer = new DispatcherTimer();
            opacityTimer.Tick += new EventHandler((sender, args) =>
            {
                if ((int)(Opacity += 0.005d) == 1)
                    opacityTimer.Stop();
            });
            opacityTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            opacityTimer.Start();
        }
    }
}
