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
        public DbSet<Colors>? Colors { get; set; }
        public DbSet<Sizes>? Sizes { get; set; }
        public DbSet<ProductColors>? ProductColors { get; set; }
        public DbSet<ProductSizes>? ProductSizes { get; set; }
    }
   
}
