using APISeries.Models;
using Microsoft.EntityFrameworkCore;

namespace APISeries.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<SeriesModel> Serie { get; set; }
        public DbSet<CategoriaModel> Categoria { get; set; }
    }
}
