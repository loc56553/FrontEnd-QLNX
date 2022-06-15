using QuanLyNhaXe.DTOS;
using QuanLyNhaXe.DTVS;
using QuanLyNhaXe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.Services
{
    public interface ITuyenDuongService
    {
        Task<MessageReponse> ThemTuyenDuong(InputTuyenDuong inputTuyenDuong);

        Task<MessageReponse> SuaTuyenDuong(string MSTD, EditTuyenDuong editTuyenDuong);

        Task<MessageReponse> XoaTuyenDuong(string MSTD);
    }

    public class TuyenDuongService : ITuyenDuongService
    {
        private readonly MyDbContext _context;

        public TuyenDuongService(MyDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Thêm Tuyến Đường
        /// </summary>
        /// <param name="inputTuyenDuong"></param>
        /// <returns></returns>
        public async Task<MessageReponse> ThemTuyenDuong(InputTuyenDuong inputTuyenDuong)
        {
            if (inputTuyenDuong.DiemDi == null && inputTuyenDuong.DiemDen == null)
                return new MessageReponse
                {
                    rs = false,
                    message = "Thông tin Điểm Đi và Điểm Đên cần nhập đầy đủ để thiết lập"
                };
            var checkTD = _context.TuyenDuongs.Where(td => td.TenTD == ($"{inputTuyenDuong.DiemDi} - {inputTuyenDuong.DiemDen}")).FirstOrDefault();
            if (checkTD != null)
                return new MessageReponse
                {
                    rs = false,
                    message = "Tuyến đường này đã tồn tại xin vui lòng nhập tuyến đường khác"
                };
            var MsCuoi = _context.TuyenDuongs.Max(td => td.MSTD);
            int count;

            if (MsCuoi != null)
            {
                count = Convert.ToInt32(MsCuoi.Substring(4));
                count++;
            }
            else
                count = 0;
            var tuyenDuong = new TuyenDuong
            {
                MSTD = $"TD00{count}",
                TenTD = $"{inputTuyenDuong.DiemDi} - {inputTuyenDuong.DiemDen}",
                DiemDen = inputTuyenDuong.DiemDen,
                DiemDi = inputTuyenDuong.DiemDi
            };
            await _context.AddAsync(tuyenDuong);
            await _context.SaveChangesAsync();
            return new MessageReponse
            {
                rs = true,
                message = $"Tuyến có tên {inputTuyenDuong.DiemDi} - {inputTuyenDuong.DiemDen} đã được thêm vào danh sách "
            };
        }
        public async Task<MessageReponse> SuaTuyenDuong(string MSTD, EditTuyenDuong editTuyenDuong)
        {
            var td = await _context.TuyenDuongs.FindAsync(MSTD);
            if (td.DiemDi == editTuyenDuong.DiemDi && td.DiemDen == editTuyenDuong.DiemDen)
                return new MessageReponse
                {
                    rs = false,
                    message = "Thông tin không có gì thay đổi nên không cần cập nhật"
                };
            var tenTd = _context.TuyenDuongs.Where(td => td.TenTD == $"{editTuyenDuong.DiemDi} - {editTuyenDuong.DiemDen}").FirstOrDefault();
            if (tenTd != null)
                return new MessageReponse {
                rs=false,
                message="Đã có tuyến đường này rồi xin vui lòng nhập thông tin khác"
                };
            if (MSTD == null && editTuyenDuong == null)
                return new MessageReponse
                {
                    rs = false,
                    message = "Cần Nhập MSTD để tiến hành thay đổi dữ liệu "
                };
            else
            {               
                if (td == null)
                    return new MessageReponse
                    {
                        rs = false,
                        message = $"Không tìm thấy tuyến đường có MSTD là : {MSTD}"
                    };
                else
                {
                    td.TenTD = $"{editTuyenDuong.DiemDi} - {editTuyenDuong.DiemDen}";
                    td.DiemDi = editTuyenDuong.DiemDi;
                    td.DiemDen = editTuyenDuong.DiemDen;
                }
                await _context.SaveChangesAsync();
                return new MessageReponse
                {
                    rs = true,
                    message = $"Cập nhật thông tin mới cho MSTD : {MSTD} thành công"
                };
            }
        }
        public async Task<MessageReponse> XoaTuyenDuong(string MSTD)
        {
            var td = await _context.TuyenDuongs.FindAsync(MSTD);
            if (td == null)
            {
                return new MessageReponse
            {
                rs = false,
                message = $"Tuyến Đường Có MSTD là : {MSTD} không tồn tại "
            };
            }
            else
            {
                _context.TuyenDuongs.Remove(td);
                await _context.SaveChangesAsync();
                return new MessageReponse {
                    rs = true,
                    message=$"Xóa tuyến đường {td.TenTD} thành công"
                };
            }    
        }    
    }
}
