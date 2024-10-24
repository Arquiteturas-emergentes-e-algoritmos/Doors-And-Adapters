using Api.Adapters.Interfaces;
using System.Text.Json.Serialization;

namespace Api.Adapters.Glucometer.Interfaces;

public interface IAddTestAdapter : IBaseAdapter
{
    [JsonRequired] public ushort Value { get; set; }
    [JsonRequired] public DateTime Time { get; set; }
}