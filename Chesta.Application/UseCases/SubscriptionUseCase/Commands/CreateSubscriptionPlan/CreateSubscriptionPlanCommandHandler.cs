using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using Chesta.Domain.Specifications;
using MediatR;

namespace Chesta.Application.UseCases.SubscriptionUseCase.Commands
{
    public class CreateSubscriptionPlanCommandHandler : IRequestHandler<CreateSubscriptionPlanCommand, AuthorPlan>
    {
        IAuthorRepository _authorRepository;
        IAuthorPlanRepository _authorPlanRepository;

        public CreateSubscriptionPlanCommandHandler(IAuthorRepository authorRepository, IAuthorPlanRepository authorPlanRepository)
        {
            _authorRepository = authorRepository;
            _authorPlanRepository = authorPlanRepository;
        }

        public async Task<AuthorPlan> Handle(CreateSubscriptionPlanCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByIdAsync<Author>(AuthorSpecs.ByUserId(request.UserId));

            var subscriptionPlan = new AuthorPlan {
                Name = request.Name,
                Description = request.Description,
                AccessLevel = request.AccessLevel,
                SubscriptionType = request.SubscriptionType,
                AuhorId = author.Id
            };

            await _authorPlanRepository.AddAsync(subscriptionPlan);

            return subscriptionPlan;
        }
    }
}