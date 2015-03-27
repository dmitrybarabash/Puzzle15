namespace Puzzle15.Utils
{
    public static class CommonUtils
    {
        public static string GetMovesWord(uint moves)
        {
            if (moves % 100 / 10 == 1)
                return "ходов";

            switch (moves % 10)
            {
                case 1:
                    return "ход";
                case 2:
                case 3:
                case 4:
                    return "хода";
                default:
                    return "ходов";
            }
        }
    }
}