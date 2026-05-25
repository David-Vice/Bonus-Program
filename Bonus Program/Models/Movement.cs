using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bonus_Program.Models
{
    [Table("Movement")]
    public class Movement
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int BonusId { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Total { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("BonusId")]
        public virtual BonusTransaction BonusTransaction { get; set; }
    }
}
