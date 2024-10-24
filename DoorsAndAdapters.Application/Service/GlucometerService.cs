using DoorsAndAdapters.Application.Repositories;
using DoorsAndAdapters.Application.UseCases;
using DoorsAndAdapters.Domain.ValueObjects;

namespace DoorsAndAdapters.Application.Service;

public class GlucometerService(IUserRepository userRepository) : BaseService(userRepository), IGlucometerUseCase
{

    public void AddTest(GlucoseTest test)
    {
        var user = GetUser();
        user.Glucometer.AddTest(test);
        userRepository.PatchUser(user);
    }

    public void DeleteTest(Guid Id)
    {
        var user = GetUser();

        var test = user.Glucometer.GlucoseTests.Find(x => x.Id == Id);
        if (test == null)
            return;

        user.Glucometer.DeleteTest(test.Id);
        userRepository.PatchUser(user);
    }

    public List<GlucoseTest> GetAllTests() => GetUser().Glucometer.GlucoseTests;


    public void UpdateTest(GlucoseTest test)
    {
        var user = GetUser();
        user.Glucometer.UpdateTest(test);
        userRepository.PatchUser(user);
    }
}
