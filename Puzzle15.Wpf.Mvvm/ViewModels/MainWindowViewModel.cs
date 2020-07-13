using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Puzzle15.Common;
using Puzzle15.DomainModel;
using Puzzle15.Wpf.Mvvm.Views;

namespace Puzzle15.Wpf.Mvvm.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IPuzzleDomainModel Model => (Application.Current as App).Model;

        public DelegateCommand NewGameCommand { get; }
        public DelegateCommand MoveCommand { get; }

        public MainWindowViewModel()
        {
            Model.Puzzle.Init();
            GameMoves = "0";

            NewGameCommand = new DelegateCommand(win =>
            {
                var mainWindow = win as Puzzle15.Wpf.Mvvm.Views.MainWindow;

                Model.Puzzle.Start();
                //GameMoves = Model.Puzzle.MovesCounter.ToString();

                mainWindow.UpdateButtons(true);
                mainWindow.StartTimer();
                mainWindow.UpdateGameLabels(true);
            });

            MoveCommand = new DelegateCommand(b =>
            {
                var mainWindow = Application.Current.MainWindow as Puzzle15.Wpf.Mvvm.Views.MainWindow;
                Button button = b as Button;

                uint clickedNumber = uint.Parse(button.Name.Remove(0, 10));
                uint y = (clickedNumber - 1) / Model.Puzzle.FieldSideSize;
                uint x = (clickedNumber - 1) % Model.Puzzle.FieldSideSize;
                if (Model.Puzzle.IsMoveable(y, x))
                {
                    Model.Puzzle.Move(y, x);
                    mainWindow.UpdateButtons(true);
                    GameMoves = Model.Puzzle.MovesCounter.ToString();
                    //BindingOperations.GetBindingExpression(button, Button.ContentProperty).UpdateTarget();

                    if (Model.Puzzle.IsDone())
                    {
                        mainWindow.StopTimer();
                        var score = new Score
                        {
                            Moves = Model.Puzzle.MovesCounter,
                            Timer = DateTime.Now - Model.Puzzle.StartTime
                        };

                        MessageBox.Show(
                            $"Вы выиграли!\n\nВы сделали {Model.Puzzle.MovesCounter} {Utils.GetMovesWord(Model.Puzzle.MovesCounter)} за {GameTimer}!",
                            "Молодец!", MessageBoxButton.OK, MessageBoxImage.Information);

                        try
                        {
                            Model.BestScoresStorage.Load(Model.BestScores);
                            if (Model.BestScores.CanBeAdded(score))
                            {
                                var bestScoredPlayerNameWindow = new BestScoredPlayerNameWindow { Owner = mainWindow };
                                if (bestScoredPlayerNameWindow.ShowDialog() == true)
                                {
                                    score.Name = bestScoredPlayerNameWindow.PlayerName;
                                    Model.BestScores.Add(score);
                                    Model.BestScoresStorage.Save(Model.BestScores);
                                }
                            }
                        }
                        catch
                        {
                            // Ничего не делаем, пользователю ничего не говорим.
                            // Не получилось прочитать/записать файл с рекордами — ок, просто пропускаем эту часть.
                        }

                        Model.Puzzle.Init();
                        mainWindow.UpdateButtons(false);
                        mainWindow.StopTimer();
                        mainWindow.UpdateGameLabels(false);
                    }
                }
            });
        }

        //
        // Свойства привязки для кнопок самих Пятнашек
        //
        public string CellValue00 => Model.Puzzle[0, 0].ToString();
        public string CellValue01 => Model.Puzzle[0, 1].ToString();
        public string CellValue02 => Model.Puzzle[0, 2].ToString();
        public string CellValue03 => Model.Puzzle[0, 3].ToString();
        public string CellValue10 => Model.Puzzle[1, 0].ToString();
        public string CellValue11 => Model.Puzzle[1, 1].ToString();
        public string CellValue12 => Model.Puzzle[1, 2].ToString();
        public string CellValue13 => Model.Puzzle[1, 3].ToString();
        public string CellValue20 => Model.Puzzle[2, 0].ToString();
        public string CellValue21 => Model.Puzzle[2, 1].ToString();
        public string CellValue22 => Model.Puzzle[2, 2].ToString();
        public string CellValue23 => Model.Puzzle[2, 3].ToString();
        public string CellValue30 => Model.Puzzle[3, 0].ToString();
        public string CellValue31 => Model.Puzzle[3, 1].ToString();
        public string CellValue32 => Model.Puzzle[3, 2].ToString();
        public string CellValue33 => Model.Puzzle[3, 3].ToString();


        private string _gameTimer;
        public string GameTimer
        {
            get => _gameTimer;
            set
            {
                if (_gameTimer != value)
                {
                    _gameTimer = value;
                    OnPropertyChanged("GameTimer");
                }
            }
        }

        private string _gameMoves;
        public string GameMoves
        {
            get => _gameMoves;
            set
            {
                if (_gameMoves != value)
                {
                    _gameMoves = value;
                    OnPropertyChanged("GameMoves");
                }
            }
        }





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
    }
}
