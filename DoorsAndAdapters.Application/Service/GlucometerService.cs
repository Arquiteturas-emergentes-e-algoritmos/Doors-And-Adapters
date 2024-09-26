using DoorsAndAdapters.Application.Repositories;
using DoorsAndAdapters.Application.UseCases;
using DoorsAndAdapters.Domain.Entities;
using DoorsAndAdapters.Domain.ValueObjects;

namespace DoorsAndAdapters.Application.Service;

public class GlucometerService(IUserRepository userRepository) : IGlucometerUseCase
{
    public void AddTest(GlucoseTest test)
    {
        User? user = userRepository.GetFirstUser();
        if (user == null)
        {
            user = new();
            userRepository.AddUser(user);
        }
        user.Glucometer.AddTest(test);
        userRepository.PatchUser(user);
    }

    public void DeleteTest(GlucoseTest test)
    {
        User? user = userRepository.GetFirstUser();
        if (user == null)
            return;
        user.Glucometer.DeleteTest(test);
        userRepository.PatchUser(user);
    }

    public List<GlucoseTest> GetAllTests()
    {
        User? user = userRepository.GetFirstUser();
        return user == null ? [] : user.Glucometer.GlucoseTests;
    }

    public void UpdateTest(GlucoseTest test)
    {
        User? user = userRepository.GetFirstUser();
        if (user == null)
            return;
        user.Glucometer.UpdateTest(test);
        userRepository.PatchUser(user);
    }
}
