using System.Security.Claims;
using Chesta.Application.Authentication.Commands.RegisterAuthor;
using Chesta.Application.Authentication.Commands.RegisterSubscriber;
using Chesta.Application.Authentication.Common;
using Chesta.Application.Authentication.Queries.CurrentUser;
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
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [AllowAnonymous]
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

        [HttpGet("getCurrentUser")]
        public async Task<IActionResult> GetCurrentUser() {
            var token = Request.Headers["Authorization"];
            var query = new GetCurrentUserQuery(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)), token);
            var result = await _mediator.Send(query);
            
            if (result.IsError && result.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: result.FirstError.Description);
            }
            
            return result.Match(
                authResult => Ok(_mapper.Map<AuthenticationReponse>(authResult)),
                errors => Problem(errors)
            );
        }
    }
}