using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupSabahAlisveris.Models
{
    public class ProductSize
    {
        [Key]
        public int ProductSizeId { get; set; }
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public virtual Product? Product { get; set; }
        [ForeignKey("Size")]
        public int? SizeId { get; set; }
        public virtual Size? Size { get; set; }

        public int? Stocks { get; set; }
    }
}
