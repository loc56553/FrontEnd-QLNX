using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyNhaXe.Migrations
{
    public partial class SuaChuyenXeThoiGianDi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgayDi",
                table: "VeXe");

            migrationBuilder.AddColumn<DateTime>(
                name: "GioDi",
                table: "ChuyenXe",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayDi",
                table: "ChuyenXe",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GioDi",
                table: "ChuyenXe");

            migrationBuilder.DropColumn(
                name: "NgayDi",
                table: "ChuyenXe");

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayDi",
                table: "VeXe",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
