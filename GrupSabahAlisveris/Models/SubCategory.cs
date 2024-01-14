namespace GrupSabahAlisveris.Models
{
    public class SubCategory
    {
        public int SubCategory_Id { get; set; }
        public string SubCategory_Name { get; set; } = string.Empty;
        public int Category_Id { get; set; }
        public virtual Category? Category { get; set; }
    }
}
