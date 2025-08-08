using DevelopmentSucks.Domain.Entities;

namespace DevelopmentSucks.Application.Services
{
    public interface ILanguagesService
    {
        Task<Guid> CreateLanguage(Language language);
        Task<bool> DeleteLanguage(Guid id);
        Task<List<Language>> GetAllLanguages();
        Task<Language?> GetLanguageById(Guid id);
        Task<bool> UpdateLanguage(Language language);
    }
}