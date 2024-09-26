using DoorsAndAdapters.Application.Repositories;
using DoorsAndAdapters.Domain.Entities;
using DoorsAndAdapters.Infrastructure.EntityFrameworkDataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DoorsAndAdapters.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class UserRepository(DataContext context) : IUserRepository
{
    private readonly DataContext _context = context;

    public void AddUser(User u)
    {
        _context.Users.Add(u);
        _context.SaveChanges();
    }

    public User? GetFirstUser() => _context.Users.FirstOrDefault();

    public void PatchUser(User u)
    {
        _context.Users.Attach(u);
        _context.Entry(u).State = EntityState.Modified;
        _context.SaveChanges();
    }
}
