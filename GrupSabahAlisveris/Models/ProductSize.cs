using System.ComponentModel.DataAnnotations;

namespace GrupSabahAlisveris.Models
{
    public class ProductSize
    {
        [Key]
        public int ProductSizeId { get; set; }
        public int? ProductId { get; set; }
        public int? SizeId { get; set; }
        public int? Stocks { get; set; }
    }
}
