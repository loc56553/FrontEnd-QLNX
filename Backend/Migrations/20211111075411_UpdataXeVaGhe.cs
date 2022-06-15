using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyNhaXe.Migrations
{
    public partial class UpdataXeVaGhe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoGheTangDuoi",
                table: "Xe");

            migrationBuilder.DropColumn(
                name: "SoGheTangTren",
                table: "Xe");

            migrationBuilder.DropColumn(
                name: "TongSoGhe",
                table: "Xe");

            migrationBuilder.AddColumn<int>(
                name: "SoGheTangDuoi",
                table: "LoaiXe",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoGheTangTren",
                table: "LoaiXe",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GheXe",
                columns: table => new
                {
                    MSGhe = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViTri = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    BienSoXe = table.Column<string>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GheXe");

            migrationBuilder.DropColumn(
                name: "SoGheTangDuoi",
                table: "LoaiXe");

            migrationBuilder.DropColumn(
                name: "SoGheTangTren",
                table: "LoaiXe");

            migrationBuilder.AddColumn<int>(
                name: "SoGheTangDuoi",
                table: "Xe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoGheTangTren",
                table: "Xe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TongSoGhe",
                table: "Xe",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
