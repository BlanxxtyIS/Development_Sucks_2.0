﻿using DevelopmentSucks.Domain.Entities;

namespace DevelopmentSucks.Application.Services
{
    public interface ILessonsService
    {
        Task<Guid> CreateLesson(Lesson lesson);
        Task<bool> DeleteLesson(Guid id);
        Task<List<Lesson>> GetAllLessons();
        Task<Lesson?> GetLessonById(Guid id);
        Task<bool> UpdateLesson(Lesson lesson);
    }
}