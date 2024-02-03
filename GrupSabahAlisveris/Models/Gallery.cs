using System.ComponentModel.DataAnnotations;

namespace GrupSabahAlisveris.Models
{
    public class Gallery
    {
        [Key]
        public int GalleryId { get; set; }
        public int? ProductId { get; set; }
        public string Image { get; set; } = string.Empty;
       
    }
}
