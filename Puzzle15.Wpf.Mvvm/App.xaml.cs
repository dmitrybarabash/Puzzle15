﻿using System.Threading.Tasks;
using System.Windows;
using Puzzle15.DomainModel;
using Puzzle15.Wpf.Mvvm.ViewModels;
using Puzzle15.Wpf.Mvvm.Views;

namespace Puzzle15.Wpf.Mvvm
{
    public partial class App : Application
    {
        // Экземпляр модели нашего приложения
        public IPuzzleDomainModel Model { get; private set; }

        //
        // Переопределенный метод OnStartup выполняет здесь две задачи:
        //
        //    1. Splash Screen.
        //         Показывает splash screen, а только затем показывает главное окно приложения.
        //         Про реализацию splash screen:
        //         https://wpf.programmingpedia.net/en/tutorial/3948/creating-splash-screen-in-wpf
        //
        //    2. Является Application Root нашего приложения.
        //         Создает экземпляр модели — единственный на всё приложение.
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

                // Создаем настоящее главное окно типа PuzzleWindow, делаем его главным окном
                // приложения и показываем его пользователю. Поскольку мы сейчас вне основного
                // UI-потока, то обращение к тому, что имеет отношение UI-потоку, должно быть
                // вызвано потокобезопасно. В WPF это делается при помощи методов Invoke или
                // BeginInvoke объекта Dispatcher, который как раз и дает доступ к UI-потоку.
                Dispatcher.Invoke(() =>
                {
                    // Создаем модель
                    Model = new PuzzleDomainModel();

                    // Создаем настоящее главное окно типа PuzzleWindow, делаем его
                    // главным окном приложения и показываем его пользователю
                    MainWindow = new PuzzleWindow { DataContext = new PuzzleViewModel() };
                    MainWindow.Show();

                    // Закрываем splash screen
                    splashScreen.Close();
                });
            });
        }
    }
}
