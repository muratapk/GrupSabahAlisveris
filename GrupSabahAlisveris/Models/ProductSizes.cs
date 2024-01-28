using System.ComponentModel.DataAnnotations;

namespace GrupSabahAlisveris.Models
{
    public class ProductSizes
    {
        [Key]
        public int PsizeId { get; set; }
        public int Product_Id { get; set; }
        public int SizeId { get; set; }
    }
}
