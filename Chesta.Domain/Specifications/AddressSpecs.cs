using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Chesta.Domain.Entities;
using NSpecifications;

namespace Chesta.Domain.Specifications
{
    public class AddressSpecs
    {
        public static Spec<Address> ById(int id) {
            return new Spec<Address>(x => x.Id == id);
        }
    }
}