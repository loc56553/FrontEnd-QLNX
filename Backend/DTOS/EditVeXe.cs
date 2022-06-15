using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.DTOS
{
    public class EditVeXe
    {
        [Display(Name ="Mã Chuyến Xe")]
       public string MaCX { get; set; }
        [Display(Name ="Số Ghế")]
       public string SoGhe { get; set; }
        [Display(Name ="Số Điện Thoại")]
       public string ? SDT { get; set; }
    }
}
