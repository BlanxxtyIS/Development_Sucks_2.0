using DevelopmentSucks.Domain.Entities;

namespace DevelopmentSucks.Domain.Repositories;

public interface IChapterRepository
{
    Task<Guid> CreateChapter(Chapter chapter);
    Task<bool> DeleteChapter(Guid id);
    Task<List<Chapter>> GetAllChapters();
    Task<Chapter?> GetChapter(Guid id);
    Task<bool> UpdateChapter(Chapter chapter);
}
