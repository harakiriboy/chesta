using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Entities;
using NSpecifications;

namespace Chesta.Domain.Specifications
{
    public class UserSpecs
    {
        public static Spec<User> ById(int id) {
            return new Spec<User>(x => x.Id == id);
        }
    }
}