using System;
using System.Windows.Input;

namespace Puzzle15.Wpf.Mvvm.ViewModels
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;


        public DelegateCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            //if (execute == null)
            //    throw new ArgumentNullException(nameof("execute"));
            //_execute = execute;
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));

            _canExecute = canExecute;
        }


        #region ICommand implementation

        public void Execute(object parameter) =>
            _execute(parameter);

        public bool CanExecute(object parameter) =>
            //_canExecute == null ? true : _canExecute(parameter);
            //_canExecute == null || _canExecute(parameter);
            //_canExecute != null ? _canExecute.Invoke(parameter) : true;
            _canExecute?.Invoke(parameter) ?? true;

        public event EventHandler CanExecuteChanged;

        #endregion

        public void RaiseCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
