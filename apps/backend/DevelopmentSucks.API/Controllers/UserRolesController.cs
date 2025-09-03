using DevelopmentSucks.Application.DTO;
using DevelopmentSucks.Application.Services;
using DevelopmentSucks.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentSucks.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserRolesController : ControllerBase
{
    private readonly IUserRoleService _service;

    public UserRolesController(IUserRoleService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserRole>>> GetAllUserRoles()
    {
        var userRoles = await _service.GetAllUserRoles();
        
        return userRoles.Any() ? Ok(userRoles) : NotFound(new ErrorResponse
        {
            StatusCode = 404,
            Message = "Уроки пустые"
        });
    }  
}
