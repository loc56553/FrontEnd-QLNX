using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyNhaXe.Migrations
{
    public partial class AddPropTuyenDuong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenTD",
                table: "TuyenDuong",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenTD",
                table: "TuyenDuong");
        }
    }
}
