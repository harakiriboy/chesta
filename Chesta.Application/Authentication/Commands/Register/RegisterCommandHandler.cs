using Chesta.Application.Authentication.Common;
using Chesta.Application.Common.Interfaces.Authentication;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Chesta.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        // 1. Validate user not exist
            if(_userRepository.GetUserByEmail(command.Email) is not null) {
                return Domain.Common.Errors.Errors.User.DuplicateEmail;
            }

            // 2. Create user (generate unique ID) & Persist in DB
            var user = new User {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };

            _userRepository.Add(user);

            
            // 3. Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token
            );
    }
}
