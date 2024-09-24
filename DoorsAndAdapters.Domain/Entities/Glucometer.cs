namespace DoorsAndAdapters.Domain.Entities;

public class Glucometer : Entity
{
    public List<GlucoseTest> GlucoseTests { get; set; } = [];

}
