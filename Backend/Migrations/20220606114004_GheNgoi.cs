using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyNhaXe.Migrations
{
    public partial class GheNgoi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThongTinChuyenXe");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "VeXe");

            migrationBuilder.AddColumn<int>(
                name: "SoGhe",
                table: "LoaiXe",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GheNgoi",
                columns: table => new
                {
                    MSghe = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenGhe = table.Column<string>(nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GheNgoi", x => x.MSghe);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GheNgoi");

            migrationBuilder.DropColumn(
                name: "SoGhe",
                table: "LoaiXe");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "VeXe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ThongTinChuyenXe",
                columns: table => new
                {
                    MaSoTT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BienSoXe = table.Column<string>(type: "nvarchar(9)", nullable: false),
                    MaCx = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MsTX = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
    }
}
