using System.Data;
using FluentValidation;

namespace Chesta.Application.Authentication.Commands.RegisterAuthor
{
    public class RegisterAuthorCommandValidator : AbstractValidator<RegisterAuthorCommand>
    {
        public RegisterAuthorCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.AuthorUsername).NotEmpty();
        }
    }
}