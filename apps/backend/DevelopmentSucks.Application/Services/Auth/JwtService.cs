using DevelopmentSucks.Domain.Repositories.Auth;

namespace DevelopmentSucks.Application.Services.Auth;

public class JwtService : IJwtService
{
    private readonly IJwtRepository _repository;

    public JwtService(IJwtRepository repository)
    {
        _repository = repository;
    }

    public string GenerateToken(string userId, string username, IList<string> roles)
    {
        return _repository.GenerateToken(userId, username, roles);
    }
}
