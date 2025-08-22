using DevelopmentSucks.Application.DTO.Users;

namespace DevelopmentSucks.Application.Services.Auth;

public interface IAuthService
{
    Task<(bool Success, string? Error, Guid? UserId)> RegisterAsync(RegisterUserRequest request);
}