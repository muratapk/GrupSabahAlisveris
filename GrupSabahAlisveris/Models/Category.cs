namespace GrupSabahAlisveris.Models
{
    public class Category
    {
        public int Category_Id { get; set; }
        public string Cateogory_Name { get; set; } = string.Empty;
        public virtual ICollection<SubCategory>? SubCategories { get; set; }
    }
}
