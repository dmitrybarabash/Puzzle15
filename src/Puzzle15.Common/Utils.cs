using System;

namespace Puzzle15.Common;

public static class Utils
{
    public static string GetMovesWord(uint moves)
    {
        uint afterLast = moves % 100 / 10;
        uint last = moves % 10;

        if (afterLast == 1 || last == 0 || (last >= 5 && last <= 9)) return "ходов";
        if (last >= 2 && last <= 4) return "хода";
        return "ход"; // if (last == 1)
    }

    // Единый формат времени партии для таймера, сообщения о победе и таблицы рекордов:
    //   - доли секунды отбрасываются, а не округляются, поэтому таймер никогда не забегает вперёд;
    //   - часы считаются полностью, без отбрасывания суток, поэтому 25 часов показываются как 25:00:00.
    public static string FormatElapsedTime(TimeSpan time) =>
        $"{(int)time.TotalHours:00}:{time.Minutes:00}:{time.Seconds:00}";
}
