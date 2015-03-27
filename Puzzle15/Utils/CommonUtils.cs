namespace Puzzle15.Utils
{
    public static class CommonUtils
    {
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