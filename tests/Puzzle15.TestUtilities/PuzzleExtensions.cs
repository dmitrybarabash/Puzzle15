using Puzzle15.Common.DomainModel;

namespace Puzzle15.TestUtilities;

public static class PuzzleExtensions
{
    // Раскладывает собранное поле, в котором пустая клетка поменялась местами с клеткой (emptyY, emptyX).
    // Партию при этом не начинает и не сбрасывает: например, после Start таймер партии продолжает идти.
    public static void SetFieldWithEmptyCellAt(this IPuzzle puzzle, uint emptyY, uint emptyX)
    {
        for (uint y = 0; y < puzzle.FieldSideSize; y++)
            for (uint x = 0; x < puzzle.FieldSideSize; x++)
                puzzle[y, x] = y * puzzle.FieldSideSize + x + 1;
        uint last = puzzle.FieldSideSize - 1;
        puzzle[last, last] = puzzle[emptyY, emptyX];
        puzzle[emptyY, emptyX] = puzzle.EmptyCellValue;
        puzzle.EmptyY = emptyY;
        puzzle.EmptyX = emptyX;
    }
}
