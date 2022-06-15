using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyNhaXe.Migrations
{
    public partial class UpdateNgaySinhKH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgaySinhKH",
                table: "VeXe");

            migrationBuilder.AddColumn<DateTime>(
                name: "NgaySinh",
                table: "VeXe",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgaySinh",
                table: "VeXe");

            migrationBuilder.AddColumn<int>(
                name: "NgaySinhKH",
                table: "VeXe",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
