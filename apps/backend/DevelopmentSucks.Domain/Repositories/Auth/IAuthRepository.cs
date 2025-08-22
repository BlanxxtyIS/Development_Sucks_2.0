using DevelopmentSucks.Domain.Entities;

namespace DevelopmentSucks.Domain.Repositories.Auth;

public interface IAuthRepository
{
    Task<bool> EmailExistsAsync(string email);
    Task<bool> UsernameExistsAsync(string username);
    Task<Guid> CreateAsync(User user);
}
