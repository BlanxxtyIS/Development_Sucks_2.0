using DevelopmentSucks.Domain.Entities;
using DevelopmentSucks.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevelopmentSucks.Infrastructure.Persistence.Repositories;

/// <summary>
/// Репозиторий для работы с сущностью Language
/// Отвечает только за доступ к данным (CRUD) через Ef Core
/// </summary>
public class LanguagesRepository : ILanguagesRepository
{
    private readonly AppDbContext _context;

    public LanguagesRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получить список всех курсов (языков) | Read.
    /// </summary>
    /// <returns></returns>
    public async Task<List<Language>> GetAllLanguages()
    {
        var languages = await _context.Languages
            .AsNoTracking()
            .ToListAsync();

        return languages;
    }

    /// <summary>
    /// Получить курс (язык) по Id | Read.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Language?> GetLanguage(Guid id)
    {
        var language = await _context.Languages
            .FindAsync(id);

        return language;
    }

    /// <summary>
    /// Создать новый курс (язык) | Create.
    /// </summary>
    /// <param name="language"></param>
    /// <returns></returns>
    public async Task<Guid> CreateLanguage(Language language)
    {
        await _context.Languages.AddAsync(language);
        await _context.SaveChangesAsync();

        return language.Id;
    }

    /// <summary>
    /// Обновить существующий курс (язык) | Update.
    /// </summary>
    /// <param name="language"></param>
    /// <returns></returns>
    public async Task<bool> UpdateLanguage(Language language)
    {
        var updated = await _context.Languages.FindAsync(language.Id);

        if (updated == null)
        {
            return false;
        }

        updated.Title = language.Title;
        updated.Description = language.Description;
        updated.IconUrl = language.IconUrl;

        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Удалить курс (язык) по Id | Delete.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<bool> DeleteLanguage(Guid id)
    {
        var deleted = await _context.Languages
            .Where(l => l.Id == id)
            .ExecuteDeleteAsync();

        return deleted > 0;
    }
}
