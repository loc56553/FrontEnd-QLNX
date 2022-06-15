using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.DTOS
{
    public class ChangePass
    {
        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassWord { get; set; }
        [Required]       
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        [Compare("PassWord")]
        [DataType(DataType.Password)]
        public string ComfirmPass { get; set; }
    }
}
