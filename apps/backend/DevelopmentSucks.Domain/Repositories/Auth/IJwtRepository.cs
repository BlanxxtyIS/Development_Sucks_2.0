namespace DevelopmentSucks.Domain.Repositories.Auth;

public interface IJwtRepository
{
    string GenerateToken(string userId, string username, IList<string> roles);
}
