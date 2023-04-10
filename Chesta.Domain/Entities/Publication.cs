using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chesta.Domain.Entities
{
    public class Publication
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;
        public string VideoLink { get; set; } = null!;

        // Author
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; } = null!;

        // Plan
        public int PlanId { get; set; }
        [ForeignKey("PlanId")]
        public AuthorPlan AuthorPlan { get; set; } = null!;

        // Comments
        public List<Comment> Comments { get; set; } = null!;
    }
}