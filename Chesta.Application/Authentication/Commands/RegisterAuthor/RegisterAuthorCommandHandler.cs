using Chesta.Application.Authentication.Common;
using Chesta.Application.Common.Interfaces.Authentication;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Application.Services;
using Chesta.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Chesta.Application.Authentication.Commands.RegisterAuthor;

public class RegisterAuthorCommandHandler : IRequestHandler<RegisterAuthorCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IStripeCustomerService _customerService;
    private readonly IStripeAccountService _accountService;
    private readonly IAuthorRepository _authorRepository;

    public RegisterAuthorCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, 
    IStripeCustomerService customerService, IStripeAccountService accountService, IAuthorRepository authorRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _customerService = customerService;
        _accountService = accountService;
        _authorRepository = authorRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterAuthorCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // 1. Validate user not exist
        if(_userRepository.GetUserByEmail(command.Email) is not null) {
            return Domain.Common.Errors.Errors.User.DuplicateEmail;
        }

        // 2. Create user (generate unique ID) & Persist in DB
        var user = new User {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password,
            Role = "author"
        };
        
        // 3. Getting the stripe customer id
        user.CustomerId = await _customerService.CreateStripeCustomer(user);        

        // 5. after this create for him stripe connected account
        var stripeAccountId = await _accountService.CreateConnectedAccount(command);

        // 7. adding those two objects into database
        var existingUser = _userRepository.Add(user);

        // 4. Checking if user is author, if yes create for him author object in db
        var author = new Author {
            AuthorUsername = command.AuthorUsername,
            UserId = existingUser.Id,
            Tag = "informatics"
        };

        // 6. assigning this account id to the author object
        author.StripeAccountId = stripeAccountId;

        await _authorRepository.Add(author);

        
        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
}
