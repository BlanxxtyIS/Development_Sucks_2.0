namespace DevelopmentSucks.Infrastructure.Persistence.Repositories.Auth;

/// <summary>
/// Настройки JWT-токена.
/// Хранится в конфигурации (appsettings.json) 
/// </summary>
public class JwtSettings
{
    /// <summary>Ключ для подписи токена</summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>Эмитент токена</summary>
    public string Issuer { get; set; } = string.Empty;

    /// <summary>Получатель токена</summary>
    public string Audience { get; set; } = string.Empty;

    /// <summary>Вреия жизни токена в минутах</summary>
    public int DurationInMinutes { get; set; }
}
