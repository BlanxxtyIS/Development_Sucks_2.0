using DevelopmentSucks.Application.DTO;
using DevelopmentSucks.Domain.Entities;

namespace DevelopmentSucks.Application.Services;

public interface IUsersService
{
    Task<bool> DeleteUser(Guid id);
    Task<List<User>> GetAllUsers();
    Task<User?> GetUsersById(Guid id);
    Task<bool> UpdateUser(UserDto userDto);
}