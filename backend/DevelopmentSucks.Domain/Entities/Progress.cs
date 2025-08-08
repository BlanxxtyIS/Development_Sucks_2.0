namespace DevelopmentSucks.Domain.Entities;

public class Progress
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public Guid LanguageId { get; set; }
    public int Xp { get; set; }
    public DateTime LastUpdated { get; set; }
}
