using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTTrenlop17_10.Models
{
    [Table("TVCLoaiSanPham")]
    [Index(nameof(TVCMaLoai))]
    public class TVCLoaiSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PVCId { get; set; }

        [Display(Name="Ma loai")]
        [StringLength(50)]
        public string TVCMaLoai { get; set; }

        [Display(Name="Ten loai")]
        public string TVCTenLoai { get; set; }

        [Display(Name="Trang thai")]
        public bool TVCTrangThai { get; set; }

        public ICollection<TVCSanPham> TVCSanPhams { get; set; }
    }
}
