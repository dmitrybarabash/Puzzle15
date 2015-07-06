namespace Puzzle15.Common
{
    /// <summary>
    /// Абстрактный класс для всех презентеров.
    /// </summary>
    /// <typeparam name="T">Тип представления.</typeparam>
    public abstract class BasePresenter<T> : IPresenter<T> where T : IView
    {
        /// <summary>
        /// Возвращает ссылку на представление.
        /// </summary>
        public T View { get; set; }
    }
}