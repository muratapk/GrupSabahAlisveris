using System.ComponentModel.DataAnnotations;

namespace GrupSabahAlisveris.Models
{
    public class Colors
    {
        [Key]
        public int ColorId { get; set; }
        public string ColorName { get; set; }
    }
}
