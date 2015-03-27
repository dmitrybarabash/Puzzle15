using System;

namespace Puzzle15.DomainModel
{
    [Serializable]
    public class Score : IComparable<Score>
    {
        public string Name { get; set; }
        public uint Moves { get; set; }
        public TimeSpan Timer { get; set; }

        public int CompareTo(Score other)
        {
            if (Moves < other.Moves) return -1;
            if (Moves > other.Moves) return 1;
            if (Timer < other.Timer) return -1;
            if (Timer > other.Timer) return 1;
            return 0;
        }
    }
}