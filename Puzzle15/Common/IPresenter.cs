namespace Puzzle15.Common
{
    /// <summary>
    /// Общий интерфейс всех презентеров.
    /// </summary>
    /// <typeparam name="T">Тип представления.</typeparam>
    public interface IPresenter<T> where T : IView
    {
        /// <summary>
        /// Возвращает ссылку на представление.
        /// </summary>
        T View { get; set; }
    }
}