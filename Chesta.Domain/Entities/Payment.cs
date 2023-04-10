using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chesta.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        
        // Subscription
        public int SubscriptionId { get; set; }
        [ForeignKey("SubscriptionId")]
        public Subscription Subscription { get; set; } = null!;

        // Customer
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        // Author
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; } = null!;
    }
}