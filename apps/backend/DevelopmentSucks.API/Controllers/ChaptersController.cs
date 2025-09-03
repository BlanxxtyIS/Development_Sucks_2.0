using DevelopmentSucks.Application.DTO;
using DevelopmentSucks.Application.Services;
using DevelopmentSucks.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentSucks.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChaptersController: ControllerBase
{
    private readonly IChaptersService _service;

    public ChaptersController(IChaptersService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Chapter>>> GetChapters()
    {
        var chapters = await _service.GetAllChapters();

        return chapters.Any() ? Ok(chapters) : NotFound(new ErrorResponse
        {
            StatusCode = 404,
            Message = "Главы пустые"
        });
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Chapter>> GetChapterById(Guid id)
    {
        var chapter = await _service.GetChapterById(id);

        return chapter != null ? Ok(chapter) : NotFound(new ErrorResponse
        {
            StatusCode = 404,
            Message = "Главы с таким ID не существет"
        });
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateChapter([FromBody] ChapterDto dto)
    {
        if (dto == null)
        {
            return BadRequest("Передаваемы объект пуст");
        }

        var chapter = new Chapter
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Description = dto.Description,
            IconUrl = dto.IconUrl,
            Order = dto.Order,
            LanguageId = dto.LanguageId,
        };

        var createdChapter = await _service.CreateChapter(chapter);

        return CreatedAtAction(
            nameof(GetChapterById),
            new { id = createdChapter },
            createdChapter
        );
    }

    [HttpPut]
    public async Task<ActionResult> UpdateChapter([FromBody] ChapterDto dto)
    {
        if (dto.Id == null)
        {
            return BadRequest("Передаваемый объект пуст");
        }

        var chapter = new Chapter
        {
            Id = dto.Id.Value,
            Title = dto.Title,
            Description = dto.Description,
            IconUrl = dto.IconUrl,
            Order = dto.Order,
            LanguageId = dto.LanguageId,
        };

        var updatedAnswer = await _service.UpdateChapter(chapter);

        return updatedAnswer ? NoContent() : NotFound(new ErrorResponse
        {
            StatusCode = 404,
            Message = "Ошибка при обновлении"
        });
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteChapter(Guid id)
    {
        var deletedAnswer = await _service.DeleteChapter(id);

        return deletedAnswer ? NoContent() : NotFound(new ErrorResponse
        {
            StatusCode = 404,
            Message = "Ошибка при удалении курса"
        });
    }
}
