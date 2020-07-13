namespace Puzzle15.WinForms.Common
{
    public interface IPresenter<T> where T : IView
    {
        T View { get; set; }
    }
}