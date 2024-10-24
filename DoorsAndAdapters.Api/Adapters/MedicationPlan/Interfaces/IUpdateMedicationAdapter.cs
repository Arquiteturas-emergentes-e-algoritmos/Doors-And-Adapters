using Api.Adapters.Interfaces;
using System.Text.Json.Serialization;

namespace Api.Adapters.MedicationPlan.Interfaces;

public interface IUpdateMedicationAdapter : IBaseAdapter
{
    [JsonRequired] public string Name { get; set; }
    [JsonRequired] public DateTime TakeAt { get; set; }
}