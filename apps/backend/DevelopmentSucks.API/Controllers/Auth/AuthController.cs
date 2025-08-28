using DevelopmentSucks.Application.DTO;
using DevelopmentSucks.Application.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentSucks.API.Controllers.Auth;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<Guid>> Register([FromBody] UserDto request)
    {
        if (request == null)
        {
            return BadRequest(new ErrorResponse
            {
                StatusCode = 400,
                Message = "Некорректный запрос"
            });
        }

        var (success, error, userId) = await _authService.RegisterAsync(request);

        if (!success)
        {
            return BadRequest(new ErrorResponse
            {
                StatusCode = 400,
                Message = error ?? "Ошибка регистрации"
            });
        }

        return Ok(userId);

        //return Created($"/api/users/{userId}", new { id = userId });
    }

    [HttpPost("login")]
    public async Task<ActionResult> LoginUser([FromBody] UserDto dto)
    {
        if (dto == null)
        {
            return BadRequest(new ErrorResponse
            {
                StatusCode = 400,
                Message = "Некорректный запрос"
            });
        }

        var result = await _authService.LoginAsync(dto.Username, dto.Password);

        if (!result.Success)
        {
            return Unauthorized(new { error = result.Error });
        }

        return Ok(new { token = result.Token });
    }
}
