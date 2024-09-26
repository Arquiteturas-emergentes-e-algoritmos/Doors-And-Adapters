namespace DoorsAndAdapters.Domain.ValueObjects;

public abstract class ValueObject
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
