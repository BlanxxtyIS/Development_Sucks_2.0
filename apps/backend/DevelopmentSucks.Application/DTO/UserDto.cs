namespace DevelopmentSucks.Application.DTO;

public class UserDto
{
    public Guid? Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
