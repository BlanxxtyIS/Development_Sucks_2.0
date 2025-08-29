using DevelopmentSucks.Domain.Entities;

namespace DevelopmentSucks.Application.Services;

/// <summary>
/// Сервис для работы с сущностью Language
/// Отвечает за бизнес-логику и взаимодействие с репозиторием.
/// </summary>
public interface ILanguagesService
{
    /// <summary>
    /// Создать новый курс (язык).
    /// </summary>
    /// <param name="language">Новая сущность языка</param>
    /// <returns>Идентификатор созданного языка</returns>
    Task<Guid> CreateLanguage(Language language);

    /// <summary>
    /// Получить список всех курсов (языков).
    /// </summary>
    /// <returns>Список языков</returns>
    Task<List<Language>> GetAllLanguages();

    /// <summary>
    /// Получить курс (язык) по Id.
    /// </summary>
    /// <param name="id">Идентификатор языка</param>
    /// <returns>Сущность языка или null, если не найден</returns>
    Task<Language?> GetLanguageById(Guid id);

    /// <summary>
    /// Обновить существующий курс (язык).
    /// </summary>
    /// <param name="language">Изменённая сущность языка</param>
    /// <returns>true, если обновление прошло успешно</returns>
    Task<bool> UpdateLanguage(Language language);

    /// <summary>
    /// Удалить курс (язык) по Id.
    /// </summary>
    /// <param name="id">Идентификатор языка</param>
    /// <returns>true, если удаление прошло успешно</returns>
    Task<bool> DeleteLanguage(Guid id);
}