using GrupSabahAlisveris.Models;
using Microsoft.EntityFrameworkCore;

namespace GrupSabahAlisveris.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<SubCategory>? SubCategories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Admin>? Admins { get; set; }
        public DbSet<Color>? Colors { get; set; }
        public DbSet<Size>? Sizes { get; set; }
        public DbSet<ProductColor>? ProductColors { get; set; }
        public DbSet<ProductSize>? ProductSizes { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        
        public DbSet<Gallery> Galleries { get; set; }
    }
   
}
