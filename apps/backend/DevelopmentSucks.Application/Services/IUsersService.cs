using DevelopmentSucks.Domain.Entities;

namespace DevelopmentSucks.Application.Services
{
    public interface IUsersService
    {
        Task<Guid> CreateUser(User user);
        Task<bool> DeleteUser(Guid id);
        Task<List<User>> GetAllUsers();
        Task<User?> GetUsersById(Guid id);
        Task<bool> UpdateUser(User user);
    }
}