using QuanLyNhaXe.DTOS;
using QuanLyNhaXe.DTVS;
using QuanLyNhaXe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.Services
{
    public interface IVeXeSerVice
    {
        Task<MessageReponse> ThemVeXe(InputVeXe inputVeXe);

        Task<MessageReponse> SuaVeXe(long MsVe, EditVeXe editVeXe);

        Task<MessageReponse> XoaVeXe(long MsVe);
    }
    public class VeXeSerVice : IVeXeSerVice
    {
        private readonly MyDbContext _context;

        public VeXeSerVice(MyDbContext context)
        {
            _context = context;
        }
        public async Task<MessageReponse> ThemVeXe(InputVeXe inputVeXe)
        {
            if (inputVeXe == null)
                return new MessageReponse
                {
                    rs = false,
                    message = "Cần nhập thông tin đầy đủ để tiến hành thêm thông tin vé xe"
                };
            else
            {
                //if (inputVeXe.isRoundTrip && inputVeXe.NgayDi == null)
                //    return new MessageReponse
                //    {
                //        rs = false,
                //        message = "Vui lòng nhập đầy đủ thông tin ngày về của vé có khứ hồi"
                //    };
                await _context.VeXes.AddAsync(new Vexe
                {
                    soGhe = inputVeXe.soGhe,
                    SDT = inputVeXe.SDT,
                    NgaySinh = DateTime.ParseExact(inputVeXe.NgaySinhKH, "yyyy-MM-dd", null),
                    tenKH = inputVeXe.tenKH,
                    MaCX=inputVeXe.MaCX,
                    NgayDi= DateTime.ParseExact(inputVeXe.NgayDi, "d/M/yyyy", null),
                    isRoundTrip =false,
                    ThanhToan=0
                });
                await _context.SaveChangesAsync();
                return new MessageReponse
                {
                    rs = true,
                    message = $"Đã đặt vé xe thành công có thông tin \n TenKH: {inputVeXe.tenKH} \n SDT:{inputVeXe.SDT}"
                };
            }
        }
        public async Task<MessageReponse> SuaVeXe (long MsVe,EditVeXe editVeXe)
        {
            if (editVeXe == null)
                return new MessageReponse
                {
                    rs = false,
                    message = "Vui lòng nhập đầy đủ thông tin để cập nhật thông tin vé xe"
                };
            var vx = await _context.VeXes.FindAsync(MsVe);
            if (vx == null)
                return new MessageReponse
                {
                    rs = false,
                    message = "Thông tin vé xe này không tồn tại"
                };
            else
            {
                if (editVeXe.MaCX != null)
                    vx.MaCX = editVeXe.MaCX;
                if (editVeXe.SDT != null)
                    vx.SDT = editVeXe.SDT;
                if (editVeXe.SoGhe != null)
                    vx.soGhe = editVeXe.SoGhe;
                await _context.SaveChangesAsync();
                return new MessageReponse
                {
                    rs = true,
                    message = $"Cập nhật thông tin vé xe thành công có thông tin \n Số Ghế:{editVeXe.SoGhe} \n Chuyến Xe:{vx.chuyenXe.tuyenDuong.TenTD} \n TênKH:{vx.tenKH}"
                };
            }    
        }
        public async Task<MessageReponse> XoaVeXe(long MsVe)
        {
            if (MsVe == 0)
                return new MessageReponse
                {
                    rs = false,
                    message = "Nhập thông tin vé xe để tiến hành hủy vé "
                };
            else
            {
                var vx = await _context.VeXes.FindAsync(MsVe);
                if (vx == null)
                    return new MessageReponse
                    {
                        rs = false,
                        message = "Không tìm thấy thông tin vé xe này"
                    };
                _context.VeXes.Remove(vx);
                await _context.SaveChangesAsync();
                return new MessageReponse
                {
                    rs = true,
                    message = $"Đã hủy thành công vé xe có thông tin \n TênKH:{vx.tenKH} \n Số Ghế:{vx.soGhe} "
                };
            }    
        }
    }
}
