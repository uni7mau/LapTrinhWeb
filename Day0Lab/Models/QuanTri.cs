using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day0Lab.Models
{
    [Table("QUAN_TRI")]
    public class QuanTri
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("TaiKhoan")]
        [Required]
        [StringLength(100)]
        public string TaiKhoan { get; set; } = string.Empty;
        [Column("MatKhau")]
        [Required]
        [StringLength(100)]
        public string MatKhau { get; set; } = string.Empty;
        [Column("TrangThai")]
        public int? TrangThai { get; set; }
        
        public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
    }
}
