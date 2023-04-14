using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chesta.Contracts.Subscriptions
{
    public record CreateSubscriptionRequest(
        int SubscriptionPlanId
    );
}