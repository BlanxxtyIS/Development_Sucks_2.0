using DevelopmentSucks.Domain.Entities;

namespace DevelopmentSucks.Domain.Repositories;

public interface ILessonRepository
{
    Task<Guid> CreateLesson(Lesson lesson);
    Task<bool> DeleteLesson(Guid id);
    Task<List<Lesson>> GetAllLessons();
    Task<Lesson?> GetLesson(Guid id);
    Task<bool> UpdateLesson(Lesson lesson);
}
