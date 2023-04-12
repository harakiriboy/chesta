using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Chesta.Application.Authentication.Commands.RegisterSubscriber
{
    public class RegisterSubscriberCommandValidator : AbstractValidator<RegisterSubscriberCommand>
    {
        public RegisterSubscriberCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}