using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessProject.DataModelLayer.Migrations
{
    public partial class migrolePattern : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RolePatterns",
                columns: table => new
                {
                    RolePatternId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolePatternName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RolePatternDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePatterns", x => x.RolePatternId);
                });

            migrationBuilder.CreateTable(
                name: "RolePatternDetails",
                columns: table => new
                {
                    RolePatternDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolePatternId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePatternDetails", x => x.RolePatternDetailsId);
                    table.ForeignKey(
                        name: "FK_RolePatternDetails_RolePatterns_RolePatternId",
                        column: x => x.RolePatternId,
                        principalTable: "RolePatterns",
                        principalColumn: "RolePatternId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePatternDetails_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePatternDetails_RoleId",
                table: "RolePatternDetails",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePatternDetails_RolePatternId",
                table: "RolePatternDetails",
                column: "RolePatternId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePatternDetails");

            migrationBuilder.DropTable(
                name: "RolePatterns");
        }
    }
}
