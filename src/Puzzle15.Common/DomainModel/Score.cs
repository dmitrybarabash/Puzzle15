using System;

namespace Puzzle15.DomainModel;

[Serializable]
public class Score : IComparable<Score>, IEquatable<Score>
{
    public string Name { get; set; }
    public uint Moves { get; set; }
    public TimeSpan Timer { get; set; }


    #region IComparable<Score> implementation

    public int CompareTo(Score other)
    {
        if (Moves < other.Moves) return -1;
        if (Moves > other.Moves) return 1;
        if (Timer < other.Timer) return -1;
        if (Timer > other.Timer) return 1;
        return 0;
    }

    #endregion


    //
    // Методы сравнения здесь используются только для
    // удобства модульного тестирования класса Score
    //

    #region IEquatable<Score> implementation

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

    #endregion


    #region Mandatory overrides to implement consistent behavior of equality

    // From here: https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals#notes-to-implementers
    //
    // If you implement Equals(T), you should also override the base class implementations of Equals(object)
    // and GetHashCode() so that their behavior is consistent with that of the Equals(T) method.If you do
    // override Equals(object), your overridden implementation is also called in calls to the static
    // Equals(object, object) method on your class. In addition, you should overload the op_Equality (==)
    // and op_Inequality (!=) operators. This ensures that all tests for equality return consistent results.

    public override bool Equals(object other)
    {
        if (other is null) return false;
        if (object.ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;
        return Equals(other as Score);
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

    public static bool operator ==(Score left, Score right) =>
        ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.Equals(right);

    public static bool operator !=(Score left, Score right) =>
        !(left == right);

    #endregion


    #region Not mandatory and not used in the application at all, but the rest part of consistent behavior implementation of equality

    public static bool operator <(Score left, Score right) =>
        ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;

    public static bool operator <=(Score left, Score right) =>
        ReferenceEquals(left, null) || left.CompareTo(right) <= 0;

    public static bool operator >(Score left, Score right) =>
        !ReferenceEquals(left, null) && left.CompareTo(right) > 0;

    public static bool operator >=(Score left, Score right) =>
        ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;

    #endregion
}
