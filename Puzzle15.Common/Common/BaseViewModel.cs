using System;
using System.ComponentModel;

namespace Puzzle15.Common
{
    public abstract class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        //
        //
        //

        protected BaseViewModel()
        {
        }


        //
        // Реализация INotifyPropertyChanged
        // (механизм уведомления об изменении свойств модели)
        //

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        //
        // Полиморфная реализация IDisposable
        //

        // Собственно, реализация Dispose() из IDisposable
        public void Dispose()
        {
            OnDispose();
        }

        // Реальную работу по освобождению ресурсов будем делать
        // здесь, переопределяя этот метод в потомках
        protected virtual void OnDispose()
        {
        }
    }
}
