using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chesta.Domain.Entities
{
    public class Payout
    {
        public int Id { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; } = null!;
    }
}