using Microsoft.EntityFrameworkCore.Migrations;

namespace AppTest1.Migrations
{
    public partial class TryAgain2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Men_Partners_MormonsPartnerId",
                table: "Men");

            migrationBuilder.DropForeignKey(
                name: "FK_Women_Partners_MormonsPartnerId",
                table: "Women");

            migrationBuilder.DropIndex(
                name: "IX_Women_MormonsPartnerId",
                table: "Women");

            migrationBuilder.DropIndex(
                name: "IX_Men_MormonsPartnerId",
                table: "Men");

            migrationBuilder.DropColumn(
                name: "MormonsPartnerId",
                table: "Women");

            migrationBuilder.DropColumn(
                name: "MormonsPartnerId",
                table: "Men");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MormonsPartnerId",
                table: "Women",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MormonsPartnerId",
                table: "Men",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Women_MormonsPartnerId",
                table: "Women",
                column: "MormonsPartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Men_MormonsPartnerId",
                table: "Men",
                column: "MormonsPartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Men_Partners_MormonsPartnerId",
                table: "Men",
                column: "MormonsPartnerId",
                principalTable: "Partners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Women_Partners_MormonsPartnerId",
                table: "Women",
                column: "MormonsPartnerId",
                principalTable: "Partners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
