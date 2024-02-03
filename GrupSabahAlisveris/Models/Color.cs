using System.ComponentModel.DataAnnotations;

namespace GrupSabahAlisveris.Models
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }
        public string ColorName { get; set; } = string.Empty;
    }
}
