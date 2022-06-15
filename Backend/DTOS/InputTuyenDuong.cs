using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.DTOS
{
    public class InputTuyenDuong
    {
        [Required]
        [Display(Name = "Điểm Đi")]
        public string DiemDi { get; set; }
        [Required]
        [Display(Name = "Điểm Đến")]
        public string DiemDen { get; set; }
    }
}
