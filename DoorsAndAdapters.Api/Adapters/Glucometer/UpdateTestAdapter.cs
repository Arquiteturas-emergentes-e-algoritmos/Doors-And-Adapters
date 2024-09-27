using Api.Adapters.Glucometer.Interfaces;

namespace Api.Adapters.Glucometer;

public class UpdateTestAdapter : IUpdateTestAdapter
{
    public ushort Value { get; set; }
    public DateTime Time { get; set; } = DateTime.UtcNow;

    public bool Validate()
    {
        if (Time == DateTime.MinValue || Value == 0) return false;
        return true;
    }
}