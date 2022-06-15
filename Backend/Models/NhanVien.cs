using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.Models
{
    //Thêm 
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        [Required]
        [Display(Name ="Mã Số Nhân Viên")]
        public string MSNV { get; set; }
        [Required]
        [Display(Name = "Họ Và Tên")]
        [MaxLength(30,ErrorMessage ="Tối đa chỉ được 30 ký tự")]
        public string HoTen { get; set; }
        [Column(TypeName ="datetime")]
        [Display(Name = "Năm Sinh")]
        public DateTime? NgaySinh { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [Required]
        [Display(Name = "Số Điện Thoại")]
        public string SoDienThoai { set; get; }
        [Display(Name = "Giới Tính")]
        public int GioiTinh { set; get; }
        [Display(Name = "CMND")]
        public string CMND { set; get; }
        [Required]
        public string MSChucVu { get; set; }
        public virtual UserIdentity UserIdentity { get; set; }
        [ForeignKey("MSChucVu")]
        public virtual ChucVuUser ChucVuUser { get; set; }

        public virtual ImageUser ImageUser { get; set; }

    }
}
