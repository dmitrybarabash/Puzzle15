using System;
using Puzzle15.Common.DomainModel;

namespace Puzzle15.WinForms.Mvp.UnitTests.Stubs;

public class StubPuzzle : IPuzzle
{
    private enum MoveDirection
    {
        Up,
        Left,
        Right,
        Down
    }

    private const uint FieldSideSizeConst = 4;
    private const uint EmptyCellValueConst = FieldSideSizeConst * FieldSideSizeConst;

    private uint _emptyX;
    private uint _emptyY;

    public StubPuzzle()
    {
        Cells = new uint[FieldSideSize, FieldSideSize];
        Init();
    }

    #region IPuzzle implementation

    public uint[,] Cells { get; private set; }

    public uint this[uint indexY, uint indexX]
    {
        get
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(indexY, FieldSideSize);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(indexX, FieldSideSize);

            return Cells[indexY, indexX];
        }
        set
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(indexY, FieldSideSize);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(indexX, FieldSideSize);

            Cells[indexY, indexX] = value;
        }
    }

    public uint EmptyY
    {
        get => _emptyY;
        set
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(value, FieldSideSize);
            _emptyY = value;
        }
    }

    public uint EmptyX
    {
        get => _emptyX;
        set
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(value, FieldSideSize);
            _emptyX = value;
        }
    }

    public uint EmptyCellValue => EmptyCellValueConst;

    public uint FieldSideSize => FieldSideSizeConst;

    public uint MovesCounter { get; private set; }

    public TimeSpan ElapsedTime { get; private set; }

    public void Init()
    {
        for (uint i = 0; i < FieldSideSize; i++)
            for (uint j = 0; j < FieldSideSize; j++)
                Cells[i, j] = i * FieldSideSize + j + 1;
        EmptyX = FieldSideSize - 1;
        EmptyY = FieldSideSize - 1;
        MovesCounter = 0;
    }

    public void Start()
    {
        Cells[FieldSideSize - 1, FieldSideSize - 2] = EmptyCellValue;      // 16
        Cells[FieldSideSize - 1, FieldSideSize - 1] = EmptyCellValue - 1;  // 15
        EmptyY = FieldSideSize - 1;                                        // 3
        EmptyX = FieldSideSize - 2;                                        // 2
        MovesCounter = 100;
        ElapsedTime = new TimeSpan(0, 0, 1, 30);
    }

    private void Move(MoveDirection moveDirection)
    {
        switch (moveDirection)
        {
            case MoveDirection.Up:
                if (EmptyY > 0)
                {
                    Cells[EmptyY, EmptyX] = Cells[EmptyY - 1, EmptyX];
                    Cells[EmptyY - 1, EmptyX] = EmptyCellValue;
                    EmptyY--;
                }
                break;
            case MoveDirection.Left:
                if (EmptyX > 0)
                {
                    Cells[EmptyY, EmptyX] = Cells[EmptyY, EmptyX - 1];
                    Cells[EmptyY, EmptyX - 1] = EmptyCellValue;
                    EmptyX--;
                }
                break;
            case MoveDirection.Right:
                if (EmptyX < FieldSideSize - 1)
                {
                    Cells[EmptyY, EmptyX] = Cells[EmptyY, EmptyX + 1];
                    Cells[EmptyY, EmptyX + 1] = EmptyCellValue;
                    EmptyX++;
                }
                break;
            case MoveDirection.Down:
                if (EmptyY < FieldSideSize - 1)
                {
                    Cells[EmptyY, EmptyX] = Cells[EmptyY + 1, EmptyX];
                    Cells[EmptyY + 1, EmptyX] = EmptyCellValue;
                    EmptyY++;
                }
                break;
        }
        MovesCounter++;
    }

    public void Move(uint y, uint x)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(y, FieldSideSize);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(x, FieldSideSize);

        if (y == EmptyY && x == EmptyX - 1) Move(MoveDirection.Left);
        else if (y == EmptyY && x == EmptyX + 1) Move(MoveDirection.Right);
        else if (y == EmptyY - 1 && x == EmptyX) Move(MoveDirection.Up);
        else if (y == EmptyY + 1 && x == EmptyX) Move(MoveDirection.Down);
    }

    public bool IsMoveable(uint y, uint x)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(y, FieldSideSize);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(x, FieldSideSize);

        return
            (y == EmptyY && x == EmptyX - 1) ||
            (y == EmptyY && x == EmptyX + 1) ||
            (y == EmptyY - 1 && x == EmptyX) ||
            (y == EmptyY + 1 && x == EmptyX);
    }

    public bool IsDone()
    {
        for (uint i = 0; i < FieldSideSize; i++)
            for (uint j = 0; j < FieldSideSize; j++)
                if (Cells[i, j] != i * FieldSideSize + j + 1)
                    return false;
        return true;
    }

    #endregion
}
