using QuanLyNhaXe.DTOS;
using QuanLyNhaXe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.Services
{
    public interface IXeService
    {
        Task<bool> ThemXe(InputXe inputXe);

        Task<bool> XoaXe(string BienSo);

        Task<bool> SuaXe(string BSXE,Editxe editxe);
    }
    public class XeService : IXeService
    {
        private readonly MyDbContext _context;
        public XeService(MyDbContext myDbContext)
        {
            _context = myDbContext;
        }
        /// <summary>
        /// Thêm Xe 
        /// </summary>
        /// <param name="inputXe"></param>
        /// <returns></returns>
        public async Task<bool> ThemXe(InputXe inputXe)
        {
            if (inputXe == null)
                return false;
            var check = await _context.Xes.FindAsync(inputXe.BienSoXe);
            if (check != null)
                return false;
            var loaixe = _context.LoaiXes.Where(lx=>lx.TenLoaiXe==inputXe.TenLoaiXe).FirstOrDefault();
            if (loaixe == null)
                return false;
            else
            {
                await _context.Xes.AddAsync(new Xe
                {
                    BienSoXe = inputXe.BienSoXe,                  
                    SoChuyenDi = 0,
                    MSLoaiXe = loaixe.MSLoaiXe,
                    Status = 0,
                    NgayVaoBai = DateTime.Now,
                    NgayXuatBai = null
                });
            }
            await _context.SaveChangesAsync();
            return true;
        }
        /// <summary>
        /// Sửa Thông Tin Xe
        /// </summary>
        /// <param name="inputXe"></param>
        /// <returns></returns>       
        public async Task<bool> XoaXe(string BienSo)
        {
            if (BienSo == null)
                return false;
            var xe = await _context.Xes.FindAsync(BienSo);
            if (xe == null)
                return false;
            _context.Remove(xe);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> SuaXe (string BSXE,Editxe editxe)
        {
            if (editxe == null)
                return false;
            else
            {
                var xe = await _context.Xes.FindAsync(BSXE);
                var loaixe = _context.LoaiXes.Where(lx => lx.TenLoaiXe == editxe.TenLoaiXe).FirstOrDefault();
                if (xe == null)
                    return false;
                if (loaixe == null)
                    return false;
                xe.MSLoaiXe = loaixe.MSLoaiXe;
                await _context.SaveChangesAsync();
                return true;
            }                  
        }
    }
}
