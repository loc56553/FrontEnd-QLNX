using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyNhaXe.Migrations
{
    public partial class _AddImgUserAddPropNhanVien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CMND",
                table: "NhanVien",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GioiTinh",
                table: "NhanVien",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ImageUser",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MSNV = table.Column<string>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    FileSize = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageUser_NhanVien_MSNV",
                        column: x => x.MSNV,
                        principalTable: "NhanVien",
                        principalColumn: "MSNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageUser_MSNV",
                table: "ImageUser",
                column: "MSNV",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageUser");

            migrationBuilder.DropColumn(
                name: "CMND",
                table: "NhanVien");

            migrationBuilder.DropColumn(
                name: "GioiTinh",
                table: "NhanVien");
        }
    }
}
