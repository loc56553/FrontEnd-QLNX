using Castle.Core.Configuration;
using Microsoft.AspNetCore.Identity;
using QuanLyNhaXe.DTOS;
using QuanLyNhaXe.DTVS;
using QuanLyNhaXe.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.Services
{
    public interface IAuthoServicecs
    {
        Task<MessageReponse> ThemChucVu(InputChucVu inputChucVu);

        Task<MessageReponse> XoaChucVu(string MSCV);
        Task<ChucVuView> GetCVByMSCV(string MSCV);
        Task<MessageReponse> SuaChucVu(string id, EditChucVu editChucVu);
    }
    public class AuthoService : IAuthoServicecs
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly MyDbContext _myDbContext;

        public AuthoService (UserManager<UserIdentity> userManager,MyDbContext myDbContext)
        {
            _userManager = userManager;
            _myDbContext = myDbContext;
     
        }

        public async Task<MessageReponse> ThemChucVu(InputChucVu inputChucVu)
        {
            int count;
            if (inputChucVu == null)
                return new MessageReponse {
                    rs = false,
                    message = "Vui lòng nhập đầy đủ thông tin"
                };
            var check = _myDbContext.chucVuUsers.Where(cv => cv.TenChucVu == inputChucVu.TenChucVu).FirstOrDefault();
            if (check != null)
                return new MessageReponse {
                    rs = false,
                    message = "Đã tồn tại chức vụ này rồi"
                };
            var msCuoi = _myDbContext.chucVuUsers.Max(cv => cv.MSChucVu);
            if (msCuoi == null)
                count = 1;
            else
            {
                count = Convert.ToInt32(msCuoi.Substring(4));
                count++;
            }
            var rs = await _myDbContext.chucVuUsers.AddAsync(new ChucVuUser
            {
                MSChucVu = $"MS00{count}",
                TenChucVu = inputChucVu.TenChucVu,
                VietTatChucVu = inputChucVu.VietTatChucVu,
                MucDoTruyCap=Convert.ToInt32(inputChucVu.MucDoTruyCap)
            });
            await _myDbContext.SaveChangesAsync();
            return new MessageReponse { 
            rs=true,
            message="Thêm Chức Vụ Mới Thành Công"
            };
        }

        public async Task<MessageReponse> XoaChucVu(string MSCV)
        {
            if (MSCV == null)
                return new MessageReponse
                {
                    rs = false,
                    message=$"Vui lòng nhập đầy đủ thông tin"
                };
            var rs = await _myDbContext.chucVuUsers.FindAsync(MSCV);
            if (rs==null)
                return new MessageReponse
                {
                    rs = false,
                    message = $"Không tồn tại thông tin chức vụ có MSCV:{MSCV}"
                };
            _myDbContext.chucVuUsers.Remove(rs);
            await _myDbContext.SaveChangesAsync();
            return new MessageReponse { 
            rs=true,
            message=$"Xóa thành công chức vụ có MSCX:{MSCV}"
            };
        }
        public async Task<MessageReponse> SuaChucVu(string id, EditChucVu editchucVu)
        {
            int mucDoTruyCap =Convert.ToInt32(editchucVu.MucDoTruyCap);
            if (id == null || editchucVu == null)
                return new MessageReponse { 
                rs = false,
                message="Thông tin nhập vào chưa chính xác hoặc không đủ"
                };
            var rs = await _myDbContext.chucVuUsers.FindAsync(id);
            if (rs == null)
                return new MessageReponse { 
                rs=false,
                message=$"Không tìm thấy chức vụ có MSCV:{id}"
                };
            if (editchucVu.TenChucVu != null)
                rs.TenChucVu = editchucVu.TenChucVu;
            if (editchucVu.VietTatChucVu != null)
                rs.VietTatChucVu = editchucVu.VietTatChucVu;
            if(mucDoTruyCap!= rs.MucDoTruyCap)
            {
                rs.MucDoTruyCap = mucDoTruyCap;
                if (!SuaChucVuUser(rs.MSChucVu, rs.MucDoTruyCap))
                    return new MessageReponse
                    {
                        rs = false,
                        message = "Cập nhật mức độ truy cập không thành công cho các user"
                    };
            }
            await _myDbContext.SaveChangesAsync();
            return new MessageReponse { 
            rs=true,
            message="Sửa chức vụ thành công"
            };
        }

        public bool SuaChucVuUser(string MSCV,int MucDoTruyCap)
        {
            var nv = _myDbContext.NhanViens.Where(nv => nv.MSChucVu == MSCV).ToList();
            if (nv == null)
                return false;
            foreach (var iteam in nv)
            {
                var user = _userManager.FindByNameAsync(iteam.MSNV);
                {
                    user.Result.MucDoTruyCap = MucDoTruyCap;
                }
            }
            _myDbContext.SaveChanges();
            return true;
        }
        public async Task<ChucVuView> GetCVByMSCV(string MSCV)
        {
            var cv = await _myDbContext.chucVuUsers.FindAsync(MSCV);
            if (cv != null)
                return new ChucVuView
                {
                    TenChucVu = cv.TenChucVu,
                    VietTatChucVu = cv.VietTatChucVu,
                    MucDoTruyCap = cv.MucDoTruyCap
                };
            else
                return null;
        }
    }
}
