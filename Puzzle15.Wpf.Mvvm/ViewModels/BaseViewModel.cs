using System;
using System.ComponentModel;

namespace Puzzle15.Wpf.Mvvm.ViewModels
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

        // Собственно, реализация Dispose() из IDisposable.
        // На самом деле всю работу по освобождению ресурсов
        // делегируем защищенному виртуальному методу OnDispose().
        public void Dispose() =>
            OnDispose();

        #endregion

        // При необходимости освобождения ресурсов, реальную работу
        // будем делать здесь, переопределяя этот метод в потомке(ах)
        protected virtual void OnDispose()
        {
        }
    }
}
