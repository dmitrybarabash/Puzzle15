using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Threading;
using Puzzle15.Common;
using Puzzle15.Common.DomainModel;
using Puzzle15.Wpf.Mvvm.Commands;
using Puzzle15.Wpf.Mvvm.Services;

namespace Puzzle15.Wpf.Mvvm.ViewModels;

public class PuzzleViewModel : BaseViewModel
{
    // Экземпляр модели нашего приложения
    private IPuzzleDomainModel Model { get; }

    // Сервис, через который ViewModel просит представление показать игроку сообщение или задать вопрос
    private IDialogService DialogService { get; }

    // Игровой таймер
    private DispatcherTimer GameTimer { get; }


    public PuzzleViewModel(IPuzzleDomainModel model, IDialogService dialogService)
    {
        Model = model;
        DialogService = dialogService;

        // Создаем и настраиваем игровой таймер.
        // DispatcherTimer отсчитывает следующий тик от конца предыдущего, поэтому отставание копится.
        // При интервале в 1 с таймер из-за этого иногда перескакивает через секунду, а при 200 мс — нет.
        GameTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(200) };
        GameTimer.Tick += (s, e) => GameTimerText = Utils.FormatElapsedTime(Model.Puzzle.ElapsedTime);

        // UniformGrid в представлении раскладывает кнопки по строкам, поэтому и клетки добавляем по строкам
        var cells = new List<CellViewModel>();
        for (uint y = 0; y < Model.Puzzle.FieldSideSize; y++)
            for (uint x = 0; x < Model.Puzzle.FieldSideSize; x++)
                cells.Add(new CellViewModel(Model.Puzzle, y, x));
        Cells = cells;

        // Устанавливаем дефолтное содержимое и состояние контролов главного окна
        Model.Puzzle.Init();
        IsGameStarted = false;
        ResetGameLabels();
    }


    #region Private methods (приватные методы)

    private void UpdateCellButtons()
    {
        foreach (CellViewModel cell in Cells)
            cell.Refresh();
    }

    private void ResetGameLabels()
    {
        GameTimerText = Utils.FormatElapsedTime(TimeSpan.Zero);
        GameMovesText = "0";
    }

    private void StartGameTimer() =>
        GameTimer.Start();

    private void StopGameTimer() =>
        GameTimer.Stop();

    #endregion


    #region Binding properties (свойства привязки)

    //
    // Свойство привязки клеток поля для кнопок самих Пятнашек
    //
    public IReadOnlyList<CellViewModel> Cells { get; }

    //
    // Свойство привязки IsEnabled для текста таймера и счетчика ходов, от него же зависит доступность MoveCommand
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
                OnPropertyChanged(nameof(IsGameStarted));
                _moveCommand?.RaiseCanExecuteChanged();
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
                OnPropertyChanged(nameof(GameTimerText));
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
                OnPropertyChanged(nameof(GameMovesText));
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
            if (_newGameCommand is null)
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
            if (_moveCommand is null)
                _moveCommand = new DelegateCommand(ExecuteMoveCommand, _ => IsGameStarted);
            return _moveCommand;
        }
    }

    // execute-привязка команды MoveCommand (делаем ход), параметр команды — модель нажатой клетки
    private void ExecuteMoveCommand(object parameter)
    {
        var cell = (CellViewModel)parameter;
        if (Model.TryMove(cell.Y, cell.X, out Score finishedGameScore))
        {
            UpdateCellButtons();
            GameMovesText = Model.Puzzle.MovesCounter.ToString();

            if (finishedGameScore is not null)
            {
                StopGameTimer();
                GameTimerText = Utils.FormatElapsedTime(finishedGameScore.Timer);

                DialogService.ShowWinMessage(finishedGameScore);
                AddBestScoreResult result = Model.AddBestScore(finishedGameScore, DialogService.AskPlayerName);
                string errorMessage = Utils.GetAddBestScoreErrorMessage(result, Model.BestScoresStorage.FileName);
                if (errorMessage is not null)
                    DialogService.ShowWarning(errorMessage);

                Model.Puzzle.Init();
                IsGameStarted = false;
                UpdateCellButtons();
                ResetGameLabels();
            }
        }
    }

    #endregion
}
