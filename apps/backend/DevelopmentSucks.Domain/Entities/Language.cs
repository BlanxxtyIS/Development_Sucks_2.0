namespace DevelopmentSucks.Domain.Entities;

public class Language
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string IconUrl { get; set; } = string.Empty;
    public int ProgressMax { get; set; } = 1000;
    public List<Chapter> Chapters { get; set; } = new();
}
