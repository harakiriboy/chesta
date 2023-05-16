using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using Chesta.Domain.Specifications;
using MediatR;

namespace Chesta.Application.UseCases.SubscriptionUseCase.Commands
{
    public class CreateSubscriptionPlanCommandHandler : IRequestHandler<CreateSubscriptionPlanCommand, SubscriptionPlan>
    {
        IAuthorRepository _authorRepository;
        ISubscriptionPlanRepository _subscriptionPlanRepository;

        public CreateSubscriptionPlanCommandHandler(IAuthorRepository authorRepository, ISubscriptionPlanRepository subscriptionPlanRepository)
        {
            _authorRepository = authorRepository;
            _subscriptionPlanRepository = subscriptionPlanRepository;
        }

        public async Task<SubscriptionPlan> Handle(CreateSubscriptionPlanCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByIdAsync<Author>(AuthorSpecs.ByUserId(request.UserId));

            var subscriptionPlan = new SubscriptionPlan {
                Name = request.Name,
                Description = request.Description,
                Price = Convert.ToInt32(request.Price),
                SubscriptionType = Domain.Enums.SubscriptionType.Monthly,
                AccessLevel = "First level",
                AuthorId = author.Id
            };

            await _subscriptionPlanRepository.AddAsync(subscriptionPlan);

            return subscriptionPlan;
        }
    }
}