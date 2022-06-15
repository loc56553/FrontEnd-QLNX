using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyNhaXe.Migrations
{
    public partial class UpdateVeXe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VeXe_ChuyenXe_chuyenXeMaCX",
                table: "VeXe");

            migrationBuilder.DropIndex(
                name: "IX_VeXe_chuyenXeMaCX",
                table: "VeXe");

            migrationBuilder.DropColumn(
                name: "NgayDi",
                table: "VeXe");

            migrationBuilder.DropColumn(
                name: "chuyenXeMaCX",
                table: "VeXe");

            migrationBuilder.AddColumn<string>(
                name: "MaCX",
                table: "VeXe",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_VeXe_MaCX",
                table: "VeXe",
                column: "MaCX");

            migrationBuilder.AddForeignKey(
                name: "FK_VeXe_ChuyenXe_MaCX",
                table: "VeXe",
                column: "MaCX",
                principalTable: "ChuyenXe",
                principalColumn: "MaCX",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VeXe_ChuyenXe_MaCX",
                table: "VeXe");

            migrationBuilder.DropIndex(
                name: "IX_VeXe_MaCX",
                table: "VeXe");

            migrationBuilder.DropColumn(
                name: "MaCX",
                table: "VeXe");

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayDi",
                table: "VeXe",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "chuyenXeMaCX",
                table: "VeXe",
                type: "nvarchar(450)",
                nullable: true);

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
    }
}
