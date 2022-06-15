using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.DTVS
{
    public class UserProFile
    {    
        public string HoTen { get; set; }
        [Required]
        public string NgaySinh { get; set; }
        [Required]
        public string SoDienThoai { get; set; }
        [Required]
        public string ChucVu { get; set; }
        [Required]
        public string UserName { get; set; }

        public int GioiTinh { get; set; }

        public string Token { get; set; }
    }
}
