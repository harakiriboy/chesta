namespace Chesta.Contracts.Authentication;

public record AuthenticationReponse(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);