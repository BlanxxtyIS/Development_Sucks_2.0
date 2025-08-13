using DevelopmentSucks.Domain.Entities;
using DevelopmentSucks.Domain.Repositories;

namespace DevelopmentSucks.Application.Services;

public class LessonsService : ILessonsService
{
    private readonly ILessonRepository _repository;

    public LessonsService(ILessonRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Lesson>> GetAllLessons()
    {
        try
        {
            return await _repository.GetAllLessons();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex} - ERROR GET ALL LESSONS");
            throw;
        }
    }

    public async Task<Lesson?> GetLessonById(Guid id)
    {
        try
        {
            return await _repository.GetLesson(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex} - ERROR GET LESSON");
            throw;
        }
    }

    public async Task<Guid> CreateLesson(Lesson lesson)
    {
        try
        {
            return await _repository.CreateLesson(lesson);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex} - ERROR CREATE LESSON");
            throw;
        }
    }

    public async Task<bool> UpdateLesson(Lesson lesson)
    {
        try
        {
            return await _repository.UpdateLesson(lesson);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex} - ERROR UPDATE LESSON");
            throw;
        }
    }

    public async Task<bool> DeleteLesson(Guid id)
    {
        try
        {
            return await _repository.DeleteLesson(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex} - ERROR DELETE LESSON");
            throw;
        }
    }
}
