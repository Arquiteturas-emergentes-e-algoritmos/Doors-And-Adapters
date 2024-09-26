namespace DoorsAndAdapters.Domain.Entities;

public class MedicationPlan : Entity
{
    public List<Medication> Medications { get; set; } = [];
    public DateTime BeginAt { get; set; } = DateTime.UtcNow;
    public DateTime FinishAt { get; set; } = DateTime.MaxValue;
}
