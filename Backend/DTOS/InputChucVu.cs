using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.DTOS
{
    public class InputChucVu
    {
        [Required]
        [Display(Name = "Chức Vụ")]
        [MaxLength(20, ErrorMessage = "Tối Đa 20 Ký Tự")]
        public string TenChucVu { get; set; }
        [Required]
        [Display(Name = "Tên Viết Tắt")]
        [MaxLength(5, ErrorMessage = "Tối Đa 5 Ký Tự")]
        public string VietTatChucVu { get; set; }
        public string MucDoTruyCap { get; set; }
    }
}
