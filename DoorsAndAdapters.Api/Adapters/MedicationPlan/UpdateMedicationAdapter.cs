using Api.Adapters.MedicationPlan.Interfaces;

namespace Api.Adapters.MedicationPlan;

public class UpdateMedicationAdapter : IUpdateMedicationAdapter
{
    public string Name { get; set; } = string.Empty;
    public DateTime TakeAt { get; set; } = DateTime.MinValue;

    public bool Validate()
    {
        if (string.IsNullOrEmpty(Name) || (TakeAt == DateTime.MinValue)) return false;
        return true;
    }
}