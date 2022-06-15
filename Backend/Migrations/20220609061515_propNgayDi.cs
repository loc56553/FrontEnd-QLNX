using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyNhaXe.Migrations
{
    public partial class propNgayDi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NgayDi",
                table: "VeXe",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgayDi",
                table: "VeXe");
        }
    }
}
