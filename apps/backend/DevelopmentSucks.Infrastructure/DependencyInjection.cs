using DevelopmentSucks.Domain.Repositories.Auth;
using DevelopmentSucks.Domain.Repositories;
using DevelopmentSucks.Infrastructure.Persistence.Repositories.Auth;
using DevelopmentSucks.Infrastructure.Persistence.Repositories;
using DevelopmentSucks.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DevelopmentSucks.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<ILanguagesRepository, LanguagesRepository>();
        services.AddScoped<IChapterRepository, ChapterRepository>();
        services.AddScoped<ILessonRepository, LessonRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IJwtRepository, JwtRepository>();

        // DbContext
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }
}
