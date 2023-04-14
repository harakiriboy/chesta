using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Entities;
using NSpecifications;

namespace Chesta.Domain.Specifications
{
    public class AuthorSpecs
    {
        public static Spec<Author> ById(int id) {
            return new Spec<Author>(x => x.Id == id);
        }

        public static Spec<Author> ByUserId(int id) {
            return new Spec<Author>(x => x.UserId == id);
        }
    }
}