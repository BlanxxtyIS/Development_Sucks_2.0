using DevelopmentSucks.Domain.Entities;

namespace DevelopmentSucks.Application.Services
{
    public interface IUserRoleService
    {
        Task<List<UserRole>> GetAllUserRoles();
    }
}