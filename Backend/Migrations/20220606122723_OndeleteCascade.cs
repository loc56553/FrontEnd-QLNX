using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyNhaXe.Migrations
{
    public partial class OndeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GheNgoi_ChuyenXe_MaCX",
                table: "GheNgoi");

            migrationBuilder.AddForeignKey(
                name: "FK_GheNgoi_ChuyenXe_MaCX",
                table: "GheNgoi",
                column: "MaCX",
                principalTable: "ChuyenXe",
                principalColumn: "MaCX",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GheNgoi_ChuyenXe_MaCX",
                table: "GheNgoi");

            migrationBuilder.AddForeignKey(
                name: "FK_GheNgoi_ChuyenXe_MaCX",
                table: "GheNgoi",
                column: "MaCX",
                principalTable: "ChuyenXe",
                principalColumn: "MaCX",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
