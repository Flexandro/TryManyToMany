using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppTest1.Migrations
{
    public partial class TryAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ManId = table.Column<int>(nullable: false),
                    WomanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Men",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    MormonsPartnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Men", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Men_Partners_MormonsPartnerId",
                        column: x => x.MormonsPartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Women",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    MormonsPartnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Women", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Women_Partners_MormonsPartnerId",
                        column: x => x.MormonsPartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Men_MormonsPartnerId",
                table: "Men",
                column: "MormonsPartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_ManId",
                table: "Partners",
                column: "ManId");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_WomanId",
                table: "Partners",
                column: "WomanId");

            migrationBuilder.CreateIndex(
                name: "IX_Women_MormonsPartnerId",
                table: "Women",
                column: "MormonsPartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_Men_ManId",
                table: "Partners",
                column: "ManId",
                principalTable: "Men",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_Women_WomanId",
                table: "Partners",
                column: "WomanId",
                principalTable: "Women",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Men_Partners_MormonsPartnerId",
                table: "Men");

            migrationBuilder.DropForeignKey(
                name: "FK_Women_Partners_MormonsPartnerId",
                table: "Women");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "Men");

            migrationBuilder.DropTable(
                name: "Women");
        }
    }
}
