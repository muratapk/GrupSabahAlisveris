using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupSabahAlisveris.Models
{
    public class Gallery
    {
        [Key]
        public int GalleryId { get; set; }
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public string Image { get; set; } = string.Empty;
        
        [NotMapped]
        public IEnumerable <IFormFile>? ProductImage { get; set; }
       
    }
}
