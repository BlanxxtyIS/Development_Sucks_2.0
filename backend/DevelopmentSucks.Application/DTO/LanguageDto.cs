using DevelopmentSucks.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace DevelopmentSucks.Application.DTO;

public class LanguageDto
{
    public Guid? Id { get; set; }

    [Required(ErrorMessage = "Название языка обязательна")]
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string IconUrl { get; set; } = string.Empty;
    public int ProgressMax { get; set; } = 1000;
}