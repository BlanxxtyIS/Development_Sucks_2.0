using DevelopmentSucks.Application.DTO;
using DevelopmentSucks.Application.Services;
using DevelopmentSucks.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentSucks.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _service;

    public UsersController(IUsersService service)
    {
        _service = service;
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

    [HttpPut]
    public async Task<ActionResult> UpdatedUser([FromBody] UserDto userDto)
    {
        if (userDto.Id == null)
        {
            return BadRequest("Объект пустой");
        }

        try
        {
            var updated = await _service.UpdateUser(userDto);
            return updated ? NoContent() : NotFound(new ErrorResponse
            {
                StatusCode = 404,
                Message = "Ошибка при создании пользователя"
            });
        }
        catch (Exception ex)
        {
            return Conflict(new ErrorResponse
            {
                StatusCode = 409,
                Message = ex.Message
            });
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteUser(Guid id)
    {
        var deleted = await _service.DeleteUser(id);

        return deleted ? NoContent() : NotFound(new ErrorResponse
        {
            StatusCode = 404,
            Message = "Ошибка при удалении курса"
        });
    }
}

