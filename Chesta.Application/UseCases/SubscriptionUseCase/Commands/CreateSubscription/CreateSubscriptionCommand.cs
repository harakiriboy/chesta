using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Entities;
using MediatR;

namespace Chesta.Application.UseCases.SubscriptionUseCase.Commands.CreateSubscription
{
    public class CreateSubscriptionCommand : IRequest<Subscription>
    {
        public int SubscriptionPlanId { get; set; }
        public int UserId { get; set; }
    }
}