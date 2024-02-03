using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupSabahAlisveris.Models
{
    public class ProductColor
    {
        [Key]
        public int ProductColorId { get; set; }
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public virtual Product? Product {  get; set; }   
        [ForeignKey("Color")]
        public int? ColorId { get; set; }
        public virtual Color? Color { get; set; }    
        public int? Stocks { get; set; } 
    }
}
