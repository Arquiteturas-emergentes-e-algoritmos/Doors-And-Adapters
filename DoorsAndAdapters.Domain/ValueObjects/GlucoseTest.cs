﻿namespace DoorsAndAdapters.Domain.ValueObjects;

public class GlucoseTest : ValueObject
{
    public GlucoseTest() { }
    public GlucoseTest(ushort value)
    {
        Value = value;
    }

    public GlucoseTest(ushort value, DateTime time)
    {
        Value = value;
        Time = time;
    }

    public ushort Value { get; set; } = 100;
    public DateTime Time { get; set; } = DateTime.UtcNow;
}
