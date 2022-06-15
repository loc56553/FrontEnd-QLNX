using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.Models
{
    public class MyDbContext:IdentityDbContext<UserIdentity>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {

        }
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();     //Cắt Chuối AspNet trong cơ sở Database 
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
            modelBuilder.Entity<UserIdentity>(userdentity =>
            {
                userdentity.Property(user => user.UserName).HasMaxLength(450);
                userdentity.HasOne(userdentity => userdentity.NhanVien)
                .WithOne(nv => nv.UserIdentity).HasForeignKey<UserIdentity>(userdentity => userdentity.UserName)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<NhanVien>(entity => {
                entity.HasIndex(nv => nv.MSNV)
                .IsUnique(true);
                entity.HasIndex(nv => nv.SoDienThoai)     // Đánh chỉ mục UserName (user_name)
                .IsUnique(true);              // Unique
            });
            modelBuilder.Entity<Xe>(entity =>
            {
                entity.HasIndex(x => x.BienSoXe)
                .IsUnique(true);
                
            });
            modelBuilder.Entity<LoaiXe>(entity =>
            {
                entity.HasIndex(x => x.MSLoaiXe)
                .IsUnique(true);
            });
            modelBuilder.Entity<GheNgoi>(entity =>
            {
                entity.HasOne(entity => entity.ChuyenXe).WithMany(cx => cx.GheNgois).OnDelete(DeleteBehavior.Cascade);
            });
        }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<LoaiXe> LoaiXes { get; set; }

        public DbSet<Xe> Xes { get; set; }

        public DbSet<ChucVuUser> chucVuUsers { get;set; }

        public DbSet<ImageUser> imageUsers { get; set; }

        public DbSet<Vexe> VeXes { get; set; }

        public DbSet<TuyenDuong> TuyenDuongs { get; set; }

        public DbSet<ChuyenXe> ChuyenXes { get; set; }

        public DbSet<GheNgoi> GheNgois { get; set; }
    }
}
