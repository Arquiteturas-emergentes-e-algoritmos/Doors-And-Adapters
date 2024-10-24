using DoorsAndAdapters.Application.Repositories;
using DoorsAndAdapters.Domain.Entities;

namespace DoorsAndAdapters.Application.Service;

public abstract class BaseService(IUserRepository userRepository)
{
    protected readonly IUserRepository _userRepository = userRepository;

    protected User GetUser()
    {
        User? user = userRepository.GetFirstUser();
        user ??= _userRepository.AddUser(new User());
        return user;
    }
}
