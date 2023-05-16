using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Entities;
using MediatR;

namespace Chesta.Application.UseCases.SubscriptionUseCase.Queries.GetSubscriptionPlans
{
    public class GetSubscriptionPlansQuery : IRequest<IEnumerable<SubscriptionPlan>>
    {
        
    }
}