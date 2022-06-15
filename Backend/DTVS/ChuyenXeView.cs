﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.DTVS
{
    public class ChuyenXeView
    {
        [Display(Name = "MSCX")]
        public string MSCX { get; set; }
        [Display(Name = "Tên Tuyến Đường")]
        public string TenTD { get; set; }
        [Display(Name = "Ngày Đi")]
        public string NgayDi { get; set; }
        [Display(Name = "Tên Loại Xe")]
        public string TenLX { get; set; }

        [Display(Name = "Giờ Đi")]
        public string GioDi { get; set; }
        [Display(Name = "Giá Vé")]
        public string Gia { get; set; }

    }
}
