using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using Chesta.Domain.Specifications;
using MediatR;

namespace Chesta.Application.UseCases.SubscriptionUseCase.Commands.EditSubscriptionPlan
{
    public class EditSubscriptionPlanCommandHandler : IRequestHandler<EditSubscriptionPlanCommand, SubscriptionPlan>
    {
        private readonly ISubscriptionPlanRepository _subscriptionPlanRepository;

        public EditSubscriptionPlanCommandHandler(ISubscriptionPlanRepository subscriptionPlanRepository)
        {
            _subscriptionPlanRepository = subscriptionPlanRepository;
        }

        public async Task<SubscriptionPlan> Handle(EditSubscriptionPlanCommand request, CancellationToken cancellationToken)
        {
            var subPlanId = Convert.ToInt32(request.Id);
            var subscriptionPlan = await _subscriptionPlanRepository.GetByIdAsync(SubscriptionPlanSpecs.ById(subPlanId));
            subscriptionPlan.Description = request.Description;
            subscriptionPlan.Price = Convert.ToInt32(request.Price);
            subscriptionPlan.Name = request.Name;
            await _subscriptionPlanRepository.UpdatePlan(subscriptionPlan);
            return subscriptionPlan;
        }
    }
}