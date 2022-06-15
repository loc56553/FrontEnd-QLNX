using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.DTOS
{
    public class EditUser
    {
        public string HoTen { get; set; }
    
        public string NgaySinh { get; set; }
        
        public string SoDienThoai { get; set; }
        
        public string ChucVu { get; set; }
    }
}
