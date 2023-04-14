using System.Security.Claims;
using Chesta.Application.UseCases.SubscriptionUseCase.Commands;
using Chesta.Application.UseCases.SubscriptionUseCase.Commands.CreateSubscription;
using Chesta.Contracts.Subscriptions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chesta.Api.Controllers
{
    [Route("subscriptions")]
    [Authorize]
    public class SubscriptionsController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public SubscriptionsController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSubscriptionRequest request) {
            var command = _mapper.Map<CreateSubscriptionCommand>(request);
            command.UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("plan")]
        public async Task<IActionResult> CreateSubsriptionPlan(CreateSubscriptionPlanRequest request) {
            var command = _mapper.Map<CreateSubscriptionPlanCommand>(request);
            command.UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            
            var result = await _mediator.Send(command);

            return Ok(result);
        }


        // [HttpGet]
        // [Authorize]
        // public IActionResult GetUser() 
        // {
        //     Console.WriteLine("User Id: " + User.FindFirstValue(ClaimTypes.NameIdentifier));
        //     return Ok();
        // }
    }
}