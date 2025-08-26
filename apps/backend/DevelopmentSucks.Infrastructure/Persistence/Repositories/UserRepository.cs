using DevelopmentSucks.Domain.Entities;
using DevelopmentSucks.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevelopmentSucks.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllUsers()
    {
        var users = await _context.Users
            .AsNoTracking()
            .ToListAsync();

        return users;
    }

    public async Task<User?> GetUser(Guid id)
    {
        var user = await _context.Users.
            FindAsync(id);

        return user;
    }

    public async Task<Guid> CreateUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user.Id;
    }

    public async Task<bool> UpdateUser(User user)
    {
        var updated = await _context.Users.FindAsync(user.Id);

        if (updated == null)
        {
            return false;
        }

        updated.Email = user.Email;
        updated.Username = user.Username;
        updated.UserRoleId = user.UserRoleId;

        await _context.SaveChangesAsync();
        return false;
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        var deleted = await _context.Users
            .Where(u => u.Id == id)
            .ExecuteDeleteAsync();

        return deleted > 0;
    }
}

