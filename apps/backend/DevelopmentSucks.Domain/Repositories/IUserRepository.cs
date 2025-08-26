using DevelopmentSucks.Domain.Entities;

namespace DevelopmentSucks.Domain.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllUsers();
    Task<User?> GetUser(Guid id);
    Task<bool> DeleteUser(Guid id);
    Task<bool> UpdateUser(User user);
}
