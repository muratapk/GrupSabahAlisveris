using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupSabahAlisveris.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }

        [Display(Name ="Ürün Adı")]
        [Required(ErrorMessage ="Ürün İsmin Boş Bırakmazsınız")]
        [MinLength(3,ErrorMessage ="Üç Karakter Az Olamaz")]
        public string Product_Name { get; set; } = string.Empty;
        [Display(Name = "Ürün Açıklaması")]
        public string Product_Description { get; set; } = string.Empty;
        [Display(Name = "Ürün Resmi")]
        public string Product_Image { get; set; } = string.Empty;
        [Display(Name = "Ürün Fiyatı")]
        public decimal Product_Price { get; set; }
        [Display(Name = "Kategori Adı")]
        public int Category_Id { get; set; }
        public virtual Category? Category { get; set; }

        [Display(Name = "Alt Kategori Adı")]
        public int SubCategory_Id { get; set; }
        public virtual SubCategory? SubCategory { get; set; }

        [Display(Name = "Ürün Özellikleri")]
        public string Product_Feature { get; set; } = string.Empty;

        [NotMapped]
        public IFormFile? ImagePicture { get; set; }
    }
}
