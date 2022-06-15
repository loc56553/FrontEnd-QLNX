using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.DTVS
{
    public class XeView
    {
        public string BienSoXe { get; set; }

        public string TenLoaiXe { get; set; }

        public int Status { get; set; }

        public int SoChuyenDi { get; set; }

    }
}
