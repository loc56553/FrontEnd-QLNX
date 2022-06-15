using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyNhaXe.Migrations
{
    public partial class updateRelationGheVaChuyenXe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaCX",
                table: "GheNgoi",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GheNgoi_MaCX",
                table: "GheNgoi",
                column: "MaCX");

            migrationBuilder.AddForeignKey(
                name: "FK_GheNgoi_ChuyenXe_MaCX",
                table: "GheNgoi",
                column: "MaCX",
                principalTable: "ChuyenXe",
                principalColumn: "MaCX",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GheNgoi_ChuyenXe_MaCX",
                table: "GheNgoi");

            migrationBuilder.DropIndex(
                name: "IX_GheNgoi_MaCX",
                table: "GheNgoi");

            migrationBuilder.DropColumn(
                name: "MaCX",
                table: "GheNgoi");
        }
    }
}
