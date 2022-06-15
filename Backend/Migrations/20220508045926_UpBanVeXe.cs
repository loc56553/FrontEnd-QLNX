using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyNhaXe.Migrations
{
    public partial class UpBanVeXe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GheXe");

            migrationBuilder.DropColumn(
                name: "SoGheTangDuoi",
                table: "LoaiXe");

            migrationBuilder.DropColumn(
                name: "SoGheTangTren",
                table: "LoaiXe");

            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "LoaiXe");

            migrationBuilder.DropColumn(
                name: "SoTang",
                table: "LoaiXe");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TuyenDuong",
                columns: table => new
                {
                    MSTD = table.Column<string>(nullable: false),
                    DiemDi = table.Column<string>(nullable: false),
                    DiemDen = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuyenDuong", x => x.MSTD);
                });

            migrationBuilder.CreateTable(
                name: "VeXe",
                columns: table => new
                {
                    soGhe = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ThanhToan = table.Column<int>(nullable: false),
                    tenKH = table.Column<string>(nullable: false),
                    SDT = table.Column<string>(nullable: false),
                    NgaySinhKH = table.Column<int>(nullable: false),
                    NgayDi = table.Column<DateTime>(nullable: false),
                    NgayVe = table.Column<DateTime>(nullable: true),
                    isRoundTrip = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeXe", x => x.soGhe);
                });

            migrationBuilder.CreateTable(
                name: "ChuyenXe",
                columns: table => new
                {
                    MaCX = table.Column<string>(nullable: false),
                    gia = table.Column<string>(nullable: false),
                    MaTD = table.Column<string>(nullable: false),
                    MaLoaiXe = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuyenXe", x => x.MaCX);
                    table.ForeignKey(
                        name: "FK_ChuyenXe_LoaiXe_MaLoaiXe",
                        column: x => x.MaLoaiXe,
                        principalTable: "LoaiXe",
                        principalColumn: "MSLoaiXe",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuyenXe_TuyenDuong_MaTD",
                        column: x => x.MaTD,
                        principalTable: "TuyenDuong",
                        principalColumn: "MSTD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinChuyenXe",
                columns: table => new
                {
                    MaSoTT = table.Column<string>(nullable: false),
                    MaCx = table.Column<string>(nullable: false),
                    BienSoXe = table.Column<string>(nullable: false),
                    MsTX = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinChuyenXe", x => x.MaSoTT);
                    table.ForeignKey(
                        name: "FK_ThongTinChuyenXe_Xe_BienSoXe",
                        column: x => x.BienSoXe,
                        principalTable: "Xe",
                        principalColumn: "BienSoXe",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongTinChuyenXe_ChuyenXe_MaCx",
                        column: x => x.MaCx,
                        principalTable: "ChuyenXe",
                        principalColumn: "MaCX");
                    table.ForeignKey(
                        name: "FK_ThongTinChuyenXe_NhanVien_MsTX",
                        column: x => x.MsTX,
                        principalTable: "NhanVien",
                        principalColumn: "MSNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenXe_MaLoaiXe",
                table: "ChuyenXe",
                column: "MaLoaiXe");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenXe_MaTD",
                table: "ChuyenXe",
                column: "MaTD");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinChuyenXe_BienSoXe",
                table: "ThongTinChuyenXe",
                column: "BienSoXe");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinChuyenXe_MaCx",
                table: "ThongTinChuyenXe",
                column: "MaCx",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinChuyenXe_MsTX",
                table: "ThongTinChuyenXe",
                column: "MsTX");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThongTinChuyenXe");

            migrationBuilder.DropTable(
                name: "VeXe");

            migrationBuilder.DropTable(
                name: "ChuyenXe");

            migrationBuilder.DropTable(
                name: "TuyenDuong");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "SoGheTangDuoi",
                table: "LoaiXe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoGheTangTren",
                table: "LoaiXe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoLuong",
                table: "LoaiXe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoTang",
                table: "LoaiXe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GheXe",
                columns: table => new
                {
                    MSGhe = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BienSoXe = table.Column<string>(type: "nvarchar(9)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ViTri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GheXe", x => x.MSGhe);
                    table.ForeignKey(
                        name: "FK_GheXe_Xe_BienSoXe",
                        column: x => x.BienSoXe,
                        principalTable: "Xe",
                        principalColumn: "BienSoXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GheXe_BienSoXe",
                table: "GheXe",
                column: "BienSoXe");
        }
    }
}
