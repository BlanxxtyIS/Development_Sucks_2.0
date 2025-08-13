using System.ComponentModel.DataAnnotations;

namespace DevelopmentSucks.Application.DTO;

public class LessonDto
{
    public Guid? Id { get; set; }
    [Required(ErrorMessage = "Наименование обязательно")]
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int Order { get; set; }
    public Guid ChapterId { get; set; }
}