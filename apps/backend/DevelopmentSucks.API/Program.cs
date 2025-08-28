using DevelopmentSucks.Application;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using DevelopmentSucks.Application.DTO.Users;
using DevelopmentSucks.Infrastructure;
using DevelopmentSucks.Infrastructure.Persistence.Repositories.Auth;
using DevelopmentSucks.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtSettings"));

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserDtoValidator>());


var connString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddApplication();
builder.Services.AddInfrastructure(connString);

builder.Services.ConfigureJWT(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
