using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chesta.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorUsername { get; set; } = null!;
        public string StripeAccountId { get; set; } = null!;

        // Author plans
        public List<AuthorPlan> Plans { get; set; } = null!;

        // Payments
        public List<Payment> Payments { get; set; } = null!;

        // User
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        // Address
        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address Address { get; set; } = null!;

        // Publications
        public List<Publication> Publications { get; set; } = null!; 
    }
}