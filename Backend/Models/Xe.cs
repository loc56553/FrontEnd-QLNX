using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.Models
{
    [Table("Xe")]
    public class Xe
    {
        [Key]
        [Required]
        [Display(Name ="Biển Số Xe")]
        [StringLength(9,ErrorMessage ="Biển Số Xe Chỉ Có 9 Ký Tự")]
        public string BienSoXe { get; set; }
        [DefaultValue(0)] // chưa xuất bến 0:chưa xuất bến 1: đã xuất bến 2: chờ xuất bến
        public int Status { get; set; }
        [DefaultValue(0)] //Thực hiện xuất bãi cộng 1 chuyến đi
        [Display(Name ="Số Chuyến Đi")]
        public int SoChuyenDi { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Ngày Xuất Bãi")]
        public DateTime? NgayXuatBai { get; set; }
        // Khởi tạo giá trị mặc định khi tạo mới.
        [DataType(DataType.Date)]
        [Display(Name = "Ngày Vào Bãi")]
        public DateTime? NgayVaoBai { get; set; }
        public string MSLoaiXe { get; set; }
        //FK của bảng Loai Xe
        [Required]
        [ForeignKey("MSLoaiXe")] //Đặt tên cho FK- mặc định nếu không set sẽ tự tạo theo tên PK trong bảng cha
        public virtual LoaiXe LoaiXe { get; set; } // Một xe chỉ thuộc về 1 Loại
    }
}
