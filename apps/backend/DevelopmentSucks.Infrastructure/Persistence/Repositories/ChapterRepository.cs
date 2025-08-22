using DevelopmentSucks.Domain.Entities;
using DevelopmentSucks.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevelopmentSucks.Infrastructure.Persistence.Repositories;

public class ChapterRepository : IChapterRepository
{
    private readonly AppDbContext _context;

    public ChapterRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Chapter>> GetAllChapters()
    {
        var chapters = await _context.Chapters
            .AsNoTracking()
            .ToListAsync();

        return chapters;
    }

    public async Task<Chapter?> GetChapter(Guid id)
    {
        var chapter = await _context.Chapters
            .FindAsync(id);

        return chapter;
    }

    public async Task<Guid> CreateChapter(Chapter chapter)
    {
        await _context.Chapters.AddAsync(chapter);
        await _context.SaveChangesAsync();

        return chapter.Id;
    }

    public async Task<bool> UpdateChapter(Chapter chapter)
    {
        var updated = await _context.Chapters.FindAsync(chapter.Id);

        if (updated == null)
        {
            return false;
        }

        updated.Title = chapter.Title;
        updated.Description = chapter.Description;
        updated.Order = chapter.Order;
        updated.IconUrl = chapter.IconUrl;
        updated.LanguageId = chapter.LanguageId;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteChapter(Guid id)
    {
        var deleted = await _context.Chapters
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();

        return deleted > 0;
    }
}
