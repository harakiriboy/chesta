using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Enums;

namespace Chesta.Domain.Entities
{
    public class AuthorPlan
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string AccessLevel { get; set; } = null!;
        public SubscriptionType SubscriptionType { get; set; }

        // Publications
        public List<Publication> Publications { get; set; } = null!;

        // Author
        public int AuhorId { get; set; }
        [ForeignKey("AuhorId")]
        public Author Author { get; set; } = null!;
    }
}