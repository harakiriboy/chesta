using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Entities;

namespace Chesta.Application.Services
{
    public interface IStripeSubscriptionService
    {
        Task<string> CreateStripeSubscription(string customerId, string accountId, SubscriptionPlan subscriptionPlan);
    }
}