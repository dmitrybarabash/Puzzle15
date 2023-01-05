using System;

namespace Puzzle15.DomainModel;

public interface IPuzzle
{
    uint[,] Cells { get; }
    uint this[uint indexY, uint indexX] { get; set; }
    uint EmptyX { get; set; }
    uint EmptyY { get; set; }
    uint EmptyCellValue { get; }
    uint FieldSideSize { get; }

    uint MovesCounter { get; }
    DateTime StartTime { get; }

    void Init();
    void Start();
    void Move(uint y, uint x);
    bool IsMoveable(uint y, uint x);
    bool IsDone();
}
