using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Contracts.Subscriptions.Enums;

namespace Chesta.Contracts.Subscriptions
{
    public record CreateSubscriptionPlanRequest(
        string Name,
        string Description,
        string AccessLevel,
        RequestSubscriptionType SubscriptionType
    );
}