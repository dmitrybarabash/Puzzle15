namespace Puzzle15.Common
{
    /// <summary>
    /// Статический класс с разными вспомогательными свойствами и методами.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Имя файла с лучшими результатами.
        /// </summary>
        public const string BestScoresStorageFileName = "Puzzle.dat";

        /// <summary>
        /// Возвращает правильный вариант слова "ход/ходов/ходы".
        /// </summary>
        /// <param name="moves">Количество ходов.</param>
        /// <returns>Правильный вариант слова "ход/ходов/ходы".</returns>
        public static string GetMovesWord(uint moves)
        {
            uint afterLast = moves % 100 / 10;
            uint last = moves % 10;

            if (afterLast == 1 || last == 0 || (last >= 5 && last <= 9)) return "ходов";
            if (last >= 2 && last <= 4) return "хода";
            return "ход"; // if (last == 1)
        }
    }
}