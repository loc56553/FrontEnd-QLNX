using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.Models
{
    [Table("ImageUser")]
    public class ImageUser
    {              
            [Key]
            public long Id { get; set; }
            [Required]
            public string MSNV { get; set; }

            public string ImagePath { get; set; }

            public long FileSize { get; set; }
            [ForeignKey("MSNV")]
            public virtual NhanVien NhanVien { get; set; }
        }
 }
