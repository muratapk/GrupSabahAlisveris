using System.ComponentModel.DataAnnotations;

namespace GrupSabahAlisveris.Models
{
    public class Sizes
    {
        [Key]
        public int Size_Id { get; set; }
        public string SizeName { get; set; }
    }
}
