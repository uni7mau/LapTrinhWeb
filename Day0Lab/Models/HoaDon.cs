using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day0Lab.Models
{
    [Table("HOA_DON")]
    public class HoaDon
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("MaHoaDon")]
        [Required]
        [StringLength(50)]
        public string MaHoaDon { get; set; } = string.Empty;
        [Column("MaKhaHang")]
        public int? MaKhaHang { get; set; }
        [Column("NgayHoaDon")]
        public DateTime? NgayHoaDon { get; set; }
        [Column("NgayNhan")]
        public DateTime? NgayNhan { get; set; }
        [Column("HoTenKhachHang")]
        [StringLength(200)]
        public string? HoTenKhachHang { get; set; }
        [Column("Email")]
        [StringLength(100)]
        public string? Email { get; set; }
        [Column("DienThoai")]
        [StringLength(20)]
        public string? DienThoai { get; set; }
        [Column("DiaChi")]
        [StringLength(500)]
        public string? DiaChi { get; set; }
        [Column("TongTriGia", TypeName = "decimal(18, 2)")]
        public decimal? TongTriGia { get; set; }
        [Column("TrangThai")]
        public int? TrangThai { get; set; }

        [ForeignKey("MaKhaHang")]
        public virtual KhachHang? KhachHang { get; set; }
        public virtual QuanTri? QuanTri { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
    }
}
