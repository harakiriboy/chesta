using Chesta.Api.Common.Errors;
using Chesta.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Chesta.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, ChestaProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}