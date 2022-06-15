using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.DTVS
{
    public class MessageReponse
    {
        [Required]
        [Display(Name = "Kết quả trả về ")]
        public bool rs { get; set; }
        [Required]
        [Display(Name ="Thông báo trả về")]
        public string message { get; set; }
    }
}
