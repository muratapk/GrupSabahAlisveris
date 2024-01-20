using System.ComponentModel.DataAnnotations;

namespace GrupSabahAlisveris.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminName { get; set; } = string.Empty;
        public string AdminPassword { get; set; } = string.Empty;
        public string AdminEmail { get; set; } = string.Empty;
    }
}
