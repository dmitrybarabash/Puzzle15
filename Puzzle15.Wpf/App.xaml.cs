using System.Threading.Tasks;
using System.Windows;
using Puzzle15.DomainModel;
using Puzzle15.Wpf.Views;

namespace Puzzle15.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //
        // Splash Screen Implementation
        //
        // https://wpf.programmingpedia.net/en/tutorial/3948/creating-splash-screen-in-wpf
        //
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Создаем окно splash screen, временно делаем его главным
            // окном приложения и показываем его пользователю
            var splashScreen = new SplashScreenWindow();
            MainWindow = splashScreen;
            splashScreen.Show();

            // Чтобы UI оставался отзывчивым, асинхронно делаем паузу
            // и потом переходим к показу настоящего главного окна
            Task.Factory.StartNew(() =>
            {
                // Делаем паузу
                System.Threading.Thread.Sleep(5000);

                // Создаем настоящее главное окно типа MainWindow, делаем его главным окном
                // приложения и показываем его пользователю. Поскольку мы сейчас вне основного
                // UI-потока, то обращение к тому, что имеет отношение UI-потоку, должно быть
                // вызвано потокобезопасно. В WPF это делается при помощи методов Invoke или
                // BeginInvoke объекта Dispatcher, который как раз и дает доступ к UI-потоку.
                Dispatcher.Invoke(() =>
                {
                    // Создаем настоящее главное окно типа MainWindow, делаем его
                    // главным окном приложения и показываем его пользователю
                    var mainWindow = new MainWindow(new PuzzleDomainModel());
                    MainWindow = mainWindow;
                    mainWindow.Show();

                    // Закрываем splash screen
                    splashScreen.Close();
                });
            });
        }
    }
}
