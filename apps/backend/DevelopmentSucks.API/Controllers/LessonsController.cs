using DevelopmentSucks.Application.DTO;
using DevelopmentSucks.Application.Services;
using DevelopmentSucks.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentSucks.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LessonsController: ControllerBase
{
    private readonly ILessonsService _service;

    public LessonsController(ILessonsService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Lesson>>> GetLessons()
    {
        var lessons = await _service.GetAllLessons();

        return lessons.Any() ? Ok(lessons) : NotFound(new ErrorResponse
        {
            StatusCode = 404,
            Message = "Уроки пустые"
        });
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Lesson>> GetLessonById(Guid id)
    {
        var lesson = await _service.GetLessonById(id);

        return lesson != null ? Ok(lesson) : NotFound(new ErrorResponse
        {
            StatusCode = 404,
            Message = "Урока с таким ID не существует"
        });
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateLesson([FromBody] LessonDto dto)
    {
        if (dto == null)
        {
            return BadRequest("Объект пустой");
        }

        var lesson = new Lesson
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Content = dto.Content,
            ChapterId = dto.ChapterId,
            Order = dto.Order,
        };

        var createdLesson = await _service.CreateLesson(lesson);

        return CreatedAtAction(
            nameof(GetLessonById),
            new { id = createdLesson },
            createdLesson
        );
    }

    [HttpPut]
    public async Task<ActionResult> UpdateLesson([FromBody] LessonDto dto)
    {
        if (dto.Id == null )
        {
            return BadRequest("Объект пустой");
        }

        var lesson = new Lesson
        {
            Id = dto.Id.Value,
            Title = dto.Title,
            Content = dto.Content,
            ChapterId = dto.ChapterId,
            Order = dto.Order,
        };

        var updatedLesson = await _service.UpdateLesson(lesson);

        return updatedLesson ? NoContent() : NotFound(new ErrorResponse
        {
            StatusCode = 404,
            Message = "Ошибка при создании курса"
        });
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteLesson(Guid id)
    {
        var deleted = await _service.DeleteLesson(id);
        return deleted ? NoContent() : NotFound(new ErrorResponse
        {
            StatusCode = 404,
            Message = "Ошибка при удалении курса"
        });
    }
}
