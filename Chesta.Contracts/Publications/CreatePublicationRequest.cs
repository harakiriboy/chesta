using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chesta.Contracts.Publications
{
    public record CreatePublicationRequest(
        int SubscriptionPlanId,
        string Title,
        string Text,
        string VideoLink
    );
}