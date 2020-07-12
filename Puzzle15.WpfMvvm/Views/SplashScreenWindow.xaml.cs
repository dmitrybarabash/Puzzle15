using System;
using System.Windows;
using System.Windows.Threading;

namespace Puzzle15.Wpf.Views
{
    public partial class SplashScreenWindow : Window
    {
        public SplashScreenWindow()
        {
            InitializeComponent();

            // Используем специальный DispatcherTimer для WPF
            var opacityTimer = new DispatcherTimer();
            opacityTimer.Tick += (sender, args) =>
            {
                if ((int)(Opacity += 0.005d) == 1)
                    opacityTimer.Stop();
            };
            opacityTimer.Interval = TimeSpan.FromMilliseconds(1);
            opacityTimer.Start();
        }
    }
}
