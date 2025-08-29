namespace DevelopmentSucks.Domain.Repositories.Auth;

/// <summary>
/// Репозиторий для генерации JWT-токенов.
/// Формирует claims, подписывает токен и возвращает строковое представление.
/// </summary>
public interface IJwtRepository
{

    /// <summary>
    /// Сгенерировать JWT-токен для пользователя.
    /// </summary>
    /// <param name="userId">ID пользователя</param>
    /// <param name="username">Имя пользователя</param>
    /// <param name="roles">Список ролей пользователя</param>
    /// <returns>JWT-токен в виде строки</returns>
    string GenerateToken(string userId, string username, IList<string> roles);
}
