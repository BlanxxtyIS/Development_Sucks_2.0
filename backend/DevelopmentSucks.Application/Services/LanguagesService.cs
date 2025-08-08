using DevelopmentSucks.Domain.Entities;
using DevelopmentSucks.Domain.Repositories;

namespace DevelopmentSucks.Application.Services;

public class LanguagesService : ILanguagesService
{
    private readonly ILanguagesRepository _repository;

    public LanguagesService(ILanguagesRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Language>> GetAllLanguages()
    {
        try
        {
            return await _repository.GetAllLanguages();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex} - ERROR LANGUAGE");
            throw;
        }
    }

    public async Task<Language?> GetLanguageById(Guid id)
    {
        try
        {
            return await _repository.GetLanguage(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex} - ERROR LANGUAGE");
            throw;
        }
    }

    public async Task<Guid> CreateLanguage(Language language)
    {
        try
        {
            return await _repository.CreateLanguage(language);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex} - ERROR LANGUAGE");
            throw;
        }
    }

    public async Task<bool> UpdateLanguage(Language language)
    {
        try
        {
            return await _repository.UpdateLanguage(language);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<bool> DeleteLanguage(Guid id)
    {
        try
        {
            return await _repository.DeleteLanguage(id);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
