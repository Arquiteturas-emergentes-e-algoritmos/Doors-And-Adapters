using Api.Adapters.Glucometer.Interfaces;

namespace Api.Adapters.Glucometer;

public class AddTestAdapter : IAddTestAdapter
{
    public ushort Value { get; set; } = 0;
    public DateTime Time { get; set; } = DateTime.MinValue;

    public bool Validate()
    {
        if (Time == DateTime.MinValue || Value == 0) return false;
        return true;
    }
}