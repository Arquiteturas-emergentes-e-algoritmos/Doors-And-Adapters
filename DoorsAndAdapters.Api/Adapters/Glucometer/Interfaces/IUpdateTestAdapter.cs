using Api.Adapters.Interfaces;
using System.Text.Json.Serialization;

namespace Api.Adapters.Glucometer.Interfaces;

public interface IUpdateTestAdapter : IBaseAdapter
{
    [JsonRequired] public ushort Value { get; set; }
    [JsonRequired] public DateTime Time { get; set; }
}