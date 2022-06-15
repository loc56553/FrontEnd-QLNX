using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.Models
{
    [Table("GheNgoi")]
    public class GheNgoi
    {
        [Key]
        [Required]
        [Display(Name ="Mã Số Ghế")]
        public int MSghe { get; set; }
        [Required]
        [Display(Name = "Tên Ghế")]
        public string TenGhe { get; set; }
        [Required]
        [Display(Name = "Trạng Thái")]
        public int status { get; set; }
        public string MaCX { get; set; }
        [ForeignKey("MaCX")]
        public virtual ChuyenXe ChuyenXe { get; set; }
    }
}
