using System;

namespace Puzzle15
{
    public class Puzzle
    {
        public enum MoveDirection
        {
            Up,
            Left,
            Right,
            Down
        }

        public uint[,] Cells { get; set; }
        public uint EmptyX { get; set; }
        public uint EmptyY { get; set; }
        public uint MovesCounter { get; private set; }
        public DateTime StartTime { get; private set; }

        public readonly uint EmptyCellValue = 16;
        public readonly uint FieldSideSize = 4;

        public Puzzle()
        {
            Cells = new uint[FieldSideSize, FieldSideSize];
            Init();
        }

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

        public void Move(int y, int x)
        {
            if (y == EmptyY && x == EmptyX - 1) Move(MoveDirection.Left);
            if (y == EmptyY && x == EmptyX + 1) Move(MoveDirection.Right);
            if (y == EmptyY - 1 && x == EmptyX) Move(MoveDirection.Up);
            if (y == EmptyY + 1 && x == EmptyX) Move(MoveDirection.Down);
        }

        public bool IsMoveable(int y, int x)
        {
            return
                (y == EmptyY && x == EmptyX - 1) ||
                (y == EmptyY && x == EmptyX + 1) ||
                (y == EmptyY - 1 && x == EmptyX) ||
                (y == EmptyY + 1 && x == EmptyX);
        }

        public bool IsDone()
        {
            for (int i = 0; i < FieldSideSize; i++)
                for (int j = 0; j < FieldSideSize; j++)
                    if (Cells[i, j] != i * FieldSideSize + j + 1)
                        return false;
            return true;
        }
    }
}
