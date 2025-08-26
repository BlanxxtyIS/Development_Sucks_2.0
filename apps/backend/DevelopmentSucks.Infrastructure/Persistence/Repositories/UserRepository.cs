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

    public async Task<bool> UpdateUser(User user)
    {
        var updated = await _context.Users.FindAsync(user.Id);

        if (updated == null)
        {
            return false;
        }

        var emailExists = await _context.Users
            .AnyAsync(u => u.Email == user.Email && u.Id != user.Id);

        var usernameExists = await _context.Users
            .AnyAsync(u => u.Username == user.Username && u.Id != user.Id);

        if (emailExists || usernameExists)
        {
            throw new InvalidOperationException("Пользователь с таким email или username уже существует");
        }

        updated.Email = user.Email;
        updated.Username = user.Username;
        updated.UserRoleId = user.UserRoleId;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        var deleted = await _context.Users
            .Where(u => u.Id == id)
            .ExecuteDeleteAsync();

        return deleted > 0;
    }
}

