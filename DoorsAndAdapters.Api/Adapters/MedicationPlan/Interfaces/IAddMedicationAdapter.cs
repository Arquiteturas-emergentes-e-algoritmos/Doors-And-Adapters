using Api.Adapters.Interfaces;

namespace Api.Adapters.MedicationPlan.Interfaces;

public interface IAddMedicationAdapter : IBaseAdapter
{
    public string Name { get; set; }
    public DateTime TakeAt { get; set; }
}