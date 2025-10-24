using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenDucThach_231230898_de02.Models
{
    [Table("NguyenDucThachCatalog")]
    public class NguyenDucThachCatalog
    {
        [Key]
        public int hvtId { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        public string hvtCateName { get; set; }

        [Range(100, 5000, ErrorMessage = "Giá phải nằm trong khoảng 100 đến 5000")]
        public double hvtCatePrice { get; set; }

        public int hvtCateQty { get; set; }

        [RegularExpression(@".*\.(jpg|png|gif|tiff)$", ErrorMessage = "Chỉ chấp nhận ảnh .jpg, .png, .gif, .tiff")]
        public string hvtPicture { get; set; }

        public bool hvtCateActive { get; set; }
    }
}
