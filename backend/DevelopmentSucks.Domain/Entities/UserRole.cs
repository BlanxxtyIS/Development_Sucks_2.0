using DevelopmentSucks.Domain.Enums;

namespace DevelopmentSucks.Domain.Entities;

public class UserRole
{
    public Guid Id { get; set; }
    public Roles Role { get; set; } = Roles.Student;
    public List<User> Users { get; set; } = new List<User>();
}
