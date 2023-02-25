using Chesta.Application.Common.Interfaces.Authentication;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Application.Common.Interfaces.Services;
using Chesta.Infrastructure.Authentication;
using Chesta.Infrastructure.Persistence;
using Chesta.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chesta.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}