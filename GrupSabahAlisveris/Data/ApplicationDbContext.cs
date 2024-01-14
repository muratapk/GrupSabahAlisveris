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

    }
   
}
