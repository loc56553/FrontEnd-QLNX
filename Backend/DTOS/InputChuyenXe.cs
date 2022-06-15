using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.DTOS
{
    public class InputChuyenXe
    {
        [Required]
        [Display(Name = "Giá Vé")]
        public string Gia { get; set; }
        [Required]
        [Display(Name = "Ngày Đi")]
        public string NgayDi { get; set; }
        [Display(Name = "Giờ Đi")]
        [Required]
        public string GioDi { get; set; }
        [Required]
        [Display(Name = "Tên Tuyến Đường")]
        public string TenTD { get; set; } // Khóa ngoại của bảng TuyenDuong
        [Required]
        [Display(Name = "Tên Loại Xe")]
        public string tenLX { get; set; } // Khóa ngoại của bảng LoaiXe
    }
}
