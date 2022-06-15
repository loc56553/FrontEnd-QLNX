using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.Models
{
    [Table("ChucVuUser")]
    public class ChucVuUser
    {
        [Key]
        [Required]
        [Display(Name = "Mã Số Chức Vụ")]
        public string MSChucVu { get; set; }
        [Required]
        [Display(Name = "Chức Vụ")]
        [MaxLength(20, ErrorMessage = "Tối Đa 20 Ký Tự")]
        public string TenChucVu { get; set; }
        [Required]
        [Display(Name = "Tên Viết Tắt")]
        [MaxLength(5, ErrorMessage = "Tối Đa 5 Ký Tự")]
        public string VietTatChucVu { get; set; }
        [DefaultValue(1)]
        [Display(Name ="Mức Độ Truy Cập")]
        public int MucDoTruyCap { get; set; }

        public virtual List<NhanVien> NhanViens { get; set; }
    }
}
