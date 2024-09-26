using DoorsAndAdapters.Domain.Entities;

namespace DoorsAndAdapters.Application.UseCases;

public interface IGlucometerUseCase
{
    void AddTest(GlucoseTest test);
    void UpdateTest(GlucoseTest test);
    void DeleteTest(GlucoseTest test);
    List<GlucoseTest> GetAllTest();
}
