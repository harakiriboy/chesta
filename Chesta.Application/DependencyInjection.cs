using System.Reflection;
using Chesta.Application.Authentication.Commands.Register;
using Chesta.Application.Authentication.Common;
using Chesta.Application.Common.Behaviors;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Chesta.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);

        services.AddScoped(
            typeof(IPipelineBehavior<,>), 
            typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}