namespace DevelopmentSucks.Domain.Repositories.Auth;

/// <summary>
/// Cервиса хеширования паролей.
/// </summary>
public interface IPasswordHasher
{
    /// <summary>
    /// Создать хэш из исходного пароля.
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    string Hash(string password);


    /// <summary>
    /// Проверить соответсвие пароля его хешу.
    /// </summary>
    /// <param name="hash">Хеш пароля</param>
    /// <param name="password">Открытый пароль</param>
    /// <returns>true, если пароль совпадает с хешем</returns>
    bool Verify(string hash, string password);
}
