using System;
using System.ComponentModel;

namespace Puzzle15.Common
{
    public abstract class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        // Защищенный конструктор
        protected BaseViewModel()
        {
        }


        #region INotifyPropertyChanged implementation (механизм уведомления об изменении свойств модели)

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion


        #region IDisposable implementation (полиморфная реализация)

        // Собственно, реализация Dispose() из IDisposable
        public void Dispose() =>
            OnDispose();

        // Реальную работу по освобождению ресурсов будем делать
        // здесь, переопределяя этот метод в потомках
        protected virtual void OnDispose()
        {
        }

        #endregion
    }
}
