using DoorsAndAdapters.Domain.Entities.Interfaces;

namespace DoorsAndAdapters.Domain.Entities;

public class Medication : Entity
{
    public Medication() { }

    public Medication(string name, DateTime time)
    {
        Name = name;
        Time = time;
    }

    public string Name { get; set; } = string.Empty;
    public DateTime Time { get; set; } = DateTime.MaxValue;
    public List<IObserver>? Observers { get; set; } = [];

    public void NotifyUsers()
    {
        if (Observers == null) return;
        Observers.ForEach(o => o.Update());
    }

    public void AddObserver(IObserver o) => Observers?.Add(o);
    public void RemoveObserver(IObserver o) => Observers?.Remove(o);


}
