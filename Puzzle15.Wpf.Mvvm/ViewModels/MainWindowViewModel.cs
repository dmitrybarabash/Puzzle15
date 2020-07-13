using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Puzzle15.Common;
using Puzzle15.DomainModel;
using Puzzle15.Wpf.Mvvm.Commands;
using Puzzle15.Wpf.Mvvm.Views;

namespace Puzzle15.Wpf.Mvvm.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        // Берем экземпляр модели из класса приложения App
        private IPuzzleDomainModel Model => (Application.Current as App).Model;

        // Игровой таймер
        private DispatcherTimer GameTimer { get; }


        public MainWindowViewModel()
        {
            // Создаем и настраиваем игровой таймер
            GameTimer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
            GameTimer.Tick += (s, a) => GameTimerText = (DateTime.Now - Model.Puzzle.StartTime).ToString(@"hh\:mm\:ss");

            // Устанавливаем дефолтное содержимое и состояние контролов главного окна
            Model.Puzzle.Init();
            IsGameStarted = false;
            ResetGameLabels();
        }


        #region Private methods (приватные методы)

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

        private void ResetGameLabels()
        {
            GameMovesText = "0";
            GameTimerText = "00:00:00";
        }

        private void StartGameTimer() =>
            GameTimer.Start();

        private void StopGameTimer() =>
            GameTimer.Stop();

        #endregion


        #region Binding properties (свойства привязки)

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

        private Visibility GetCellButtonVisibility(uint y, uint x) =>
            Model.Puzzle[y, x] != Model.Puzzle.EmptyCellValue ? Visibility.Visible : Visibility.Hidden;

        public Visibility CellButtonVisibility00 => GetCellButtonVisibility(0, 0);
        public Visibility CellButtonVisibility01 => GetCellButtonVisibility(0, 1);
        public Visibility CellButtonVisibility02 => GetCellButtonVisibility(0, 2);
        public Visibility CellButtonVisibility03 => GetCellButtonVisibility(0, 3);
        public Visibility CellButtonVisibility10 => GetCellButtonVisibility(1, 0);
        public Visibility CellButtonVisibility11 => GetCellButtonVisibility(1, 1);
        public Visibility CellButtonVisibility12 => GetCellButtonVisibility(1, 2);
        public Visibility CellButtonVisibility13 => GetCellButtonVisibility(1, 3);
        public Visibility CellButtonVisibility20 => GetCellButtonVisibility(2, 0);
        public Visibility CellButtonVisibility21 => GetCellButtonVisibility(2, 1);
        public Visibility CellButtonVisibility22 => GetCellButtonVisibility(2, 2);
        public Visibility CellButtonVisibility23 => GetCellButtonVisibility(2, 3);
        public Visibility CellButtonVisibility30 => GetCellButtonVisibility(3, 0);
        public Visibility CellButtonVisibility31 => GetCellButtonVisibility(3, 1);
        public Visibility CellButtonVisibility32 => GetCellButtonVisibility(3, 2);
        public Visibility CellButtonVisibility33 => GetCellButtonVisibility(3, 3);


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

        #endregion


        #region Commands & its bindings (команды и их привязки)

        //
        // NewGameCommand
        //

        private DelegateCommand _newGameCommand;
        public ICommand NewGameCommand
        {
            get
            {
                // Ленивая инициализация
                if (_newGameCommand == null)
                    _newGameCommand = new DelegateCommand(ExecuteNewGameCommand);
                return _newGameCommand;
            }
        }

        // execute-привязка команды NewGameCommand (начинаем новую игру)
        private void ExecuteNewGameCommand(object parameter)
        {
            Model.Puzzle.Start();
            IsGameStarted = true;
            UpdateCellButtons();
            ResetGameLabels();
            StartGameTimer();
        }


        //
        // MoveCommand
        //

        private DelegateCommand _moveCommand;
        public ICommand MoveCommand
        {
            get
            {
                // Ленивая инициализация
                if (_moveCommand == null)
                    _moveCommand = new DelegateCommand(ExecuteMoveCommand);
                return _moveCommand;
            }
        }

        // execute-привязка команды MoveCommand (делаем ход)
        private void ExecuteMoveCommand(object parameter)
        {
            Button button = parameter as Button;

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
                        // Не получилось прочитать/записать файл с рекордами — окей, просто пропускаем эту часть.
                    }

                    Model.Puzzle.Init();
                    IsGameStarted = false;
                    UpdateCellButtons();
                    StopGameTimer();
                    ResetGameLabels();
                }
            }
        }

        #endregion
    }
}
