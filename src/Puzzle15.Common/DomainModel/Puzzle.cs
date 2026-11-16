using System;

namespace Puzzle15.Common.DomainModel;

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

    private readonly Random _random;

    private readonly TimeProvider _timeProvider;
    // Отметка начала партии или null, если партия еще не началась
    private long? _startTimestamp;
    // Время уже завершённой партии
    private TimeSpan _finishedElapsedTime;

    public Puzzle() : this(TimeProvider.System, Random.Shared)
    {
    }

    // Нужен для тестов: источник времени и генератор случайных чисел можно будет подменить
    public Puzzle(TimeProvider timeProvider, Random random)
    {
        ArgumentNullException.ThrowIfNull(timeProvider);
        ArgumentNullException.ThrowIfNull(random);
        _timeProvider = timeProvider;
        _random = random;
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

    public TimeSpan ElapsedTime =>
        _startTimestamp is long start ? _timeProvider.GetElapsedTime(start) : _finishedElapsedTime;

    public void Init()
    {
        for (uint i = 0; i < FieldSideSize; i++)
            for (uint j = 0; j < FieldSideSize; j++)
                Cells[i, j] = i * FieldSideSize + j + 1;
        EmptyX = FieldSideSize - 1;
        EmptyY = FieldSideSize - 1;
        MovesCounter = 0;
        _startTimestamp = null;
        _finishedElapsedTime = TimeSpan.Zero;
    }

    public void Start()
    {
        for (int i = 0; i < 1000; i++)
            Move((MoveDirection)_random.Next(4));
        MovesCounter = 0;
        _startTimestamp = _timeProvider.GetTimestamp();
        _finishedElapsedTime = TimeSpan.Zero;
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
        if (GetMoveDirection(y, x) is MoveDirection moveDirection)
            Move(moveDirection);

        if (_startTimestamp is long start && IsDone())
        {
            _startTimestamp = null;
            _finishedElapsedTime = _timeProvider.GetElapsedTime(start);
        }
    }

    public bool IsMoveable(uint y, uint x) =>
        GetMoveDirection(y, x) is not null;

    public bool IsDone()
    {
        for (uint i = 0; i < FieldSideSize; i++)
            for (uint j = 0; j < FieldSideSize; j++)
                if (Cells[i, j] != i * FieldSideSize + j + 1)
                    return false;
        return true;
    }

    #endregion

    // Куда сдвинется пустая клетка при нажатии на клетку (y, x), или null, если эта клетка не соседняя с пустой.
    // Пишем x + 1 == EmptyX, а не x == EmptyX - 1: при EmptyX == 0 вычитание в uint дало бы переполнение.
    private MoveDirection? GetMoveDirection(uint y, uint x)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(y, FieldSideSize);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(x, FieldSideSize);

        if (y == EmptyY && x + 1 == EmptyX) return MoveDirection.Left;
        if (y == EmptyY && x == EmptyX + 1) return MoveDirection.Right;
        if (y + 1 == EmptyY && x == EmptyX) return MoveDirection.Up;
        if (y == EmptyY + 1 && x == EmptyX) return MoveDirection.Down;
        return null;
    }
}
