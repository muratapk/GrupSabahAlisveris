using System.ComponentModel.DataAnnotations;

namespace GrupSabahAlisveris.Models
{
    public class ProductColor
    {
        [Key]
        public int ProductColorId { get; set; }
        public int? ProductId { get; set; }
        public int? ColorId { get; set; }
        public int? Stocks { get; set; } 
    }
}
