using DevelopmentSucks.Application.Services;
using DevelopmentSucks.Application.Services.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace DevelopmentSucks.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ILanguagesService, LanguagesService>();
        services.AddScoped<IChaptersService, ChaptersService>();
        services.AddScoped<ILessonsService, LessonsService>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtService, JwtService>();

        return services;
    }
}
