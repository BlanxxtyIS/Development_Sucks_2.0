using System.Data;

namespace DevelopmentSucks.WEB.Models;

public class UserRole
{
    public Guid Id { get; set; }
    public Roles Role { get; set; } = Roles.Student;
    public List<UserDto> Users { get; set; } = new List<UserDto>();
}

public enum Roles
{
    Admin,
    Teacher,
    Student
}