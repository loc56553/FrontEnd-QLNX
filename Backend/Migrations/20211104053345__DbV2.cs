using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyNhaXe.Migrations
{
    public partial class _DbV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChucVu",
                table: "NhanVien");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MucDoTruyCap",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "SoDienThoai",
                table: "NhanVien",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "MSChucVu",
                table: "NhanVien",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ChucVuUser",
                columns: table => new
                {
                    MSChucVu = table.Column<string>(nullable: false),
                    TenChucVu = table.Column<string>(maxLength: 20, nullable: false),
                    VietTatChucVu = table.Column<string>(maxLength: 5, nullable: false),
                    MucDoTruyCap = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVuUser", x => x.MSChucVu);
                });

            migrationBuilder.CreateTable(
                name: "LoaiXe",
                columns: table => new
                {
                    MSLoaiXe = table.Column<string>(nullable: false),
                    TenLoaiXe = table.Column<string>(maxLength: 30, nullable: false),
                    SoTang = table.Column<int>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiXe", x => x.MSLoaiXe);
                });

            migrationBuilder.CreateTable(
                name: "Xe",
                columns: table => new
                {
                    BienSoXe = table.Column<string>(maxLength: 9, nullable: false),
                    TongSoGhe = table.Column<int>(nullable: false),
                    SoGheTangTren = table.Column<int>(nullable: false),
                    SoGheTangDuoi = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    SoChuyenDi = table.Column<int>(nullable: false),
                    NgayXuatBai = table.Column<DateTime>(nullable: true),
                    NgayVaoBai = table.Column<DateTime>(nullable: true),
                    MSLoaiXe = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xe", x => x.BienSoXe);
                    table.ForeignKey(
                        name: "FK_Xe_LoaiXe_MSLoaiXe",
                        column: x => x.MSLoaiXe,
                        principalTable: "LoaiXe",
                        principalColumn: "MSLoaiXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MSChucVu",
                table: "NhanVien",
                column: "MSChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MSNV",
                table: "NhanVien",
                column: "MSNV",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_SoDienThoai",
                table: "NhanVien",
                column: "SoDienThoai",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoaiXe_MSLoaiXe",
                table: "LoaiXe",
                column: "MSLoaiXe",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Xe_BienSoXe",
                table: "Xe",
                column: "BienSoXe",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Xe_MSLoaiXe",
                table: "Xe",
                column: "MSLoaiXe");

            migrationBuilder.AddForeignKey(
                name: "FK_NhanVien_ChucVuUser_MSChucVu",
                table: "NhanVien",
                column: "MSChucVu",
                principalTable: "ChucVuUser",
                principalColumn: "MSChucVu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_NhanVien_UserName",
                table: "Users",
                column: "UserName",
                principalTable: "NhanVien",
                principalColumn: "MSNV",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhanVien_ChucVuUser_MSChucVu",
                table: "NhanVien");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_NhanVien_UserName",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ChucVuUser");

            migrationBuilder.DropTable(
                name: "Xe");

            migrationBuilder.DropTable(
                name: "LoaiXe");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserName",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_NhanVien_MSChucVu",
                table: "NhanVien");

            migrationBuilder.DropIndex(
                name: "IX_NhanVien_MSNV",
                table: "NhanVien");

            migrationBuilder.DropIndex(
                name: "IX_NhanVien_SoDienThoai",
                table: "NhanVien");

            migrationBuilder.DropColumn(
                name: "MucDoTruyCap",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MSChucVu",
                table: "NhanVien");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SoDienThoai",
                table: "NhanVien",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ChucVu",
                table: "NhanVien",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
