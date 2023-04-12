using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Authentication.Common;
using Chesta.Application.Common.Interfaces.Authentication;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Application.Services;
using Chesta.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Chesta.Application.Authentication.Commands.RegisterSubscriber
{
    public class RegisterSubscriberCommandHandler : IRequestHandler<RegisterSubscriberCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IStripeCustomerService _customerService;

        public RegisterSubscriberCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IStripeCustomerService customerService)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _customerService = customerService;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterSubscriberCommand command, CancellationToken cancellationToken)
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
                Role = "subscriber"
            };
            
            // 3. Getting the stripe customer id
            user.CustomerId = await _customerService.CreateStripeCustomer(user);
            _userRepository.Add(user);

            
            // 3. Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token
            );
        }
    }
}