using System.ComponentModel.DataAnnotations;

namespace GrupSabahAlisveris.Models
{
    public class ProductColors
    {
        [Key]
        public int PcolorId { get; set; }
        public int Product_Id { get; set; }
        public int ColorId { get; set; }
    }
}
