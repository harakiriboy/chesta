using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chesta.Contracts.Subscriptions
{
    public record EditSubscriptionPlanRequest(
        string Id,
        string Name,
        string Description,
        string Price
    );
}