namespace Puzzle15.WinForms.Mvp.Common
{
    public abstract class BasePresenter<T> : IPresenter<T> where T : IView
    {
        public T View { get; set; }
    }
}