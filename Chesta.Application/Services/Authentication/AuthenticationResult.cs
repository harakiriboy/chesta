using System.ComponentModel.DataAnnotations;
using Chesta.Domain.Entities;

namespace Chesta.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);