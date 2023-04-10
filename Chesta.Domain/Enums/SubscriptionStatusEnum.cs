using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chesta.Domain.Enums
{
    public enum SubscriptionStatusEnum : byte
    {
        Pending,
        Active,
        Inactive,
        Cancelled
    }
}