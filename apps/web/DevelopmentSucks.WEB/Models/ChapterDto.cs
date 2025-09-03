namespace DevelopmentSucks.WEB.Models;

public class ChapterDto
{
    public Guid Id { get; set; }
    public Guid LanguageId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string IconUrl { get; set; } = string.Empty;
    public int Order { get; set; }
    public List<LessonDto> Lessons { get; set; } = new();
}
