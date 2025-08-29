using DevelopmentSucks.Domain.Entities;

namespace DevelopmentSucks.Domain.Repositories.Auth;

/// <summary>
/// Репозиторий для аутентификации и управления пользователями.
/// Работает с EF Core и использует PasswordHasher для проверки пароля.
/// </summary>
public interface IAuthRepository
{

    /// <summary>
    /// Проверить, существует ли пользователь с указанной почтой.
    /// </summary>
    /// <param name="email">Email пользователя</param>
    /// <returns>true, если email уже используется</returns>
    Task<bool> EmailExistsAsync(string email);

    /// <summary>
    /// Проверить, существует ли пользователь с указанным именем.
    /// </summary>
    /// <param name="username">Имя пользователя</param>
    /// <returns>true, если имя уже занято</returns>
    Task<bool> UsernameExistsAsync(string username);

    /// <summary>
    /// Создать нового пользователя.
    /// </summary>
    /// <param name="user">Сущность пользователя</param>
    /// <returns>ID созданного пользователя</returns>
    Task<Guid> CreateAsync(User user);

    /// <summary>
    /// Вход пользователя, аутентификация.
    /// Проверяет существование профиля и совпадение пароля с хешем.
    /// </summary>
    /// <param name="username">Имя пользователя</param>
    /// <param name="password">Пароль</param>
    /// <returns>Пользователя или null, если аутентификация не удалась</returns>
    Task<User?> LoginAsync(string username, string password);
}
