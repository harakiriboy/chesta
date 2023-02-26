using Chesta.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Chesta.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}