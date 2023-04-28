using System;
using System.Collections.Generic;
using Chesta.Domain.Entities;
using NSpecifications;

namespace Chesta.Domain.Specifications
{
    public class SubscriptionPlanSpecs
    {
        public static Spec<SubscriptionPlan> ById(int id) {
            return new Spec<SubscriptionPlan>(x => x.Id == id);
        }
    }
}