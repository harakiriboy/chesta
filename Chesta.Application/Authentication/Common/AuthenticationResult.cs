using Chesta.Domain.Entities;

namespace Chesta.Application.Authentication.Common
{
    public record AuthenticationResult(User User, string Token);
}