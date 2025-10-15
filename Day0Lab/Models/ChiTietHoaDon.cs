using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day0Lab.Models
{
    [Table("CT_HOA_DON")]
    public class ChiTietHoaDon
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("HoaDonID")]
        public int? HoaDonID { get; set; }
        [Column("SanPhamID")]
        public int? SanPhamID { get; set; }
        [Column("SoLuongMua")]
        public int? SoLuongMua { get; set; }
        [Column("DonGiaMua", TypeName = "decimal(18, 2)")]
        public decimal? DonGiaMua { get; set; }
        [Column("ThanhTien", TypeName = "decimal(18, 2)")]
        public decimal? ThanhTien { get; set; }
        [Column("TrangThai")]
        public int? TrangThai { get; set; }

        [ForeignKey("HoaDonID")]
        public virtual HoaDon? HoaDon { get; set; }
        [ForeignKey("SanPhamID")]
        public virtual SanPham? SanPham { get; set; }
    }
}
