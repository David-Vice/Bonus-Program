using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bonus_Program.Models
{
    [Table("Bonus")]
    public class BonusTransaction
    {
        [Key]
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int ManagerId { get; set; }

        [Column(TypeName = "decimal")]
        public decimal UsedBonus { get; set; }

        [Column(TypeName = "decimal")]
        public decimal NewBonus { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Payed { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Total { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        [ForeignKey("ManagerId")]
        public virtual Manager Manager { get; set; }

        public virtual ICollection<Movement> Movements { get; set; }
    }
}
