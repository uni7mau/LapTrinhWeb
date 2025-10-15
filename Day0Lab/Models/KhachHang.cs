using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day0Lab.Models
{
    [Table("KHACH_HANG")]
    public class KhachHang
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("MaKhachHang")]
        [Required]
        [StringLength(50)]
        public string MaKhachHang { get; set; } = string.Empty;
        [Column("HoTenKhachHang")]
        [StringLength(200)]
        public string? HoTenKhachHang { get; set; }
        [Column("Email")]
        [StringLength(100)]
        public string? Email { get; set; }
        [Column("MaKhau")]
        [StringLength(100)]
        public string? MaKhau { get; set; }
        [Column("DienThoai")]
        [StringLength(20)]
        public string? DienThoai { get; set; }
        [Column("DiaChi")]
        [StringLength(500)]
        public string? DiaChi { get; set; }
        [Column("NgayDangKy")]
        public DateTime? NgayDangKy { get; set; }
        [Column("TrangThai")]
        public int? TrangThai { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
    }
}
