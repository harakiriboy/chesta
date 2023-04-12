using Chesta.Application.Authentication.Commands.RegisterAuthor;
using Chesta.Application.Authentication.Commands.RegisterSubscriber;
using Chesta.Application.Authentication.Common;
using Chesta.Application.Authentication.Queries.Login;
using Chesta.Contracts.Authentication;
using Chesta.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chesta.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("registerUser")]
        public async Task<IActionResult> RegisterUser(RegisterUserRequest request)
        {
            var command = _mapper.Map<RegisterSubscriberCommand>(request);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationReponse>(authResult)),
                errors => Problem(errors)
            );
        }

        [HttpPost("registerAuthor")]
        public async Task<IActionResult> RegisterAuthor(RegisterAuthorRequest request)
        {
            var command = _mapper.Map<RegisterAuthorCommand>(request);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationReponse>(authResult)),
                errors => Problem(errors)
            );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            var authResult = await _mediator.Send(query);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authResult.FirstError.Description);
            }
            
            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationReponse>(authResult)),
                errors => Problem(errors)
            );
        }
    }
}