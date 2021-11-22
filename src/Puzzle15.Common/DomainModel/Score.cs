using System;

namespace Puzzle15.DomainModel;

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

    //
    // Методы Equals здесь только для удобства
    // модульного тестирования класса Score
    //

    public override bool Equals(object other)
    {
        if (other is null) return false;
        if (object.ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;
        return Equals(other as Score);
    }

    public bool Equals(Score other)
    {
        if (other is null) return false;
        if (object.ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;
        return
            string.Compare(Name, other.Name, StringComparison.CurrentCulture) == 0 &&
            Moves.Equals(other.Moves) &&
            Timer.Equals(other.Timer);
    }

    public override int GetHashCode()
    {
        //
        // Классический вариант из Рихтера
        //
        //unchecked
        //{
        //    return ((int)Moves * 397) ^ (int)Timer.TotalSeconds;
        //}

        //
        // Используем класс HashCode, добавленный в .NET Core 2.1
        //
        return HashCode.Combine(Moves, Timer.TotalSeconds);
    }
}
