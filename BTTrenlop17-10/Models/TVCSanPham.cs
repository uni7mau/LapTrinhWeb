using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTTrenlop17_10.Models
{
    [Table("TVCSanPham")]
    public class TVCSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TVCId { get; set; }

        [Display(Name="Ma san pham")]
        public string TVCMasanPham { get; set; }
        
        [Display(Name="Ten san pham")]
        public string TVCTenSanPham { get; set; }
        
        [Display(Name="Hinh anh")]
        public string TVCHinhAnh { get; set; }
        
        [Display(Name="So luong")]
        public string TVCSoLuong { get; set; }
        
        [Display(Name="Don gia")]
        public string TVCDonGia { get; set; }
        
        public long TVCLoaiSanPhamId { get; set; }
        
        public TVCLoaiSanPham TVCLoaiSanPham { get; set; }
    }
}
