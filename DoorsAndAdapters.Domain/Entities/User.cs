using DoorsAndAdapters.Domain.Entities.Interfaces;

namespace DoorsAndAdapters.Domain.Entities;

public class User : Entity, IObserver
{
    public List<MedicationPlan> MedicationPlan { get; set; } = [];
    public Glucometer Glucometer { get; set; } = new();

    public void Update()
    {
        throw new NotImplementedException();
    }
}
