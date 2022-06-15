using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.Models
{
    [Table("TuyenDuong")]
    public class TuyenDuong
    {
        [Key]
        [Required]
        [Display(Name ="Mã Số Tuyến Đường")]
        public string MSTD { get; set; }
        [Required]
        [Display(Name ="Tên Tuyến Đường")]
        public string TenTD { get; set; }
        [Required]
        [Display(Name ="Điểm Đi")]
        public string DiemDi { get; set; }
        [Required]
        [Display(Name ="Điểm Đến")]
        public string DiemDen { get; set; }

        public virtual List<ChuyenXe> chuyenXes { get; set; }
    }
}
