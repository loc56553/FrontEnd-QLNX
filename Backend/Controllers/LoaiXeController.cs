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
    public class LoaiXeController : ControllerBase
    {
        private readonly ILoaiXeService _loaiXeService;
        private readonly MyDbContext _myDbConText;
        public LoaiXeController(ILoaiXeService loaiXeService, MyDbContext myDbContext)
        {
            _loaiXeService = loaiXeService;
            _myDbConText = myDbContext;
        }
        // GET: api/<LoaiXeController>
        [HttpGet]
        public IEnumerable<LoaiXe> DanhSachLoaiXe()
        {
            return _myDbConText.LoaiXes.Select(lx => new LoaiXe
            {
                MSLoaiXe = lx.MSLoaiXe,
                TenLoaiXe = lx.TenLoaiXe,
                SoGhe=lx.SoGhe
            }).ToList();
        }

        // GET api/<LoaiXeController>/5
        [HttpGet("{MSLX}")]
        public async Task<IActionResult> GetLxByMSLX(string MSLX)
        {
            var kq = new MessageReponse();
            var kqlx = new LoaiXeView();
            if (MSLX==null)
            {
                kq.rs = false;
                kq.message = "Cần nhập đầy đủ thông tin để lấy dữ liệu";
                return BadRequest(kq);
            }
            else
            {
                var lx = await _myDbConText.LoaiXes.FindAsync(MSLX);
                if(lx!=null)
                {
                    kqlx.MSLX = lx.MSLoaiXe;
                    kqlx.TenLoaiXe = lx.TenLoaiXe;
                    kqlx.SoGhe = lx.SoGhe;
                    return Ok(kqlx);
                }
                else
                {
                    kq.rs = false;
                    kq.message = $"Không tìm thấy thông tin loại xe có MSLX:{MSLX}";
                    return NotFound(kq);
                }    
            }
        }

        // POST api/<LoaiXeController>
        /// <summary>
        /// Thêm Loại Xe
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public async Task<IActionResult> ThemLoaiXe ([FromBody] InputLoaiXe inputLoaiXe)
        {
            if(ModelState.IsValid)
            {
                var kq = await _loaiXeService.ThemLoaiXe(inputLoaiXe);
                if (kq.rs)
                    return Ok(kq);
                else
                    return BadRequest(kq);
            }
            return BadRequest("Có lỗi xảy ra trong quá trình xác thực dữ liệu");
        }

        // PUT api/<LoaiXeController>/5
        /// <summary>
        /// Sửa loại xe 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{MSLX}")]
        public async Task<IActionResult> SuaLoaiXe (string MSLX, [FromBody] EditLoaiXe editLoaiXe)
        {
            if(ModelState.IsValid)
            {
                var kq = await _loaiXeService.SuaLoaiXe(MSLX, editLoaiXe);
                if (kq.rs)
                    return Ok(kq);
                else
                    return BadRequest(kq);
            }
            return BadRequest(error: new { message = "Có vấn đề xảy ra khi cập nhật dữ liệu" });
        }

        // DELETE api/<LoaiXeController>/5
        /// <summary>
        /// Xóa loại xe
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{MSLX}")]
        public async Task<IActionResult> XoaLoaiXe(string MSLX)
        {
            if(ModelState.IsValid)
            {
                var kq = await _loaiXeService.XoaLoaiXe(MSLX);
                if (kq.rs)
                    return Ok(kq);
                else
                    return BadRequest(kq);
            }
            return BadRequest(error: new { message = "Dữ liệu cập nhật không thành công" });
        }
    }
}
