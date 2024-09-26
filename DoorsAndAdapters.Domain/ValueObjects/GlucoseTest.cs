namespace DoorsAndAdapters.Domain.ValueObjects;

public class GlucoseTest : ValueObject
{
    public GlucoseTest(ushort value)
    {
        Value = value;
    }

    public ushort Value { get; set; } = 100;
    public DateTime Time { get; set; } = DateTime.UtcNow;
}
