using System;
using System.IO;

namespace Puzzle15.Common;

public static class Options
{
    public const string BestScoresStorageFileName = "Puzzle.dat";

    // Файл рекордов всегда лежит рядом с exe-файлом, из какой бы папки ни запустили игру.
    // Относительный путь "Puzzle.dat" отсчитывался бы от текущей рабочей папки процесса,
    // а она не обязательно совпадает с папкой, где лежит exe-файл (например, запуск
    // через ярлык с другой рабочей папкой или запуск из терминала).
    public static string BestScoresStoragePath { get; } =
        Path.Combine(AppContext.BaseDirectory, BestScoresStorageFileName);
}
