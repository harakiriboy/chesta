using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using Chesta.Domain.Specifications;
using MediatR;

namespace Chesta.Application.UseCases.SubscriptionUseCase.Queries.GetSubscriptionPlans
{
    public class GetSubscriptionPlansQueryHandler : IRequestHandler<GetSubscriptionPlansQuery, IEnumerable<SubscriptionPlan>>
    {
        private readonly ISubscriptionPlanRepository _subscriptionPlanRepository;
        private readonly IAuthorRepository _authorRepository;

        public GetSubscriptionPlansQueryHandler(ISubscriptionPlanRepository subscriptionPlanRepository, IAuthorRepository authorRepository)
        {
            _subscriptionPlanRepository = subscriptionPlanRepository;
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<SubscriptionPlan>> Handle(GetSubscriptionPlansQuery request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByUsername(request.Author);
            var subscriptionPlans = await _subscriptionPlanRepository.GetAllByIdAsync<SubscriptionPlan>(SubscriptionPlanSpecs.ByAuthorId(author!.Id));
            return subscriptionPlans;
        }
    }
}