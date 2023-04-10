using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Chesta.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        // User
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        // Publication
        public int PublicationId { get; set; }
        [ForeignKey("PublicationId")]
        public Publication Publication { get; set; } = null!;
    }
}