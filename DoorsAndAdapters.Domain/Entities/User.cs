using DoorsAndAdapters.Domain.Entities.Interfaces;

namespace DoorsAndAdapters.Domain.Entities;

public class User : Entity, IObserver
{
    public MedicationPlan MedicationPlan { get; set; } = new();
    public Glucometer Glucometer { get; set; } = new();

    public void Update()
    {
    }
}
