using System.ComponentModel.DataAnnotations;

namespace GrupSabahAlisveris.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }
        public string Product_Name { get; set; } = string.Empty;
        public string Product_Description { get; set; } = string.Empty; 

        public string Product_Image { get; set; } = string.Empty;
        public decimal Product_Price { get; set; }
        public int Category_Id { get; set; }
        public virtual Category? Category { get; set; }
        public int SubCategory_Id { get; set; }
        public virtual SubCategory? SubCategory { get; set; }
        public string Product_Feature { get; set; } = string.Empty;
    }
}
