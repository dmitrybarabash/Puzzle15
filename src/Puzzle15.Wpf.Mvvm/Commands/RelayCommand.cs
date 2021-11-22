using System;
using System.Windows.Input;

namespace Puzzle15.Wpf.Mvvm.Commands;

class RelayCommand : ICommand
{
    private readonly Action<object> _execute;
    private readonly Predicate<object> _canExecute;

    // Конструктор
    public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
    {
        //if (execute is null)
        //    throw new ArgumentNullException(nameof("execute"));
        //_execute = execute;
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));

        _canExecute = canExecute;
    }


    #region ICommand implementation

    public void Execute(object parameter) =>
        _execute.Invoke(parameter);

    public bool CanExecute(object parameter) =>
        //_canExecute is not null ? _canExecute.Invoke(parameter) : true;
        _canExecute?.Invoke(parameter) ?? true;

    // Либо мы сами следим за тем когда дергать CanExecuteChanged, либо делегируем это CommandManager'у,
    // который периодически дергает CanExecuteChanged, причем когда он сам считает нужным (смена фокуса
    // или еще что-то). При этом, во втором случае, время от времени следует так же вызывать
    // CommandManager.InvalidateRequerySuggested(): что-то происходило в фоновой работе, UI мы не трогали,
    // но некоторые команды смогли поменять состояние CanExecute. И мы вызываем InvalidateRequerySuggested,
    // чтобы он вызвал CanExecuteChanged подписчиков.
    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    #endregion
}
