namespace DevelopmentSucks.Domain.Entities;

public class Lesson
{
    public Guid Id { get; set; }
    public Guid ChapterId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty; 
    public int Order { get; set; }
}
