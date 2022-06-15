using QuanLyNhaXe.DTOS;
using QuanLyNhaXe.DTVS;
using QuanLyNhaXe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.Services
{
   public interface ILoaiXeService
    {
        Task<MessageReponse> ThemLoaiXe(InputLoaiXe inputLoaiXe);

        Task<MessageReponse> SuaLoaiXe(string MSLX, EditLoaiXe editLoaiXe);

        Task<MessageReponse> XoaLoaiXe(string MSLX);
    }
    public class LoaiXeService : ILoaiXeService
    {
        private readonly MyDbContext _myDbContext;

        public LoaiXeService(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        /// <summary>
        /// Thêm Loại Xe
        /// </summary>
        /// <param name="inputLoaiXe"></param>
        /// <returns></returns>
        public async Task<MessageReponse> ThemLoaiXe(InputLoaiXe inputLoaiXe)
        {
            var check = _myDbContext.LoaiXes.Where(lx => lx.TenLoaiXe == inputLoaiXe.TenLoaiXe).FirstOrDefault();
            if (check != null)
                return new MessageReponse {
                rs=false,
                message=$"Đã tồn tại loại xe có tên là :{inputLoaiXe.TenLoaiXe}"};
            if (inputLoaiXe == null)
                return new MessageReponse
                {
                    rs = false,
                    message = "Vui lòng nhập đầy đủ thông tin để thêm mới loại xe"
                };
            var MsCuoi = _myDbContext.LoaiXes.Max(lx=>lx.MSLoaiXe);
            int count = Convert.ToInt32(MsCuoi.Substring(4));
            count++;
            await _myDbContext.LoaiXes.AddAsync(new LoaiXe
            {
                MSLoaiXe = $"MSLX00{count}",
                TenLoaiXe = inputLoaiXe.TenLoaiXe,        
                SoGhe=Convert.ToInt32(inputLoaiXe.SoGhe)
            });
            await _myDbContext.SaveChangesAsync();
            return new MessageReponse { 
            rs=true,
            message=$"Đã thêm mới thành công loại xe có tên loại xe :{inputLoaiXe.TenLoaiXe}"
            };
        }
        
        public async Task<MessageReponse> SuaLoaiXe(string MSLX ,EditLoaiXe editLoaiXe)
        {
            if (editLoaiXe == null)
                return new MessageReponse { 
                rs=false,
                message="Cần nhập đầy đủ thông tin sửa thông tin xe"
                };
            var check = await _myDbContext.LoaiXes.FindAsync(MSLX);
            if (check == null)
                return new MessageReponse { 
                rs=false,
                message=$"Loại xe có MSLX:{MSLX} không tồn tại"
                };
            check.TenLoaiXe = editLoaiXe.TenLoaiXe;
            check.SoGhe = Convert.ToInt32(editLoaiXe.SoGhe);
            await _myDbContext.SaveChangesAsync();
            return new MessageReponse { 
            rs=true,
            message="Sửa thông tin thành công"
            };
        }
        public async Task<MessageReponse> XoaLoaiXe(string MSLX)
        {
            var check = await _myDbContext.LoaiXes.FindAsync(MSLX);
            if (check == null)
                return new MessageReponse { 
                rs=false,
                message=$"Loại xe có MSLX:{MSLX} không tồn tại"
                };
            _myDbContext.Remove(check);
            await _myDbContext.SaveChangesAsync();
            return new MessageReponse { 
            rs=true,
            message="Đã xóa thành công"
            };
        }
    }
}
