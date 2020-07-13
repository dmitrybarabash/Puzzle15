using System;
using System.Windows.Input;

namespace Puzzle15.Wpf.Mvvm.ViewModels
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;


        public DelegateCommand(
                    Action<object> execute,
                    Predicate<object> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }


        public void Execute(object parameter)
        {
            _execute(parameter);
        }


        public bool CanExecute(object parameter)
        {
            //return _canExecute == null ? true : _canExecute(parameter);
            return _canExecute == null || _canExecute(parameter);
        }

        //public event EventHandler CanExecuteChanged
        //{
        //    add => CommandManager.RequerySuggested += value;
        //    remove => CommandManager.RequerySuggested -= value;
        //}

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
