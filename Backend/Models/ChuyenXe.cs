using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.Models
{
    [Table("ChuyenXe")]
    public class ChuyenXe
    {
        [Key]
        [Required]
        [Display(Name ="Mã Chuyến Xe")]
        public string MaCX { get; set; }
        [Required]
        [Display(Name = "Giá Vé")]
        public string gia { get; set; }
        [Required]
        [Display(Name ="Ngày Đi")]
        public DateTime NgayDi { get; set; }
        [Display(Name ="Giờ Đi")]
        [Required]
        public DateTime GioDi { get; set; }
        [Required]
        [Display(Name ="Mã Tuyến Đường")]
        public string MaTD { get; set; } // Khóa ngoại của bảng TuyenDuong
        [Required]
        [Display(Name = "Mã Loại Xe")]
        public string MaLoaiXe { get; set; } // Khóa ngoại của bảng LoaiXe
        [ForeignKey("MaLoaiXe")]
        public virtual LoaiXe loaiXe { get; set; }
        [ForeignKey("MaTD")]
        public virtual TuyenDuong tuyenDuong { get; set; }
        public virtual List<Vexe> veXes { get; set; }

        public virtual List<GheNgoi> GheNgois { get; set; }
    }
}
