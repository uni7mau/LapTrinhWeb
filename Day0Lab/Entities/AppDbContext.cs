using Day0Lab.Models;
using Microsoft.EntityFrameworkCore;

namespace Day0Lab.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<QuanTri> QuanTris { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<SanPham>()
                .HasOne(sp => sp.LoaiSanPham)
                .WithMany(lsp => lsp.SanPhams)
                .HasForeignKey(sp => sp.MaLoai)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<HoaDon>()
                .HasOne(hd => hd.KhachHang)
                .WithMany(kh => kh.HoaDons)
                .HasForeignKey(hd => hd.MaKhaHang)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ChiTietHoaDon>()
                .HasOne(ct => ct.HoaDon)
                .WithMany(hd => hd.ChiTietHoaDons)
                .HasForeignKey(ct => ct.HoaDonID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChiTietHoaDon>()
                .HasOne(ct => ct.SanPham)
                .WithMany(sp => sp.ChiTietHoaDons)
                .HasForeignKey(ct => ct.SanPhamID)
                .OnDelete(DeleteBehavior.SetNull);

            // Seed initial data (optional)
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed QuanTri
            modelBuilder.Entity<QuanTri>().HasData(
                new QuanTri { Id = 1, TaiKhoan = "admin", MatKhau = "123456", TrangThai = 1 }
            );

            // Seed LoaiSanPham
            modelBuilder.Entity<LoaiSanPham>().HasData(
                new LoaiSanPham { Id = 1, MaLoai = "LSP001", TenLoai = "Điện thoại", TrangThai = 1 },
                new LoaiSanPham { Id = 2, MaLoai = "LSP002", TenLoai = "Laptop", TrangThai = 1 },
                new LoaiSanPham { Id = 3, MaLoai = "LSP003", TenLoai = "Phụ kiện", TrangThai = 1 }
            );

            // Seed SanPham
            modelBuilder.Entity<SanPham>().HasData(
                new SanPham
                {
                    Id = 1,
                    MaSanPham = "SP001",
                    TenSanPham = "iPhone 15 Pro",
                    SoLuong = 50,
                    DonGia = 29990000,
                    MaLoai = 1,
                    TrangThai = 1
                },
                new SanPham
                {
                    Id = 2,
                    MaSanPham = "SP002",
                    TenSanPham = "Samsung Galaxy S24",
                    SoLuong = 40,
                    DonGia = 22990000,
                    MaLoai = 1,
                    TrangThai = 1
                },
                new SanPham
                {
                    Id = 3,
                    MaSanPham = "SP003",
                    TenSanPham = "MacBook Pro M3",
                    SoLuong = 20,
                    DonGia = 45990000,
                    MaLoai = 2,
                    TrangThai = 1
                }
            );

            // Seed KhachHang
            modelBuilder.Entity<KhachHang>().HasData(
                new KhachHang
                {
                    Id = 1,
                    MaKhachHang = "KH001",
                    HoTenKhachHang = "Nguyễn Văn A",
                    Email = "nguyenvana@email.com",
                    DienThoai = "0901234567",
                    DiaChi = "Hà Nội",
                    NgayDangKy = DateTime.Now,
                    TrangThai = 1
                }
            );
        }
    }
}
