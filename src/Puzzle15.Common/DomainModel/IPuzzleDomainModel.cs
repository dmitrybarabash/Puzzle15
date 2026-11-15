using System;

namespace Puzzle15.Common.DomainModel;

public interface IPuzzleDomainModel
{
    IPuzzle Puzzle { get; }
    IBestScores BestScores { get; }
    IBestScoresStorage BestScoresStorage { get; }

    // Перечитывает таблицу рекордов из файла. Возвращает false, если файл прочитать не удалось.
    bool TryLoadBestScores();

    // Добавляет результат партии в таблицу рекордов, если он туда попадает.
    // askPlayerName спрашивает имя игрока и возвращает null, если игрок отказался.
    // Возвращает true, если результат добавлен и сохранён.
    bool TryAddBestScore(Score score, Func<string> askPlayerName);
}
