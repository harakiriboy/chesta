namespace Chesta.Contracts.Authentication;

public record RegisterAuthorRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string AuthorUsername
);