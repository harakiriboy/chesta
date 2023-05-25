using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Chesta.Application.UseCases.SubscriptionUseCase.Queries.GetSubscriptionsByUserAndPlans
{
    public class GetSubscriptionsByUserAndPlansQuery : IRequest<List<int>>
    {
        public int UserId { get; set; }
        public int[] Plans { get; set; } = null!;
    }
}