using DevelopmentSucks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevelopmentSucks.Infrastructure.Persistence.Repositories;

public class LanguagesRepository : ILanguagesRepository
{
    private readonly AppDbContext _context;

    public LanguagesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Language>> GetLanguages()
    {
        var languages = await _context.Languages
            .AsNoTracking()
            .ToListAsync();

        return languages;
    }

    public async Task<Language?> GetLanguage(Guid id)
    {
        var language = await _context.Languages
            .FindAsync(id);

        return language;
    }

    public async Task<Guid> CreateLanguage(Language language)
    {
        await _context.Languages.AddAsync(language);
        await _context.SaveChangesAsync();

        return language.Id;
    }

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

    public async Task<bool> DeleteLanguage(Guid id)
    {
        var deleted = await _context.Languages
            .Where(l => l.Id == id)
            .ExecuteDeleteAsync();

        return deleted > 0;
    }
}
