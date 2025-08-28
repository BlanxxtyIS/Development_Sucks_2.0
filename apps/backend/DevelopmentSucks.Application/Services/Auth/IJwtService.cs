
namespace DevelopmentSucks.Application.Services.Auth
{
    public interface IJwtService
    {
        string GenerateToken(string userId, string username, IList<string> roles);
    }
}