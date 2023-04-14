using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Entities;
using NSpecifications;

namespace Chesta.Domain.Specifications
{
    public class AuthorPlanSpecs
    {
        public static Spec<AuthorPlan> ById(int id) {
            return new Spec<AuthorPlan>(x => x.Id == id);
        }
    }
}