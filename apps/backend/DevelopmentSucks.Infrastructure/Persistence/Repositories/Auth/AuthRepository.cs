using DevelopmentSucks.Domain.Entities;
using DevelopmentSucks.Domain.Repositories.Auth;
using Microsoft.EntityFrameworkCore;

namespace DevelopmentSucks.Infrastructure.Persistence.Repositories.Auth;

public class AuthRepository : IAuthRepository
{
    private readonly AppDbContext _context;
    private readonly IPasswordHasher _hasher;

    public AuthRepository(AppDbContext context, 
        IPasswordHasher hasher)
    {
        _context = context;
        _hasher = hasher;
    }

    public Task<bool> EmailExistsAsync(string email)
    {
       return _context.Users.AnyAsync(u => u.Email == email);
    }

    public Task<bool> UsernameExistsAsync(string username)
    {
        return _context.Users.AnyAsync(u => u.Username == username);
    }


    public async Task<Guid> CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }

    public async Task<User?> LoginAsync(string username, string password)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == username);

        if (user == null)
        {
            return null;
        }

        return _hasher.Verify(user.PasswordHash, password) ? user : null;
    }
}
