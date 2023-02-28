using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Authentication.Commands.Register;
using Chesta.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Chesta.Application.Common.Behaviors
{
    public class ValidateRegisterCommandBehavior : IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        public async Task<ErrorOr<AuthenticationResult>> Handle(
            RegisterCommand request,
            RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next,
            CancellationToken cancellationToken)
        {
            //before the handler
            var result = await next();

            //after the handler
            return result;
        }
    }
}