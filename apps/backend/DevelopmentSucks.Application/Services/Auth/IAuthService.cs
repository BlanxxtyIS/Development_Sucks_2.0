using DevelopmentSucks.Application.DTO;

namespace DevelopmentSucks.Application.Services.Auth;

public interface IAuthService
{
    Task<(bool Success, string? Error, Guid? UserId)> RegisterAsync(UserDto request);
}