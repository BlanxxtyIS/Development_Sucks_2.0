using DevelopmentSucks.Domain.Entities;

namespace DevelopmentSucks.Application.Services;

public interface IChaptersService
{
    Task<Guid> CreateChapter(Chapter chapter);
    Task<bool> DeleteChapter(Guid id);
    Task<List<Chapter>> GetAllChapters();
    Task<Chapter?> GetChapterById(Guid id);
    Task<bool> UpdateChapter(Chapter chapter);
}