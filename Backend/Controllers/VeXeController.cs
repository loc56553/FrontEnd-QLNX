using Microsoft.AspNetCore.Mvc;
using QuanLyNhaXe.DTOS;
using QuanLyNhaXe.DTVS;
using QuanLyNhaXe.Models;
using QuanLyNhaXe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuanLyNhaXe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeXeController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IVeXeSerVice _veXeSerVice;

        public VeXeController(MyDbContext context, IVeXeSerVice veXeSerVice)
        {
            _context = context;
            _veXeSerVice = veXeSerVice;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{MSCX}")]
        public IActionResult Get(string MSCX)
        {
           var kq = _context.VeXes.Where(vx => vx.MaCX == MSCX).Select(vx => new {
            TenKH=vx.tenKH,
            SDT=vx.SDT,
            NamSinhKH=vx.NgaySinh,
            NgayDi=vx.chuyenXe.NgayDi,
            GioDi=vx.chuyenXe.GioDi,
            SoGhe=vx.soGhe,
            ThanhToan=vx.ThanhToan,
            GiaVe=vx.chuyenXe.gia
            }).ToList();
            if (kq.Count == 0)
                return BadRequest("Hiện không có vé xe nào thuốc chuyến xe này ");
            return Ok(kq);
        }
        [HttpGet("{SDT}")]
        public IActionResult GetVeBySDT(string SDT)
        {
            var kq = _context.VeXes.Where(vx => vx.SDT == SDT).Select(vx => new {
                MSCX=vx.MaCX,
                TenKH = vx.tenKH,
                SDT = vx.SDT,
                NamSinhKH = vx.NgaySinh,
                TuyenDuong=vx.chuyenXe.tuyenDuong.TenTD,
                NgayDi = vx.chuyenXe.NgayDi,
                GioDi = vx.chuyenXe.GioDi,
                SoGhe = vx.soGhe,
                GiaVe = vx.chuyenXe.gia
            }).ToList();
            if (kq.Count == 0)
                return BadRequest("Hiện không có vé xe nào thuốc chuyến xe này ");
            return Ok(kq);
        }
        [HttpGet("{MSCX}/{SoGhe}")]
        public IActionResult Get(string MSCX , string SoGhe)
        {
            var kq = _context.VeXes.Where(vx => vx.MaCX.Equals(MSCX) && vx.soGhe.Equals(SoGhe)).FirstOrDefault();
            if (kq == null)
                return BadRequest("Không tồn tại vé xe có thông tin này");
            else
                return Ok(new VeXeView
                {
                    MsVe = kq.MsVe,
                    soGhe = kq.soGhe,
                    tenKH = kq.tenKH,
                    SDT = kq.SDT,
                    NgaySinh = kq.NgaySinh.ToShortDateString(),
                    NgayDi=kq.NgayDi.ToShortDateString() 
                });
        }
        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InputVeXe inputVeXe)
        {
            if(ModelState.IsValid)
            {
                var kq = await _veXeSerVice.ThemVeXe(inputVeXe);
                if (kq.rs)
                    return Ok(kq);
                else
                    return BadRequest(kq.message);
            }
            else
            {
                return BadRequest("Đã có lỗi xảy ra trong quá trình cập nhật dữ liệu");
            }    
        }
        // PUT api/<ValuesController>/5
        [HttpPut("{MsVe}")]
        public async Task<IActionResult> Put(long MsVe, [FromBody] EditVeXe editVeXe)
        {
            if(ModelState.IsValid)
            {
                var kq = await _veXeSerVice.SuaVeXe(MsVe, editVeXe);
                if (kq.rs)
                    return Ok(kq);
                else
                    return BadRequest(kq);
            }
            else
            {
                return BadRequest("Đã có lỗi xảy ra trong quá trình cập nhật dữ liệu");
            }    
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{MsVe}")]
        public async Task<IActionResult> Delete(long MsVe)
        {
            if(ModelState.IsValid)
            {
                var kq = await _veXeSerVice.XoaVeXe(MsVe);
                if (kq.rs)
                    return Ok(kq);
                else
                    return BadRequest(kq);
            }   
            else
            {
                return BadRequest("Đã có lỗi xảy ra trong quá trình cập nhật dữ liệu");
            }    
        }
    }
}
