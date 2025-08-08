using DevelopmentSucks.Domain.Entities;
using DevelopmentSucks.Domain.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentSucks.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LanguagesController : ControllerBase
{
    private readonly ILanguagesRepository _languagesRepository;

    public LanguagesController(ILanguagesRepository languagesRepository)
    {
        _languagesRepository = languagesRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Language>>> GetLanguages()
    {
        var languages = await _languagesRepository.GetAllLanguages();

        return languages.Any() ? Ok(languages) : NotFound(new ErrorReponse
        {
            StatusCode = 404,
            Message = "Курсы пустые"
        });
    }

    [HttpGet("{guid:id}")]
    public async Task<ActionResult<Language>> GetLanguageById(Guid id)
    {
        var language = await _languagesRepository.GetLanguage(id);

        return language != null ? Ok(language) : NotFound(new ErrorResponse
        {
            StatusCode = 404,
            Message = "Курса с таким ID не существует"
        });
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateLanguage([FromBody] LanguageDto dto)
    {
        if (dto == null)
        {
            return BadRequest("Объект пустой");
        }

        var language = new Language
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Description = dto.Description,
            IconUrl = dto.IconUrl,
        };

        var createdLanguage = await _languagesRepository.CreateLanguage(language);

        return CreatedAtAction(
            nameof(GetLanguageById), 
            new { id = createdLanguage }, 
            createdLanguage
        );
    }

    [HttpPut]
    public async Task<ActionResult> UpdateLanguage([FromBody] LanguageDto dto) { 
        if (dto.Id is null)
        {
            return BadRequest("Id пустой");
        }

        var updatedLanguage = await _languagesRepository.UpdateLanguage(new Language
        {
            Id = dto.Id.Value,
            Title = dto.Title,
            Description = dto.Description,
            IconUrl = dto.IconUrl,
        });

        return updatedLanguage ? NoContent() : NotFound(new ErrorResponse
        {
            StatusCode = 404,
            Message = "Ошибка при обновлении"
        });
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteLanguage([FromBody] Guid id)
    {
        var deletedLanguage = await _languagesRepository.DeleteLanguage(id);
        return deletedLanguage ? NoContent() : NotFound(new ErrorResponse
        {
            StatusCode = 404,
            Message = "Ошибка при удалении курса"
        });
    }
}
