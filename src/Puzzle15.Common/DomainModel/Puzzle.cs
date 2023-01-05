using System;

namespace Puzzle15.DomainModel;

public class Puzzle : IPuzzle
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

    public Puzzle()
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
            if (indexY >= FieldSideSize)
                throw new IndexOutOfRangeException(nameof(indexY));
            if (indexX >= FieldSideSize)
                throw new IndexOutOfRangeException(nameof(indexX));

            return Cells[indexY, indexX];
        }
        set
        {
            if (indexY >= FieldSideSize)
                throw new IndexOutOfRangeException(nameof(indexY));
            if (indexX >= FieldSideSize)
                throw new IndexOutOfRangeException(nameof(indexX));

            Cells[indexY, indexX] = value;
        }
    }

    public uint EmptyY
    {
        get => _emptyY;
        set => _emptyY = value < FieldSideSize ? value : throw new IndexOutOfRangeException(nameof(EmptyY));
    }

    public uint EmptyX
    {
        get => _emptyX;
        set => _emptyX = value < FieldSideSize ? value : throw new IndexOutOfRangeException(nameof(EmptyX));
    }

    public uint EmptyCellValue => EmptyCellValueConst;

    public uint FieldSideSize => FieldSideSizeConst;

    public uint MovesCounter { get; private set; }

    public DateTime StartTime { get; private set; }

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
        var rnd = new Random();
        for (int i = 0; i < 1000; i++)
            Move((MoveDirection)rnd.Next(4));
        MovesCounter = 0;
        StartTime = DateTime.Now;
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
        if (y >= FieldSideSize)
            throw new IndexOutOfRangeException(nameof(y));
        if (x >= FieldSideSize)
            throw new IndexOutOfRangeException(nameof(x));

        if (y == EmptyY && x == EmptyX - 1) Move(MoveDirection.Left);
        if (y == EmptyY && x == EmptyX + 1) Move(MoveDirection.Right);
        if (y == EmptyY - 1 && x == EmptyX) Move(MoveDirection.Up);
        if (y == EmptyY + 1 && x == EmptyX) Move(MoveDirection.Down);
    }

    public bool IsMoveable(uint y, uint x)
    {
        if (y >= FieldSideSize)
            throw new IndexOutOfRangeException(nameof(y));
        if (x >= FieldSideSize)
            throw new IndexOutOfRangeException(nameof(x));

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
