using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Puzzle15.Common.DomainModel;
using Puzzle15.Wpf.Mvvm.ViewModels;
using Puzzle15.Wpf.Mvvm.Views;

namespace Puzzle15.Wpf.Mvvm;

public partial class App : Application
{
    // Экземпляр модели нашего приложения
    public IPuzzleDomainModel Model { get; private set; }

    //
    // Переопределенный метод OnStartup выполняет здесь две задачи:
    //
    //    1. Splash Screen.
    //         Показывает splash screen, а только затем показывает главное окно приложения.
    //
    //    2. Является Application Root нашего приложения.
    //         Создает экземпляр модели — единственный на всё приложение.
    //
    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Необработанное исключение показываем пользователю и закрываем приложение.
        // Иначе ошибка при создании главного окна оставила бы на экране висящий splash screen.
        DispatcherUnhandledException += App_DispatcherUnhandledException;

        // Создаем окно splash screen, временно делаем его главным
        // окном приложения и показываем его пользователю
        var splashScreen = new SplashScreenWindow();
        MainWindow = splashScreen;
        splashScreen.Show();

        // Чтобы UI оставался отзывчивым, асинхронно делаем паузу
        // и потом переходим к показу настоящего главного окна
        await Task.Delay(5000);

        // Создаем модель
        Model = new PuzzleDomainModel();

        // Создаем настоящее главное окно типа PuzzleWindow, делаем его
        // главным окном приложения и показываем его пользователю
        MainWindow = new PuzzleWindow { DataContext = new PuzzleViewModel() };
        MainWindow.Show();

        // Закрываем splash screen
        splashScreen.Close();
    }

    private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        MessageBox.Show(
            $"Произошла непредвиденная ошибка, и игра будет закрыта.\n\n{e.Exception.GetBaseException().Message}",
            "Пятнашки", MessageBoxButton.OK, MessageBoxImage.Error);

        // Помечаем исключение обработанным, чтобы WPF не завершил процесс аварийно, и закрываем приложение сами
        e.Handled = true;
        Shutdown(1);
    }
}
