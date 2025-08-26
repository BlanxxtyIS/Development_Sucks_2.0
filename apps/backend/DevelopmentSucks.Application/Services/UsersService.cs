using DevelopmentSucks.Domain.Entities;
using DevelopmentSucks.Domain.Repositories;

namespace DevelopmentSucks.Application.Services;

public class UsersService : IUsersService
{
    private readonly IUserRepository _repository;

    public UsersService(IUserRepository repository)
    {
        _repository = repository;
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

    public async Task<Guid> CreateUser(User user)
    {
        try
        {
            return await _repository.CreateUser(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex} - ERROR CREATE USER");
            throw;
        }
    }

    public async Task<bool> UpdateUser(User user)
    {
        try
        {
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
