using System.ComponentModel.DataAnnotations;
using System.Windows;
using Puzzle15.Common;
using Puzzle15.DomainModel;

namespace Puzzle15.Wpf.Mvvm.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        //
        private IPuzzleDomainModel Model => (Application.Current as App).Model;

        public DelegateCommand NewGameCommand { get; }
        public DelegateCommand MoveCommand { get; }
        public DelegateCommand BestScoresCommand { get; }

        public MainWindowViewModel()
        {
            NewGameCommand = new DelegateCommand(win =>
            {
                var mainWindow = win as Puzzle15.Wpf.Mvvm.Views.MainWindow;

                Model.Puzzle.Start();
                mainWindow.UpdateButtons(true);
                mainWindow.StartTimer();
                mainWindow.UpdateGameLabels(true);
            });

            MoveCommand = new DelegateCommand(win =>
            {

            });

            BestScoresCommand = new DelegateCommand(win =>
            {

            });
        }

        /*
                //
                // Свойства-обертки для объектов модели, реализующие их ленивую
                // инициализацию и механизм уведомления представления при их изменении
                //

                private int _movesCounter;
                public int MovesCounter
                {
                    get => _movesCounter;
                    set
                    {
                        _movesCounter = value;
                        OnPropertyChanged("MovesCounter");
                    }
                }

                // Все клиенты (сам тип клиента для коллекции так же берется из модели).
                // В этой программе это свойство — readonly. Поэтому механизм уведомления
                // представления о ее изменении здесь не нужен.
                private ObservableCollection<Client> _clients;
                public ObservableCollection<Client> Clients
                {
                    get
                    {
                        // Ленивая инициализация
                        if (_clients == null)
                            _clients = ClientRepository.AllClients;
                        return _clients;
                    }
                }
        */


        //
        // Команда AddClient и ее привязка (execute и canExecute)
        //

        /*
                private RelayCommand _addClientCommand;
                public ICommand AddClient
                {
                    get
                    {
                        // Ленивая инициализация
                        if (_addClientCommand == null)
                            _addClientCommand = new RelayCommand(ExecuteAddClientCommand, CanExecuteAddClientCommand);
                        return _addClientCommand;
                    }
                }


                // execute-привязка (добавляем нового клиента)
                public void ExecuteAddClientCommand(object parameter)
                {
                    Clients.Add(CurrentClient);
                    CurrentClient = null;
                }

                // canExecute-привязка (оба поля CurrentClient.FirstName и CurrentClient.LastName должны быть не пустые)
                public bool CanExecuteAddClientCommand(object parameter)
                {
                    //if (string.IsNullOrEmpty(CurrentClient.FirstName) ||
                    //    string.IsNullOrEmpty(CurrentClient.LastName))
                    //{
                    //    return false;
                    //}
                    //return true;

                    // Так короче:
                    return !string.IsNullOrEmpty(CurrentClient.FirstName) && !string.IsNullOrEmpty(CurrentClient.LastName);
                }
        */


        //
        // Полиморфная реализация паттерна Disposable
        //

        // Вызывается из Dispose() базового класса
        protected override void OnDispose()
        {
            //Clients.Clear();
        }
    }
}
