using DoorsAndAdapters.Domain.ValueObjects;

namespace DoorsAndAdapters.Application.UseCases;

public interface IGlucometerUseCase
{
    void AddTest(GlucoseTest test);
    void UpdateTest(GlucoseTest test);
    void DeleteTest(Guid Id);
    List<GlucoseTest> GetAllTests();
}
