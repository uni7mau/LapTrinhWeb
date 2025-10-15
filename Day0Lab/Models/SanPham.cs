using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day0Lab.Models
{
    [Table("SAN_PHAM")]
    public class SanPham
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("MaSanPham")]
        [Required]
        [StringLength(50)]
        public string MaSanPham { get; set; } = string.Empty;
        [Column("TenSanPham")]
        [StringLength(200)]
        public string? TenSanPham { get; set; }
        [Column("HinhAnh")]
        [StringLength(500)]
        public string? HinhAnh { get; set; }
        [Column("SoLuong")]
        public int? SoLuong { get; set; }
        [Column("DonGia", TypeName = "decimal(18, 2)")]
        public decimal? DonGia { get; set; }
        [Column("MaLoai")]
        public int? MaLoai { get; set; }
        [Column("TrangThai")]
        public int? TrangThai { get; set; }

        [ForeignKey("MaLoai")]
        public virtual LoaiSanPham? LoaiSanPham { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
    }
}
