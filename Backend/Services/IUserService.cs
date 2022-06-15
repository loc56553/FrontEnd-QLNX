
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuanLyNhaXe.DTOS;
using QuanLyNhaXe.DTVS;
using QuanLyNhaXe.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaXe.Services
{
    public interface IUserService
    {
        Task<NhanVien> DangKyNhanVien(DangKy dangKy);
        Task<bool> DangKyUser(string MSNV, NhanVien nhanVien);

        Task<UserProFile> Login(Login loGin);

        Task<UserView> GetUserByID(string MSNV);

        Task<bool> DeleteUserById(string MSNV);

        Task<NhanVien> EditUser(string MSNV, EditUser editUser);

        Task<bool> ChangePassWord(string MSNV, ChangePass changePass);

        Task<bool> EditChucVuUser(NhanVien nhanVien);

        Task<bool> EditStatus(string MSNV);
    }

    public class UserServices : IUserService
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly SignInManager<UserIdentity> _signInManager;
        private readonly MyDbContext _myDbContext;
        private readonly IConfiguration _configuration;
        private IWebHostEnvironment _environment;
        private string fileName = "Avatar";
        public UserServices(UserManager<UserIdentity> userManager, MyDbContext myDbContext, IConfiguration configuration, SignInManager<UserIdentity> signInManager, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _myDbContext = myDbContext;
            _configuration = configuration;
            _signInManager = signInManager;
            _environment = environment;
        }
        /// <summary>
        /// Đăng Ký User
        /// </summary>
        /// <param name="MSNV"></param>
        /// <param name="dangKy"></param>
        /// <returns></returns>
        public async Task<bool> DangKyUser(string MSNV, NhanVien nhanVien)
        {
            var identityUser = new UserIdentity();
            if (MSNV == null)
                return false;
            else
            {
                identityUser.UserName = MSNV;
                identityUser.MucDoTruyCap = nhanVien.ChucVuUser.MucDoTruyCap;
            }
            var result = await _userManager.CreateAsync(identityUser, nhanVien.SoDienThoai);
            if (result.Succeeded)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Đăng Ký Nhân Viên
        /// </summary>
        /// <param name="dangKy"></param>
        /// <returns></returns>
        public async Task<NhanVien> DangKyNhanVien(DangKy dangKy)
        {
            int count;
            var nhanVien = new NhanVien();
            var checkCV = _myDbContext.chucVuUsers.Where(cCV => cCV.TenChucVu == dangKy.ChucVu).FirstOrDefault();
            if (checkCV == null)
                return null;
            var nvCuoi = _myDbContext.NhanViens.Max(nv=>nv.MSNV);
            if (nvCuoi == null)
                count = 1;
            else
            {
                count = Convert.ToInt32(nvCuoi.Substring(4));
                count++;
            }        
            if (dangKy == null)
                return null;
            else
            {
                nhanVien.MSNV = $"MSNV00{count}";    
                nhanVien.HoTen = dangKy.HoTen;
                nhanVien.NgaySinh = DateTime.ParseExact(dangKy.NgaySinh, "yyyy-MM-dd", null); 
                nhanVien.SoDienThoai = dangKy.SoDienThoai;
                nhanVien.MSChucVu = checkCV.MSChucVu; //Sửa
                await _myDbContext.AddAsync(nhanVien);
                await _myDbContext.SaveChangesAsync();
                return nhanVien;
            }
        }
        /// <summary>
        /// Đăng Nhập
        /// </summary>
        /// <param name="loGin"></param>
        /// <returns></returns>
        public async Task<UserProFile> Login(Login loGin)
        {
            var user = await _myDbContext.Users.Include(us=>us.NhanVien).Include(us=>us.NhanVien.ChucVuUser).FirstOrDefaultAsync(us=>us.UserName.Equals(loGin.UserName)); //Sửa Chức Năng Đăng Nhập    
            if (loGin == null)
                return null;
            if (user == null)
                return null;
            if (!user.UserName.Equals(loGin.UserName))
                return null;
            var checkpass = await _signInManager.PasswordSignInAsync(user.UserName, loGin.Password, false, false);
            if (!checkpass.Succeeded)
                return null;
            var claims = new[]
            {
                new Claim("UserName",loGin.UserName),
                new Claim("ID",user.Id)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            string toKen = new JwtSecurityTokenHandler().WriteToken(token);
            var rs = new UserProFile()
            {
                HoTen = user.NhanVien.HoTen,
                GioiTinh = user.NhanVien.GioiTinh,
                ChucVu = user.NhanVien.ChucVuUser.TenChucVu,
                NgaySinh = user.NhanVien.NgaySinh.Value.ToString("dd-MM-yyyy"),
                SoDienThoai=user.NhanVien.SoDienThoai,
                UserName=user.UserName,
                Token= toKen
            };
            return rs;
        }
        /// <summary>
        /// Lấy User bằng ID
        /// </summary>
        /// <param name="MSNV"></param>
        /// <returns></returns>
        public async Task<UserView> GetUserByID(string MSNV)//Sửa Lại Chức Năng
        {
            var user = new UserView();
            var result = await _myDbContext.NhanViens.Include(nv=>nv.ChucVuUser).Include(nv=>nv.ImageUser).FirstOrDefaultAsync(nv => nv.MSNV == MSNV);
            if (result == null)
                return null;
            if (result.ImageUser==null)
            {
                user.UserName = result.MSNV;
                user.HoTen = result.HoTen;
                user.SoDienThoai = result.SoDienThoai;
                user.ChucVu = result.ChucVuUser.TenChucVu;
                user.NgaySinh = result.NgaySinh.Value.ToString("dd-MM-yyyy");
                user.GioiTinh = result.GioiTinh;             
            }
            else
            {
                user.UserName = result.MSNV;
                user.HoTen = result.HoTen;
                user.SoDienThoai = result.SoDienThoai;
                user.ChucVu = result.ChucVuUser.TenChucVu; 
                user.NgaySinh = result.NgaySinh.Value.ToString("dd-MM-yyyy");
                user.GioiTinh= result.GioiTinh;
                user.ImagePath=result.ImageUser.ImagePath;
                user.FileSize = result.ImageUser.FileSize;
            };
            return user;
        }
        /// <summary>
        /// Xóa User bằng ID
        /// </summary>
        /// <param name="MSNV"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUserById(string MSNV)
        {
            var result = await _myDbContext.NhanViens.FindAsync(MSNV);
            if (result == null)
                return false;
            else
            {
                var user = await _myDbContext.Users.FirstOrDefaultAsync(nv => nv.UserName == MSNV);
                if (user == null)
                    return false;
                else
                {
                    await _userManager.DeleteAsync(user);
                    _myDbContext.NhanViens.Remove(result);
                    await _myDbContext.SaveChangesAsync();
                    return true;
                }
            }
        }
        /// <summary>
        /// Chỉnh sửa thông tin User
        /// </summary>
        /// <param name="MSNV"></param>
        /// <param name="editUser"></param>
        /// <returns></returns>
        public async Task<NhanVien> EditUser(string MSNV, EditUser editUser)
        {
            var checCk = _myDbContext.chucVuUsers.Where(cCV => cCV.TenChucVu == editUser.ChucVu).FirstOrDefault();
            if (checCk == null)
                return null;
            var result = await _myDbContext.NhanViens.FindAsync(MSNV);
            if (result == null)
                return null;
            else
            {
                if (editUser.HoTen != null)
                    result.HoTen = editUser.HoTen;
                if (editUser.ChucVu != null)
                    result.MSChucVu = checCk.MSChucVu; //Sửa
                if (editUser.SoDienThoai != null)
                    result.SoDienThoai = editUser.SoDienThoai;
                if (editUser.NgaySinh != null)
                {
                    result.NgaySinh = DateTime.ParseExact(editUser.NgaySinh, "yyyy-MM--dd", null);
                }
            }
            await _myDbContext.SaveChangesAsync();
            return result;
        }
        /// <summary>
        /// Sửa chức vụ của User khi cập nhật
        /// </summary>
        /// <param name="nhanVien"></param>
        /// <returns></returns>
        public async Task<bool> EditChucVuUser(NhanVien nhanVien)
        {
            var rs = await _userManager.FindByNameAsync(nhanVien.MSNV);
            if (rs == null)
                return false;
            rs.MucDoTruyCap = nhanVien.ChucVuUser.MucDoTruyCap;
            await _myDbContext.SaveChangesAsync();
            return true;
        }
        /// <summary>
        /// Đổi mật khẩu cho user
        /// </summary>
        /// <param name="MSNV"></param>
        /// <param name="changePass"></param>
        /// <returns></returns>
        public async Task<bool> ChangePassWord(string MSNV, ChangePass changePass)
        {
            var user = await _userManager.FindByNameAsync(MSNV);
            if (user == null)
                return false;
            if (!await _userManager.CheckPasswordAsync(user, changePass.CurrentPassWord))
                return false;
            await _userManager.ChangePasswordAsync(user, changePass.CurrentPassWord, changePass.PassWord);
            return true;
        }

        public async Task<bool> EditStatus(string MSNV)
        {
            var user = await _userManager.FindByNameAsync(MSNV);
            if (user == null)
                return false;
            else
            {
                switch (user.Status)
                {
                    case 0: user.Status = 1;
                        break;
                    case 1: user.Status = 0;
                        break;
                }
                await _myDbContext.SaveChangesAsync();
                return true;
            }   
        }
    }
}
