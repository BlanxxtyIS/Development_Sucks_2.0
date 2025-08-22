namespace DevelopmentSucks.Domain.Entities;

public class AiHelpRequest
{
    public Guid Id { get; set; }
    public string RequestText { get; set; } = string.Empty;
    public string ResponseText { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Guid UserId { get; set; }
    public Guid TaskId { get; set; }
}
