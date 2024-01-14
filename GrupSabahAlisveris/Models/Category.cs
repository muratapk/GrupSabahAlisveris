using System.ComponentModel.DataAnnotations;

namespace GrupSabahAlisveris.Models
{
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }

        [Display(Name ="Kategori Adı")]
        [MaxLength(50), MinLength(2)]
        [Required(ErrorMessage ="Kategori Boş Geçemezsiniz")]
        public string Category_Name { get; set; } = string.Empty;
        public virtual ICollection<SubCategory>? SubCategories { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
