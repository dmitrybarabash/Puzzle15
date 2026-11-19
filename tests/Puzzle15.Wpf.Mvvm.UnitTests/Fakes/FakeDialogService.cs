using System.Collections.Generic;
using Puzzle15.Common.DomainModel;
using Puzzle15.Wpf.Mvvm.Services;

namespace Puzzle15.Wpf.Mvvm.UnitTests.Fakes;

// Вместо окон запоминает, какие диалоги ViewModel показала бы игроку
public class FakeDialogService : IDialogService
{
    // Имя, которое «введет» игрок, или null, если он откажется
    public string PlayerName { get; set; }

    // Результат из сообщения о победе или null, если сообщения не было
    public Score WinMessageScore { get; private set; }

    public int AskPlayerNameCount { get; private set; }

    public List<string> Warnings { get; } = [];

    #region IDialogService implementation

    // Запоминаем копию, потому что потом модель впишет в этот же результат имя игрока
    public void ShowWinMessage(Score score) =>
        WinMessageScore = new Score { Name = score.Name, Moves = score.Moves, Timer = score.Timer };

    public string AskPlayerName()
    {
        AskPlayerNameCount++;
        return PlayerName;
    }

    public void ShowWarning(string message) =>
        Warnings.Add(message);

    #endregion
}
