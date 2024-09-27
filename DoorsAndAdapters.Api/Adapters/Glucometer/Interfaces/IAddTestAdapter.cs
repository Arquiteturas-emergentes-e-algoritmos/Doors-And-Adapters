using Api.Adapters.Interfaces;

namespace Api.Adapters.Glucometer.Interfaces;

public interface IAddTestAdapter : IBaseAdapter
{
    public ushort Value { get; set; }
    public DateTime Time { get; set; }
}