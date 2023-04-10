using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chesta.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;

        // Author
        public Author Author { get; set; } = null!;
    }
}