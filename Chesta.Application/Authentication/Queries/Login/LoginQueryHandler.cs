using Chesta.Application.Authentication.Common;
using Chesta.Application.Common.Interfaces.Authentication;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Chesta.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // 1. Validate the user exists
        if(_userRepository.GetUserByEmail(query.Email) is not User user) {
            return Domain.Common.Errors.Errors.Authentication.InvalidCredentials;
        }

        // 2. Validate the password is correct
        if(user.Password != query.Password) {
            return Domain.Common.Errors.Errors.Authentication.InvalidCredentials;
        }


        // 3. Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
}
}




