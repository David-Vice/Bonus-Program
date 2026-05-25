using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bonus_Program.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Lastname { get; set; }

        [Required, MaxLength(50)]
        public string CardNumber { get; set; }

        public decimal Bonus { get; set; }

        public virtual ICollection<BonusTransaction> BonusTransactions { get; set; }
    }
}
