using DevelopmentSucks.Application.DTO;
using DevelopmentSucks.Application.DTO.Users;
using DevelopmentSucks.Application.Services;
using DevelopmentSucks.Domain.Entities;
using DevelopmentSucks.Domain.Repositories.Auth;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentSucks.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _service;
    private readonly IPasswordHasher _hasher;

    public UsersController(IUsersService service, IPasswordHasher hasher)
    {
        _service = service;
        _hasher = hasher;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        var users = await _service.GetAllUsers();
        return users;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<User?>> GetUserById(Guid id)
    {
        var user = await _service.GetUsersById(id);
        return user != null ? Ok(user) : NotFound(new ErrorResponse
        {
            StatusCode = 404,
            Message = "Пользователя с таким Id не существует"
        });
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateUser([FromBody] RegisterUserRequest userDto)
    {
        if (userDto == null)
        {
            return BadRequest("Объект пустой");
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = userDto.Email,
            Username = userDto.Username,
            PasswordHash = _hasher.Hash(userDto.Password),
            CreatedAt = DateTime.UtcNow,
            UserRoleId = new Guid("a311bcfa-b6e7-4d93-93b1-0974253a031a")
        };

        var createdUser = await _service.CreateUser(user);

        return CreatedAtAction(
            nameof(GetUserById),
            new { id = createdUser },
            createdUser
        );
    }
}

