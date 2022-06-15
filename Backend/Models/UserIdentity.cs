using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.Models
{
    public class UserIdentity:IdentityUser
    {
        public int MucDoTruyCap { get; set; }
        [Display(Name = "Trạng Thái")] 
        public int Status { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
