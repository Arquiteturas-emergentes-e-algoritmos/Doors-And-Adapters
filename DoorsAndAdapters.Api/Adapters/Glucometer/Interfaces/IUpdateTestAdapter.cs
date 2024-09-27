using Api.Adapters.Interfaces;

namespace Api.Adapters.Glucometer.Interfaces;

public interface IUpdateTestAdapter : IBaseAdapter
{
    public ushort Value { get; set; }
    public DateTime Time { get; set; }
}