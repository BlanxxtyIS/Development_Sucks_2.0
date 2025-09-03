using DevelopmentSucks.Domain.Entities;
using DevelopmentSucks.Domain.Repositories;

namespace DevelopmentSucks.Application.Services;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _repository;

    public UserRoleService(IUserRoleRepository repository)
    {
        _repository = repository;
    }

    public Task<List<UserRole>> GetAllUserRoles()
    {
        try
        {
            return _repository.GetAllUserRoles();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}
