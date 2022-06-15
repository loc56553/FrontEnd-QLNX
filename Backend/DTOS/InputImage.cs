using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.DTOS
{
    public class InputImage
    {
        public string MSNV { get; set; }

        public IFormFile ImgageFile { get; set; }
    }
}
