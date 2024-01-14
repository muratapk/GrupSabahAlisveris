using System.ComponentModel.DataAnnotations;

namespace GrupSabahAlisveris.Models
{
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }
        public string Cateogory_Name { get; set; } = string.Empty;
        public virtual ICollection<SubCategory>? SubCategories { get; set; }
    }
}
