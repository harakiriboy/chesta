using Chesta.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Chesta.Application.Authentication.Commands.RegisterAuthor
{
    public record RegisterAuthorCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string AuthorUsername) : IRequest<ErrorOr<AuthenticationResult>>;
}