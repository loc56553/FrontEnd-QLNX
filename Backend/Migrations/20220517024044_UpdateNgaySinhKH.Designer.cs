// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyNhaXe.Models;

namespace QuanLyNhaXe.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220517024044_UpdateNgaySinhKH")]
    partial class UpdateNgaySinhKH
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("QuanLyNhaXe.Models.ChucVuUser", b =>
                {
                    b.Property<string>("MSChucVu")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MucDoTruyCap")
                        .HasColumnType("int");

                    b.Property<string>("TenChucVu")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("VietTatChucVu")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.HasKey("MSChucVu");

                    b.ToTable("ChucVuUser");
                });

            modelBuilder.Entity("QuanLyNhaXe.Models.ChuyenXe", b =>
                {
                    b.Property<string>("MaCX")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("GioDi")
                        .HasColumnType("datetime2");

                    b.Property<string>("MaLoaiXe")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaTD")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayDi")
                        .HasColumnType("datetime2");

                    b.Property<string>("gia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaCX");

                    b.HasIndex("MaLoaiXe");

                    b.HasIndex("MaTD");

                    b.ToTable("ChuyenXe");
                });

            modelBuilder.Entity("QuanLyNhaXe.Models.ImageUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MSNV")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MSNV")
                        .IsUnique();

                    b.ToTable("ImageUser");
                });

            modelBuilder.Entity("QuanLyNhaXe.Models.LoaiXe", b =>
                {
                    b.Property<string>("MSLoaiXe")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenLoaiXe")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("MSLoaiXe");

                    b.HasIndex("MSLoaiXe")
                        .IsUnique();

                    b.ToTable("LoaiXe");
                });

            modelBuilder.Entity("QuanLyNhaXe.Models.NhanVien", b =>
                {
                    b.Property<string>("MSNV")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CMND")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("MSChucVu")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MSNV");

                    b.HasIndex("MSChucVu");

                    b.HasIndex("MSNV")
                        .IsUnique();

                    b.HasIndex("SoDienThoai")
                        .IsUnique();

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("QuanLyNhaXe.Models.ThongTinChuyenXe", b =>
                {
                    b.Property<string>("MaSoTT")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BienSoXe")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("MaCx")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MsTX")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MaSoTT");

                    b.HasIndex("BienSoXe");

                    b.HasIndex("MaCx")
                        .IsUnique();

                    b.HasIndex("MsTX");

                    b.ToTable("ThongTinChuyenXe");
                });

            modelBuilder.Entity("QuanLyNhaXe.Models.TuyenDuong", b =>
                {
                    b.Property<string>("MSTD")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiemDen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiemDi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenTD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MSTD");

                    b.ToTable("TuyenDuong");
                });

            modelBuilder.Entity("QuanLyNhaXe.Models.UserIdentity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("MucDoTruyCap")
                        .HasColumnType("int");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QuanLyNhaXe.Models.Vexe", b =>
                {
                    b.Property<long>("MsVe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("NgayDi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayVe")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("ThanhToan")
                        .HasColumnType("int");

                    b.Property<string>("chuyenXeMaCX")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("isRoundTrip")
                        .HasColumnType("bit");

                    b.Property<string>("soGhe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tenKH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MsVe");

                    b.HasIndex("chuyenXeMaCX");

                    b.ToTable("VeXe");
                });

            modelBuilder.Entity("QuanLyNhaXe.Models.Xe", b =>
                {
                    b.Property<string>("BienSoXe")
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("MSLoaiXe")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("NgayVaoBai")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXuatBai")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoChuyenDi")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("BienSoXe");

                    b.HasIndex("BienSoXe")
                        .IsUnique();

                    b.HasIndex("MSLoaiXe");

                    b.ToTable("Xe");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("QuanLyNhaXe.Models.UserIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("QuanLyNhaXe.Models.UserIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyNhaXe.Models.UserIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("QuanLyNhaXe.Models.UserIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuanLyNhaXe.Models.ChuyenXe", b =>
                {
                    b.HasOne("QuanLyNhaXe.Models.LoaiXe", "loaiXe")
                        .WithMany("chuyenXes")
                        .HasForeignKey("MaLoaiXe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyNhaXe.Models.TuyenDuong", "tuyenDuong")
                        .WithMany("chuyenXes")
                        .HasForeignKey("MaTD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuanLyNhaXe.Models.ImageUser", b =>
                {
                    b.HasOne("QuanLyNhaXe.Models.NhanVien", "NhanVien")
                        .WithOne("ImageUser")
                        .HasForeignKey("QuanLyNhaXe.Models.ImageUser", "MSNV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuanLyNhaXe.Models.NhanVien", b =>
                {
                    b.HasOne("QuanLyNhaXe.Models.ChucVuUser", "ChucVuUser")
                        .WithMany("NhanViens")
                        .HasForeignKey("MSChucVu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuanLyNhaXe.Models.ThongTinChuyenXe", b =>
                {
                    b.HasOne("QuanLyNhaXe.Models.Xe", "xe")
                        .WithMany("thongTinChuyenXes")
                        .HasForeignKey("BienSoXe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyNhaXe.Models.ChuyenXe", "chuyenXe")
                        .WithOne("thongTinChuyenXe")
                        .HasForeignKey("QuanLyNhaXe.Models.ThongTinChuyenXe", "MaCx")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("QuanLyNhaXe.Models.NhanVien", "nhanVien")
                        .WithMany("thongTinChuyenXes")
                        .HasForeignKey("MsTX")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuanLyNhaXe.Models.UserIdentity", b =>
                {
                    b.HasOne("QuanLyNhaXe.Models.NhanVien", "NhanVien")
                        .WithOne("UserIdentity")
                        .HasForeignKey("QuanLyNhaXe.Models.UserIdentity", "UserName")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuanLyNhaXe.Models.Vexe", b =>
                {
                    b.HasOne("QuanLyNhaXe.Models.ChuyenXe", "chuyenXe")
                        .WithMany("veXes")
                        .HasForeignKey("chuyenXeMaCX");
                });

            modelBuilder.Entity("QuanLyNhaXe.Models.Xe", b =>
                {
                    b.HasOne("QuanLyNhaXe.Models.LoaiXe", "LoaiXe")
                        .WithMany("Xes")
                        .HasForeignKey("MSLoaiXe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
