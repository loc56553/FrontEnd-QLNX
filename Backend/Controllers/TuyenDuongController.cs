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
    public class TuyenDuongController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly ITuyenDuongService _tuyenDuongService;

        public TuyenDuongController(MyDbContext myDbContext , ITuyenDuongService tuyenDuongService)
        {
            _context = myDbContext;
            _tuyenDuongService = tuyenDuongService;
        }

        // GET: api/<TuyenDuongController>
        [HttpGet]
        public IEnumerable<TuyenDuongView> Get()
        {
            return _context.TuyenDuongs.Select(td => new TuyenDuongView
            {
            MSTD=td.MSTD,
            TenTD=td.TenTD,
            DiemDi=td.DiemDi,
            DiemDen=td.DiemDen
            }).ToList();
        }
        [HttpGet("{MSTD}")]
        public async Task<IActionResult> Get(string MSTD)
        {
            var cx = await _context.TuyenDuongs.FindAsync(MSTD);
            if (cx == null)
                return BadRequest($"Không có chuyến xe có MSTD : {MSTD}");
            else
                return Ok(new TuyenDuongView
                {
                    DiemDi=cx.DiemDi,
                    DiemDen=cx.DiemDen
                });
        }

        // GET api/<TuyenDuongController>/5
        [HttpPost("TimKiemTD")]
        public IActionResult PostTD ([FromBody] InputTuyenDuong inputTuyenDuong)
        {
            if (inputTuyenDuong == null)
                return BadRequest("Vui lòng nhập MSTD để tiến hành kiểm tra");
            else
            {
                var td = _context.TuyenDuongs.Where(td => td.TenTD==($"{inputTuyenDuong.DiemDi} - {inputTuyenDuong.DiemDen}")).FirstOrDefault();
                if (td == null)
                {
                    return BadRequest($"Không tìm thầy tuyến đường {inputTuyenDuong.DiemDi} - {inputTuyenDuong.DiemDen}");
                }
                return Ok(td);
            }
        }

        // POST api/<TuyenDuongController>
        /// <summary>
        /// Thêm Tuyến Đường
        /// </summary>
        /// <param name="inputTuyenDuong"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InputTuyenDuong inputTuyenDuong)
        {
            var kq = await _tuyenDuongService.ThemTuyenDuong(inputTuyenDuong);
            if (ModelState.IsValid)
            {
                if (kq.rs)
                    return Ok(kq);
                else
                    return BadRequest(kq.message);
            }
            return BadRequest("Có lỗi xảy ra khi cập nhật dữ liệu");
        }

        // PUT api/<TuyenDuongController>/5
        [HttpPut("{MSTD}")]
        public async Task<IActionResult> Put(string MSTD, [FromBody] EditTuyenDuong editTuyenDuong)
        {
            if (ModelState.IsValid)
            {
                var kq = await _tuyenDuongService.SuaTuyenDuong(MSTD, editTuyenDuong);
                if (kq.rs)
                    return Ok(kq);
                else
                    return BadRequest(kq.message);
            }
            else
                return BadRequest("Quá trình cập nhật dữ liệu xảy ra lỗi");
        }

        // DELETE api/<TuyenDuongController>/5
        [HttpDelete("{MSTD}")]
        public async Task<IActionResult> Delete(string MSTD)
        {
            if (ModelState.IsValid)
            {
                var kq = await _tuyenDuongService.XoaTuyenDuong(MSTD);
                if (kq.rs)
                    return Ok(kq);
                else
                    return BadRequest(kq);
            }
            else
                return BadRequest("Đã xảy ra lỗi trong qua trình thay đổi dữ liệu");
        }
    }
}
