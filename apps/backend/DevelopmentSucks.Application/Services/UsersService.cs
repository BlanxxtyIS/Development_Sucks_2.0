using DevelopmentSucks.Application.DTO;
using DevelopmentSucks.Domain.Entities;
using DevelopmentSucks.Domain.Repositories;
using DevelopmentSucks.Domain.Repositories.Auth;

namespace DevelopmentSucks.Application.Services;

public class UsersService : IUsersService
{
    private readonly IUserRepository _repository;
    private readonly IPasswordHasher _hasher;

    public UsersService(IUserRepository repository,
        IPasswordHasher hasher)
    {
        _repository = repository;
        _hasher = hasher;
    }

    public async Task<List<User>> GetAllUsers()
    {
        try
        {
            return await _repository.GetAllUsers();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex} - ERROR GET ALL USERS");
            throw;
        }
    }

    public async Task<User?> GetUsersById(Guid id)
    {
        try
        {
            return await _repository.GetUser(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex} - ERROR GET USER");
            throw;
        }
    }

    public async Task<bool> UpdateUser(UserDto userDto)
    {
        try
        {
            var user = new User
            {
                Id = userDto.Id.Value,
                Email = userDto.Email,
                Username = userDto.Username,
                PasswordHash = _hasher.Hash(userDto.Password),
                UserRoleId = new Guid("a311bcfa-b6e7-4d93-93b1-0974253a031a")
            };

            return await _repository.UpdateUser(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex} - ERROR UPDATE USER");
            throw;
        }
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        try
        {
            return await _repository.DeleteUser(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex} - ERROR DELETE USER");
            throw;
        }
    }
}
