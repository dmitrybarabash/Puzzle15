namespace Puzzle15.WinForms.Mvp.Common
{
    public interface IPresenter<T> where T : IView
    {
        T View { get; set; }
    }
}