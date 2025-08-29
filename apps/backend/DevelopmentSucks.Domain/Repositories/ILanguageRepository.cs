using DevelopmentSucks.Domain.Entities;

namespace DevelopmentSucks.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностью Language
/// Отвечает только за доступ к данным (CRUD) через Ef Core
/// </summary>
public interface ILanguagesRepository
{
    /// <summary>
    /// Получить список всех курсов (языков) | Read.
    /// </summary>
    /// <returns></returns>
    Task<List<Language>> GetAllLanguages();

    /// <summary>
    /// Получить курс (язык) по Id | Read.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Language?> GetLanguage(Guid id);

    /// <summary>
    /// Создать новый курс (язык) | Create.
    /// </summary>
    /// <param name="language"></param>
    /// <returns></returns>
    Task<Guid> CreateLanguage(Language language);

    /// <summary>
    /// Обновить существующий курс (язык) | Update.
    /// </summary>
    /// <param name="language"></param>
    /// <returns></returns>
    Task<bool> UpdateLanguage(Language language);

    /// <summary>
    /// Удалить курс (язык) по Id | Delete.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteLanguage(Guid id);
}
