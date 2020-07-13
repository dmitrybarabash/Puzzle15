using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using Puzzle15.Common;
using Puzzle15.DomainModel;
using Puzzle15.Wpf.Mvvm.Views;

namespace Puzzle15.Wpf.Mvvm.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IPuzzleDomainModel Model => (Application.Current as App).Model;
        private DispatcherTimer GameTimer { get; }

        public DelegateCommand NewGameCommand { get; }
        public DelegateCommand MoveCommand { get; }

        public MainWindowViewModel()
        {
            GameTimer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
            GameTimer.Tick += (s, a) => GameTimerText = (DateTime.Now - Model.Puzzle.StartTime).ToString(@"hh\:mm\:ss");

            Model.Puzzle.Init();
            IsGameStarted = false;
            ResetGameLabels();

            NewGameCommand = new DelegateCommand(_ =>
            {
                Model.Puzzle.Start();
                IsGameStarted = true;
                UpdateCellButtons();
                ResetGameLabels();
                StartGameTimer();
            });

            MoveCommand = new DelegateCommand(b =>
            {
                Button button = b as Button;

                uint clickedNumber = uint.Parse(button.Name.Remove(0, 10));
                uint y = (clickedNumber - 1) / Model.Puzzle.FieldSideSize;
                uint x = (clickedNumber - 1) % Model.Puzzle.FieldSideSize;
                if (Model.Puzzle.IsMoveable(y, x))
                {
                    Model.Puzzle.Move(y, x);
                    UpdateCellButtons();
                    GameMovesText = Model.Puzzle.MovesCounter.ToString();

                    if (Model.Puzzle.IsDone())
                    {
                        StopGameTimer();
                        var score = new Score
                        {
                            Moves = Model.Puzzle.MovesCounter,
                            Timer = DateTime.Now - Model.Puzzle.StartTime
                        };

                        MessageBox.Show(
                            $"Вы выиграли!\n\nВы сделали {Model.Puzzle.MovesCounter} {Utils.GetMovesWord(Model.Puzzle.MovesCounter)} за {GameTimerText}!",
                            "Молодец!", MessageBoxButton.OK, MessageBoxImage.Information);

                        try
                        {
                            Model.BestScoresStorage.Load(Model.BestScores);
                            if (Model.BestScores.CanBeAdded(score))
                            {
                                var mainWindow = Application.Current.MainWindow as MainWindow;
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
                        IsGameStarted = false;
                        UpdateCellButtons();
                        StopGameTimer();
                        ResetGameLabels();
                    }
                }
            });
        }

        private void StartGameTimer()
        {
            GameTimer.Start();
        }

        private void StopGameTimer()
        {
            GameTimer.Stop();
        }

        private void ResetGameLabels()
        {
            GameMovesText = "0";
            GameTimerText = "00:00:00";
        }

        private void UpdateCellButtons()
        {
            for (int y = 0; y < Model.Puzzle.FieldSideSize; y++)
            {
                for (int x = 0; x < Model.Puzzle.FieldSideSize; x++)
                {
                    OnPropertyChanged($"CellButtonValue{y}{x}");
                    OnPropertyChanged($"CellButtonVisibility{y}{x}");
                }
            }
        }


        //
        // Свойства привязки содержимого для кнопок самих Пятнашек
        //
        public string CellButtonValue00 => Model.Puzzle[0, 0].ToString();
        public string CellButtonValue01 => Model.Puzzle[0, 1].ToString();
        public string CellButtonValue02 => Model.Puzzle[0, 2].ToString();
        public string CellButtonValue03 => Model.Puzzle[0, 3].ToString();
        public string CellButtonValue10 => Model.Puzzle[1, 0].ToString();
        public string CellButtonValue11 => Model.Puzzle[1, 1].ToString();
        public string CellButtonValue12 => Model.Puzzle[1, 2].ToString();
        public string CellButtonValue13 => Model.Puzzle[1, 3].ToString();
        public string CellButtonValue20 => Model.Puzzle[2, 0].ToString();
        public string CellButtonValue21 => Model.Puzzle[2, 1].ToString();
        public string CellButtonValue22 => Model.Puzzle[2, 2].ToString();
        public string CellButtonValue23 => Model.Puzzle[2, 3].ToString();
        public string CellButtonValue30 => Model.Puzzle[3, 0].ToString();
        public string CellButtonValue31 => Model.Puzzle[3, 1].ToString();
        public string CellButtonValue32 => Model.Puzzle[3, 2].ToString();
        public string CellButtonValue33 => Model.Puzzle[3, 3].ToString();


        //
        // Свойства привязки видимости для кнопок самих Пятнашек
        //
        public Visibility CellButtonVisibility00 => Model.Puzzle[0, 0] != Model.Puzzle.EmptyCellValue ? Visibility.Visible : Visibility.Hidden;
        public Visibility CellButtonVisibility01 => Model.Puzzle[0, 1] != Model.Puzzle.EmptyCellValue ? Visibility.Visible : Visibility.Hidden;
        public Visibility CellButtonVisibility02 => Model.Puzzle[0, 2] != Model.Puzzle.EmptyCellValue ? Visibility.Visible : Visibility.Hidden;
        public Visibility CellButtonVisibility03 => Model.Puzzle[0, 3] != Model.Puzzle.EmptyCellValue ? Visibility.Visible : Visibility.Hidden;
        public Visibility CellButtonVisibility10 => Model.Puzzle[1, 0] != Model.Puzzle.EmptyCellValue ? Visibility.Visible : Visibility.Hidden;
        public Visibility CellButtonVisibility11 => Model.Puzzle[1, 1] != Model.Puzzle.EmptyCellValue ? Visibility.Visible : Visibility.Hidden;
        public Visibility CellButtonVisibility12 => Model.Puzzle[1, 2] != Model.Puzzle.EmptyCellValue ? Visibility.Visible : Visibility.Hidden;
        public Visibility CellButtonVisibility13 => Model.Puzzle[1, 3] != Model.Puzzle.EmptyCellValue ? Visibility.Visible : Visibility.Hidden;
        public Visibility CellButtonVisibility20 => Model.Puzzle[2, 0] != Model.Puzzle.EmptyCellValue ? Visibility.Visible : Visibility.Hidden;
        public Visibility CellButtonVisibility21 => Model.Puzzle[2, 1] != Model.Puzzle.EmptyCellValue ? Visibility.Visible : Visibility.Hidden;
        public Visibility CellButtonVisibility22 => Model.Puzzle[2, 2] != Model.Puzzle.EmptyCellValue ? Visibility.Visible : Visibility.Hidden;
        public Visibility CellButtonVisibility23 => Model.Puzzle[2, 3] != Model.Puzzle.EmptyCellValue ? Visibility.Visible : Visibility.Hidden;
        public Visibility CellButtonVisibility30 => Model.Puzzle[3, 0] != Model.Puzzle.EmptyCellValue ? Visibility.Visible : Visibility.Hidden;
        public Visibility CellButtonVisibility31 => Model.Puzzle[3, 1] != Model.Puzzle.EmptyCellValue ? Visibility.Visible : Visibility.Hidden;
        public Visibility CellButtonVisibility32 => Model.Puzzle[3, 2] != Model.Puzzle.EmptyCellValue ? Visibility.Visible : Visibility.Hidden;
        public Visibility CellButtonVisibility33 => Model.Puzzle[3, 3] != Model.Puzzle.EmptyCellValue ? Visibility.Visible : Visibility.Hidden;


        //
        // Свойство привязки состояния IsEnabale для кнопок самих Пятнашек, текста таймера и счетчика ходов
        //
        private bool _isGameStarted = false;
        public bool IsGameStarted
        {
            get => _isGameStarted;
            set
            {
                if (_isGameStarted != value)
                {
                    _isGameStarted = value;
                    OnPropertyChanged("IsGameStarted");
                }
            }
        }

        //
        // Свойство привязки текста таймера
        //
        private string _gameTimerText;
        public string GameTimerText
        {
            get => _gameTimerText;
            set
            {
                if (_gameTimerText != value)
                {
                    _gameTimerText = value;
                    OnPropertyChanged("GameTimerText");
                }
            }
        }

        //
        // Свойство привязки счетчика количества ходов
        //
        private string _gameMovesText;
        public string GameMovesText
        {
            get => _gameMovesText;
            set
            {
                if (_gameMovesText != value)
                {
                    _gameMovesText = value;
                    OnPropertyChanged("GameMovesText");
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
