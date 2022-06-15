using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.DTVS
{
    public class TuyenDuongView
    {
        [Display(Name = "Mã Số Tuyến Đường")]
        public string MSTD { get; set; }
        [Display(Name = "Tên Tuyến Đường")]
        public string TenTD { get; set; }

        public string DiemDi { get; set; }

        public string DiemDen { get; set; }
    }
}
