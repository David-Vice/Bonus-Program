using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bonus_Program.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Fullname { get; set; }

        public decimal Price { get; set; }

        public decimal BonusPercent { get; set; }

        public virtual ICollection<Movement> Movements { get; set; }
    }
}
