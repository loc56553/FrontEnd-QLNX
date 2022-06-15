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
    public class ChuyenXeController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IChuyenXeService _chuyenXeService;

        public ChuyenXeController(MyDbContext context, IChuyenXeService chuyenXeService)
        {
            _context = context;
            _chuyenXeService = chuyenXeService;
        }

        // GET: api/<ChuyenXeController>
        [HttpGet]
        public IEnumerable<ChuyenXeView> Get()
        {
            var kq = _context.ChuyenXes.Select(cx=>new ChuyenXeView { 
            MSCX=cx.MaCX,
            Gia=cx.gia,
            GioDi=cx.GioDi.ToShortTimeString(),
            NgayDi=cx.NgayDi.Date.ToString(),
            TenLX=cx.loaiXe.TenLoaiXe,
            TenTD=cx.tuyenDuong.TenTD
            }).ToList();
            return kq;
        }
        // GET api/<ChuyenXeController>/5
        [HttpGet("{MSCX}")]
        public async Task<IActionResult> Get(string MSCX)
        {
            var cx = await _context.ChuyenXes.FindAsync(MSCX);
            if (cx == null)
                return BadRequest($"Không có chuyến xe có MSCX : {MSCX}");
            else
                return Ok(new { 
                gia=cx.gia,
                GioDi=cx.GioDi,
                NgayDi=cx.NgayDi.ToShortDateString(),
                TenTuyenDuong=cx.tuyenDuong.TenTD,
                LoaiXe= cx.loaiXe.TenLoaiXe
                });
        }
        [HttpGet("GheDuoi/{MSCX}")]
        public IEnumerable<GheXeView> GetListGheDuoi(string MSCX)
        {
            List<GheXeView> ListGheDuoi = new List<GheXeView>();
            var kq =  _chuyenXeService.ListGhe(MSCX);
            foreach(var item in kq)
            {
                if(item.TenGhe.Contains("A"))
                {
                    ListGheDuoi.Add(item);
                }    
            }
            return ListGheDuoi;
        }
        [HttpGet("GheTren/{MSCX}")]
        public IEnumerable<GheXeView> GetListGheTren(string MSCX)
        {
            List<GheXeView> ListGheDuoi = new List<GheXeView>();
            var kq = _chuyenXeService.ListGhe(MSCX);
            foreach (var item in kq)
            {
                if (item.TenGhe.Contains("B"))
                {
                    ListGheDuoi.Add(item);
                }
            }
            return ListGheDuoi;
        }
        [HttpGet("OneGhe/{MSCX}/{tenGhe}")]
        public IActionResult GetGhe(string MSCX,string tenGhe)
        {
            if (MSCX == null && tenGhe == null)
                return BadRequest("Thông tin không hợp lệ");
            else
            {
                var kq =  _context.GheNgois.Where(cx => cx.MaCX == MSCX && cx.TenGhe == tenGhe).FirstOrDefault();
                return Ok(new GheXeView {
                MSGhe=kq.MSghe,
                TenGhe=kq.TenGhe,
                TrangThai=kq.status
                });
            }    
        }
        [HttpPut("OneGhe")]
        public async Task<IActionResult> EditGheXe([FromBody] EditGhe editGhe)
        {
            var kq = await _context.GheNgois.FindAsync(editGhe.msGhe);
            if (kq == null)
                return BadRequest("Không tìm thấy dữ liệu");
            else
            {
                kq.status = editGhe.trangThai;
                await _context.SaveChangesAsync();
                return Ok(new GheXeView { 
                MSGhe=kq.MSghe,
                TenGhe=kq.TenGhe,
                TrangThai=kq.status
                });
            }    
        }
        /// <summary>
        /// Thêm Chuyến Xe
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // POST api/<ChuyenXeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InputChuyenXe inputChuyenXe)
        {
            if (ModelState.IsValid)
            {
                var kq = await _chuyenXeService.ThemChuyenXe(inputChuyenXe);
                if (kq.rs)
                    return Ok(kq);
                else
                    return BadRequest(kq.message);
            }
            else
                return BadRequest("Có lỗi xảy ra trong quá trình cập nhật dữ liệu");
        }
        // PUT api/<ChuyenXeController>/5
        [HttpPut("{MSCX}")]
        public async Task<IActionResult> Put(string MSCX, [FromBody] EditChuyenXe editChuyenXe)
        {
            if (ModelState.IsValid)
            {
                var kq = await _chuyenXeService.SuaChuyenXe(editChuyenXe, MSCX);
                if (kq.rs)
                    return Ok(kq.message);
                else
                    return BadRequest(kq.message);
            }
            else
                return BadRequest("Đã có lỗi xảy ra trong quá trình cập nhật dữ liệu");

        }

        // DELETE api/<ChuyenXeController>/5
        [HttpDelete("{MSCX}")]
        public async Task<IActionResult> Delete(string MSCX)
        {
            if (ModelState.IsValid)
            {
                var kq = await _chuyenXeService.XoaChuyenXe(MSCX);
                if (kq.rs)
                    return Ok(kq);
                else
                    return BadRequest(kq.message);
            }
            else
            {
                return BadRequest("Quá trình xử lý cơ sở dữ liệu bị lỗi");
            }    
        }
        // Search Data
        [HttpGet("SearchChuyenXe1/{maTD}/{ngayDi}/{tenLX}")]
        public IActionResult SearchChuyenXe1(string maTD, string ngayDi,string tenLX)
        {
            var kq = _chuyenXeService.SearchChuyenXe(maTD, ngayDi,tenLX);
            if (kq != null)
                return Ok(kq);
            else
                return NotFound("Không tìm thấy thông tin chuyến xe");
        }
    }
}
