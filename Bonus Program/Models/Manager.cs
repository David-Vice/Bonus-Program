using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bonus_Program.Models
{
    [Table("Manager")]
    public class Manager
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Lastname { get; set; }

        [Required, MaxLength(50)]
        public string Login { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }

        public bool Admin { get; set; }

        public virtual ICollection<BonusTransaction> BonusTransactions { get; set; }
    }
}
