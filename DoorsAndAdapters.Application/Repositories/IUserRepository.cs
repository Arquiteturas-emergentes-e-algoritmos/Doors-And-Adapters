using DoorsAndAdapters.Domain.Entities;

namespace DoorsAndAdapters.Application.Repositories;

public interface IUserRepository
{
    User AddUser(User u);
    User? GetFirstUser();
    void PatchUser(User u);
}
