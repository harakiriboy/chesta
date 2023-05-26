using System.Security.Claims;
using Chesta.Application.UseCases.SubscriptionUseCase.Commands;
using Chesta.Application.UseCases.SubscriptionUseCase.Commands.CreateSubscription;
using Chesta.Application.UseCases.SubscriptionUseCase.Commands.EditSubscriptionPlan;
using Chesta.Application.UseCases.SubscriptionUseCase.Queries.GetSubscriptionPlans;
using Chesta.Application.UseCases.SubscriptionUseCase.Queries.GetSubscriptions;
using Chesta.Application.UseCases.SubscriptionUseCase.Queries.GetSubscriptionsByUserAndPlans;
using Chesta.Contracts.Subscriptions;
using Chesta.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace Chesta.Api.Controllers
{
    [Route("chesta/subscriptions")]
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

        [HttpPost("plan/edit")]
        public async Task<IActionResult> editSubscriptionPlan(EditSubscriptionPlanRequest request) {
            var command = _mapper.Map<EditSubscriptionPlanCommand>(request);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("plan")]
        [AllowAnonymous]
        public async Task<IEnumerable<SubscriptionPlan>> GetSubsriptionPlans(string author) {
            var command = new GetSubscriptionPlansQuery(author);
            var result = await _mediator.Send(command);
            if(result is null) {
                var list = new List<SubscriptionPlan>();
                var plan = new SubscriptionPlan();
                list.Add(plan);
                return list;
            }
            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<Domain.Entities.Subscription>> GetAll() {
            var query = new GetSubscriptionsQuery();
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost("byUserAndPlan")]
        public async Task<List<int>> GetSubscriptionPlansByUserAndPublicationPlan(GetSubscriptionByUserAndPlanRequest request) {
            var query = _mapper.Map<GetSubscriptionsByUserAndPlansQuery>(request);
            var result = await _mediator.Send(query);
            return result;
        }

        [AllowAnonymous]
        [HttpPost("webhook")]
        public async Task<IActionResult> StripeWebhook() {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"],
                "whsec_bd2a3adfb085b118f61335024d767fbce63cb58689c037d525a959a6304f4b4d");

            var charge = (Charge)stripeEvent.Data.Object;

            if (charge.Status == "succeeded") Console.WriteLine("hi, your charge is succeeded");

            return new EmptyResult();
        }
    }
}