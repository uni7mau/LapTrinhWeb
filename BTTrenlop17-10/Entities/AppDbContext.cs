using BTTrenlop17_10.Models;
using Microsoft.EntityFrameworkCore;

namespace BTTrenlop17_10.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TVCLoaiSanPham> TVCLoaiSanPhams { get; set; }
        public DbSet<TVCSanPham> TVCSanPhams { get; set; }
    }
}
