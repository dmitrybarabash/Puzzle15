using System;

namespace Puzzle15.Wpf.Mvvm.UnitTests.Fakes;

// Время идет только тогда, когда его двигает сам тест
public class ManualTimeProvider : TimeProvider
{
    private long _timestamp;

    public override long TimestampFrequency => TimeSpan.TicksPerSecond;

    public override long GetTimestamp() => _timestamp;

    public void Advance(TimeSpan time) => _timestamp += time.Ticks;
}
