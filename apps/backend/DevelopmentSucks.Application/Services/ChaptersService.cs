using DevelopmentSucks.Domain.Entities;
using DevelopmentSucks.Domain.Repositories;

namespace DevelopmentSucks.Application.Services;

public class ChaptersService : IChaptersService
{
    private readonly IChapterRepository _repository;

    public ChaptersService(IChapterRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Chapter>> GetAllChapters()
    {
        try
        {
            return await _repository.GetAllChapters();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex} - ERROR GET ALL CHAPTERS");
            throw;
        }
    }

    public async Task<Chapter?> GetChapterById(Guid id)
    {
        try
        {
            return await _repository.GetChapter(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex} - ERROR GET ONE CHAPTER");
            throw;
        }
    }

    public async Task<Guid> CreateChapter(Chapter chapter)
    {
        try
        {
            return await _repository.CreateChapter(chapter);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex} - ERROR CREATE CHAPTER");
            throw;
        }
    }

    public async Task<bool> UpdateChapter(Chapter chapter)
    {
        try
        {
            return await _repository.UpdateChapter(chapter);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex} - ERROR UPDATE CHAPTER");
            throw;
        }
    }

    public async Task<bool> DeleteChapter(Guid id)
    {
        try
        {
            return await _repository.DeleteChapter(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex} - ERROR DELETE CHAPTER");
            throw;
        }
    }
}

