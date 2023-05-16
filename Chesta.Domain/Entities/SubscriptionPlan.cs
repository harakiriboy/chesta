using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Enums;

namespace Chesta.Domain.Entities
{
    public class SubscriptionPlan
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string AccessLevel { get; set; } = null!;
        public SubscriptionType SubscriptionType { get; set; }
        public int Price { get; set; }

        // Publications
        public List<Publication> Publications { get; set; } = null!;

        // Subscriptions
        public List<Subscription> Subscriptions { get; set; } = null!;

        // Author
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; } = null!;
    }
}