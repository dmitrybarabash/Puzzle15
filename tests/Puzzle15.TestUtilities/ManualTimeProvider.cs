using System;

namespace Puzzle15.TestUtilities;

// TimeProvider для тестов: время идёт, только когда вызывают Advance
public class ManualTimeProvider : TimeProvider
{
    private long _timestamp;

    public override long TimestampFrequency => TimeSpan.TicksPerSecond;

    public override long GetTimestamp() => _timestamp;

    public void Advance(TimeSpan time) => _timestamp += time.Ticks;
}
