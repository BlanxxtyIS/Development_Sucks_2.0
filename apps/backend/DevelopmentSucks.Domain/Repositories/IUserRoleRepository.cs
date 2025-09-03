using DevelopmentSucks.Domain.Entities;

namespace DevelopmentSucks.Domain.Repositories;

public interface IUserRoleRepository
{
    Task<List<UserRole>> GetAllUserRoles();
}
