using DevelopmentSucks.Domain.Repositories;
using DevelopmentSucks.Domain.Repositories.Auth;
using DevelopmentSucks.Infrastructure.Persistence.Repositories;
using DevelopmentSucks.Infrastructure.Persistence.Repositories.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DevelopmentSucks.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<ILanguagesRepository, LanguagesRepository>();
        services.AddScoped<IChapterRepository, ChapterRepository>();
        services.AddScoped<ILessonRepository, LessonRepository>();

        // DbContext
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }
}
