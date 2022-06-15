using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaXe.DTOS;
using QuanLyNhaXe.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace QuanLyNhaXe.Services
{
    public interface IImageUserService
    {
        Task<bool> AddImage(string MSNV, InputImage img);

        Task<bool> RemoveImage(string MSNV);

        Task<bool> UpdateImage(string MSNV, InputImage img);
    }
    public class ImageUserService:IImageUserService
    {
        private readonly MyDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-image";
        public ImageUserService(MyDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        public async Task<bool> AddImage(string MSNV, InputImage img)
        {
            var user = await _context.NhanViens.Include(us => us.ImageUser).FirstOrDefaultAsync(us => us.MSNV.Equals(MSNV));
            if (user == null)
                return false;
            if(user.ImageUser!=null)
                    return false;
            var image = new ImageUser();
            if (img.ImgageFile!=null)
            {
                image.MSNV = MSNV;
                image.ImagePath = await this.SaveFile(img.ImgageFile);
                image.FileSize = img.ImgageFile.Length;
            }
            _context.imageUsers.Add(image);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveImage(string MSNV)
        {
            var userImage =_context.imageUsers.Where(img => img.MSNV.Equals(MSNV)).FirstOrDefault();
            if (userImage == null)
                return false;
            else
            {
                _context.imageUsers.Remove(userImage);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> UpdateImage(string MSNV, InputImage img)
        {
            var user = _context.imageUsers.Where(img=>img.MSNV==MSNV).FirstOrDefault();
            if (user == null)
                return false;
            if (user.ImagePath == null)
                return false;
            if (img.ImgageFile != null)
            {
                user.ImagePath = await this.SaveFile(img.ImgageFile);
                user.FileSize = img.ImgageFile.Length;
            }
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
