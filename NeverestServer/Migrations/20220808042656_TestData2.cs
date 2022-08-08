using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeverestServer.Migrations
{
    public partial class TestData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Characters_JobId",
                table: "Characters");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_JobId",
                table: "Characters",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Characters_JobId",
                table: "Characters");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_JobId",
                table: "Characters",
                column: "JobId",
                unique: true);
        }
    }
}
