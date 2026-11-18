using Puzzle15.Common.DomainModel;

namespace Puzzle15.Wpf.Mvvm.Services;

// Диалоги с игроком, которые нужны ViewModel. Сама ViewModel не знает ни об окнах, ни о MessageBox,
// поэтому показывает диалоги через этот интерфейс, а в тестах его заменяет заглушка.
public interface IDialogService
{
    // Сообщает игроку о победе и показывает результат партии
    void ShowWinMessage(Score score);

    // Спрашивает имя игрока для таблицы рекордов. Возвращает null, если игрок отказался.
    string AskPlayerName();
}
