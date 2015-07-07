namespace Puzzle15.Common
{
    public interface IPresenter<T> where T : IView
    {
        T View { get; set; }
    }
}