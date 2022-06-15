using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyNhaXe.Migrations
{
    public partial class QuanHeVexeVaChuyenXe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VeXe",
                table: "VeXe");

            migrationBuilder.AlterColumn<string>(
                name: "soGhe",
                table: "VeXe",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<long>(
                name: "MsVe",
                table: "VeXe",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "chuyenXeMaCX",
                table: "VeXe",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VeXe",
                table: "VeXe",
                column: "MsVe");

            migrationBuilder.CreateIndex(
                name: "IX_VeXe_chuyenXeMaCX",
                table: "VeXe",
                column: "chuyenXeMaCX");

            migrationBuilder.AddForeignKey(
                name: "FK_VeXe_ChuyenXe_chuyenXeMaCX",
                table: "VeXe",
                column: "chuyenXeMaCX",
                principalTable: "ChuyenXe",
                principalColumn: "MaCX",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VeXe_ChuyenXe_chuyenXeMaCX",
                table: "VeXe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VeXe",
                table: "VeXe");

            migrationBuilder.DropIndex(
                name: "IX_VeXe_chuyenXeMaCX",
                table: "VeXe");

            migrationBuilder.DropColumn(
                name: "MsVe",
                table: "VeXe");

            migrationBuilder.DropColumn(
                name: "chuyenXeMaCX",
                table: "VeXe");

            migrationBuilder.AlterColumn<string>(
                name: "soGhe",
                table: "VeXe",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_VeXe",
                table: "VeXe",
                column: "soGhe");
        }
    }
}
