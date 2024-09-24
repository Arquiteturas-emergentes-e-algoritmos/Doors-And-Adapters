namespace DoorsAndAdapters.Domain.Entities;

public class MedicationPlan : Entity
{
    public List<Medication> Medications { get; set; } = [];
}
