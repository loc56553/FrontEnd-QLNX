using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.DTOS
{
    public class InputVeXe
    {
        [Required]
        [Display(Name ="MaCX")]
        public string MaCX { get; set; }
        [Required]
        [Display(Name = "Số Ghế")]
        public string soGhe { get; set; }
        [Required]
        [Display(Name = "Tình Trạng Thanh Toán")]
        public int ThanhToan { get; set; } // 0 là chưa , 1 là đã thanh toán
        [Required]
        [Display(Name = "Tên Khách Hàng")]
        public string tenKH { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required]
        [Display(Name = "Số Điện Thoại")]
        public string SDT { get; set; }
        [Required]
        [Display(Name = "Năm Sinh Khách Hàng")]
        public string NgaySinhKH { get; set; }
        public string NgayDi { get; set; }
        [Display(Name = "Khứ Hồi")]
        public bool isRoundTrip { get; set; }
    }
}
