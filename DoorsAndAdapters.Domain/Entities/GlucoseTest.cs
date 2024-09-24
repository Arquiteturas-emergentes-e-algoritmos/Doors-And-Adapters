namespace DoorsAndAdapters.Domain.Entities;

public class GlucoseTest : Entity
{
    public GlucoseTest(ushort value)
    {
        Value = value;
    }

    public ushort Value { get; set; } = 100;
    public DateTime Time { get; set; } = DateTime.UtcNow;
}
