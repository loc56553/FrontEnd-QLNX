using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.DTVS
{
    public class ChucVuView
    {
        public string TenChucVu { get; set; }
        [Display(Name = "Tên Viết Tắt")]
        [MaxLength(5, ErrorMessage = "Tối Đa 5 Ký Tự")]
        public string VietTatChucVu { get; set; }
        [Display(Name = "Mức Độ Truy Cập")]
        public int MucDoTruyCap { get; set; }
    }
}
