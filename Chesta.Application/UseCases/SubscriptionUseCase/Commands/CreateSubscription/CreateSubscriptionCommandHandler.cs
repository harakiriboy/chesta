using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Application.Services;
using Chesta.Domain.Entities;
using Chesta.Domain.Enums;
using Chesta.Domain.Specifications;
using MediatR;

namespace Chesta.Application.UseCases.SubscriptionUseCase.Commands.CreateSubscription
{
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, Subscription>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ISubscriptionPlanRepository _subscriptionPlanRepository;
        private readonly ISubscriptionRepository _subscriptionRepository; 
        private readonly IStripeSubscriptionService _subscriptionService;

        public CreateSubscriptionCommandHandler(IUserRepository userRepository, IAuthorRepository authorRepository, 
        ISubscriptionPlanRepository subscriptionPlanRepository, ISubscriptionRepository subscriptionRepository, 
        IStripeSubscriptionService subscriptionService)
        {
            _userRepository = userRepository;
            _authorRepository = authorRepository;
            _subscriptionPlanRepository = subscriptionPlanRepository;
            _subscriptionRepository = subscriptionRepository;
            _subscriptionService = subscriptionService;
        }
        public async Task<Subscription> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync<User>(UserSpecs.ById(request.UserId));
            var subscriptionPlan = await _subscriptionPlanRepository
            .GetByIdAsync<SubscriptionPlan>(SubscriptionPlanSpecs.ById(request.SubscriptionPlanId));
            var author = await _authorRepository.GetByIdAsync<Author>(AuthorSpecs.ById(subscriptionPlan.AuthorId));
            var stripeSubscriptionId = await _subscriptionService
            .CreateStripeSubscription(user.CustomerId, author.StripeAccountId, subscriptionPlan);

            var subscription = new Subscription {
                StripeSubscriptionId = stripeSubscriptionId,
                Status = SubscriptionStatusEnum.Active,
                AuthorId = author.Id,
                UserId = user.Id,
                SubscriptionType = subscriptionPlan.SubscriptionType,
                SubscriptionPlanId = subscriptionPlan.Id
            };
            await _subscriptionRepository.AddAsync(subscription);
            return subscription;
        }
    }
}