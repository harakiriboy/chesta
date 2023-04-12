using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Chesta.Application.Authentication.Commands.RegisterSubscriber
{
    public record RegisterSubscriberCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}