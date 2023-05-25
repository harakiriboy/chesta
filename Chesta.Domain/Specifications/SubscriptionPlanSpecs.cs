using System;
using System.Collections.Generic;
using System.Net;
using Chesta.Domain.Entities;
using NSpecifications;

namespace Chesta.Domain.Specifications
{
    public class SubscriptionPlanSpecs
    {
        public static Spec<SubscriptionPlan> ById(int id) {
            return new Spec<SubscriptionPlan>(x => x.Id == id);
        }

        public static Spec<SubscriptionPlan> ByAuthorId(int id) {
            return new Spec<SubscriptionPlan>(x => x.AuthorId == id);
        }
    }
}