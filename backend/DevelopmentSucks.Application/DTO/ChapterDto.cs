using DevelopmentSucks.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace DevelopmentSucks.Application.DTO;

public class ChapterDto
{
    public Guid? Id { get; set; }
    [Required(ErrorMessage = "Название главы обязательо")]
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string IconUrl { get; set; } = string.Empty;
    public int Order { get; set; }
    public Guid LanguageId { get; set; }
}

