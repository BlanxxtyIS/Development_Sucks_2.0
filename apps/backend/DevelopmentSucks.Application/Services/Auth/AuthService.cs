using DevelopmentSucks.Application.DTO;
using DevelopmentSucks.Domain.Entities;
using DevelopmentSucks.Domain.Repositories.Auth;

namespace DevelopmentSucks.Application.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _repository;
    private readonly IPasswordHasher _hasher;
    private readonly IJwtRepository _jwtRepository;

    public AuthService(IAuthRepository repository, 
        IPasswordHasher passwordHasher,
        IJwtRepository jwtRepository)
    {
        _repository = repository;
        _hasher = passwordHasher;
        _jwtRepository = jwtRepository;
    }

    public async Task<(bool Success, string? Error, Guid? UserId)> RegisterAsync(UserDto request)
    {
        var email = (request.Email ?? string.Empty);
        var username = (request.Username ?? string.Empty);
        var password = (request.Password ?? string.Empty);

        var emailRequest = await _repository.EmailExistsAsync(email);
        if (emailRequest)
        {
            return (false, "Email уже используется", null);
        }

        var usernameRequest = await _repository.UsernameExistsAsync(username);
        if (usernameRequest)
        {
            return (false, "Username уже используется", null);
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            Username = username,
            PasswordHash = _hasher.Hash(password),
            CreatedAt = DateTime.UtcNow,
            UserRoleId = new Guid("a311bcfa-b6e7-4d93-93b1-0974253a031a")
        };

        try
        {
            var id = await _repository.CreateAsync(user);
            return (true, null, id);
        }
        catch (Exception ex)
        {
            // ⚡️ Тут лучше залогировать ошибку для разработчика
            // _logger.LogError(ex, "Ошибка при регистрации пользователя");

            return (false, "Ошибка при сохранении пользователя. Попробуйте позже.", null);
        }
    }

    public async Task<(bool Success, string? Error, string? Token)> LoginAsync(string username, string password)
    {
        var user = await _repository.LoginAsync(username, password);

        if (user == null)
        {
            return (false, "Неверный логин или пароль", null);
        }

        var roles = new List<string> { "Student" };

        var token = _jwtRepository.GenerateToken(user.Id.ToString(), user.Username, roles);

        return (true, null, token);
    }
}
