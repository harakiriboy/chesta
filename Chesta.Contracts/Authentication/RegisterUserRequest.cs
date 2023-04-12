namespace Chesta.Contracts.Authentication;

public record RegisterUserRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password
);