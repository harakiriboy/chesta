using Chesta.Application.Authentication.Commands.Register;
using Chesta.Application.Authentication.Common;
using Chesta.Application.Common.Behaviors;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Chesta.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddScoped<
            IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>,
            ValidateRegisterCommandBehavior>();
        return services;
    }
}