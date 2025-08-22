using DevelopmentSucks.Domain.Entities;

namespace DevelopmentSucks.Domain.Repositories;

public interface ILanguagesRepository
{
    Task<Guid> CreateLanguage(Language language);
    Task<bool> DeleteLanguage(Guid id);
    Task<Language?> GetLanguage(Guid id);
    Task<List<Language>> GetAllLanguages();
    Task<bool> UpdateLanguage(Language language);
}
