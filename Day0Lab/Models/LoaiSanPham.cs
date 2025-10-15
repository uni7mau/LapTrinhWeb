using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day0Lab.Models
{
    [Table("LOAI_SAN_PHAM")]
    public class LoaiSanPham
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("MaLoai")]
        [Required]
        [StringLength(50)]
        public string MaLoai { get; set; } = string.Empty;
        [Column("TenLoai")]
        [StringLength(200)]
        public string? TenLoai { get; set; }
        [Column("TrangThai")]
        public int? TrangThai { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
    }
}
