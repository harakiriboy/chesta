using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Enums;

namespace Chesta.Domain.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public string StripeSubscriptionId { get; set; } = null!;
        public SubscriptionStatusEnum Status { get; set; }

        // Author
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; } = null!;

        // User(Subscriber)
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        // Payment
        public List<Payment> Payments { get; set; } = null!;
    }
}