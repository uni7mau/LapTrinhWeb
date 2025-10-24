using Microsoft.EntityFrameworkCore;
using NguyenDucThach_231230898_de02.Models;

namespace NguyenDucThach_231230898_de02.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<NguyenDucThachCatalog> NguyenDucThachCatalogs { get; set; }
    }
}
