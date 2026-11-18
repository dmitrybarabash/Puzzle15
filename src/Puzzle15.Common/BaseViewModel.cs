using System.ComponentModel;

namespace Puzzle15.Common;

public abstract class BaseViewModel : INotifyPropertyChanged
{
    // Защищенный конструктор
    protected BaseViewModel()
    {
    }

    #region INotifyPropertyChanged implementation (механизм уведомления об изменении свойств ViewModel)

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    #endregion
}
