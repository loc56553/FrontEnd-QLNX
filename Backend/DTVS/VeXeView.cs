using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.DTVS
{
    public class VeXeView
    {
        public long MsVe { get; set; }
        [Required]
        [Display(Name = "Số Ghế")]
        public string soGhe { get; set; }
        [Required]
        [Display(Name = "Tên Khách Hàng")]
        public string tenKH { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required]
        [Display(Name = "Số Điện Thoại")]
        public string SDT { get; set; }
        [Required]
        [Display(Name = "Ngày Sinh KH")]
        public string NgaySinh { get; set; }
        public string NgayDi { get; set; }
    }
}
