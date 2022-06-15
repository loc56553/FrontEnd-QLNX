using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.DTOS
{
    public class DangKy
    {
        [Required]
        public string HoTen { get; set; }
        [Required]
        public string NgaySinh { get; set; }
        [Required]
        public string SoDienThoai { get; set; }
        [Required]
        public string ChucVu { get; set; }
    }
}
