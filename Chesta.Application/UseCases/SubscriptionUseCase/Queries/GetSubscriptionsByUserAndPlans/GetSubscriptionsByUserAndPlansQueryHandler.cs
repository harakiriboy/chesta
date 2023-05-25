using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Common.Interfaces.Persistence;
using MediatR;

namespace Chesta.Application.UseCases.SubscriptionUseCase.Queries.GetSubscriptionsByUserAndPlans
{
    public class GetSubscriptionsByUserAndPlansQueryHandler : IRequestHandler<GetSubscriptionsByUserAndPlansQuery, List<int>>
    {
        ISubscriptionRepository _subscriptionRepository;

        public GetSubscriptionsByUserAndPlansQueryHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<List<int>> Handle(GetSubscriptionsByUserAndPlansQuery request, CancellationToken cancellationToken)
        {
            var plans = await _subscriptionRepository.GetByUserAndPlans(request.UserId, request.Plans);
            return plans;
        }
    }
}