using DoorsAndAdapters.Domain.ValueObjects;

namespace DoorsAndAdapters.Application.UseCases;

public interface IGlucometerUseCase
{
    void AddTest(GlucoseTest test);
    void UpdateTest(GlucoseTest test);
    void DeleteTests(GlucoseTest test);
    List<GlucoseTest> GetAllTest();
}
