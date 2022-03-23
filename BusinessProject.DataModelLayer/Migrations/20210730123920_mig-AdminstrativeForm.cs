using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessProject.DataModelLayer.Migrations
{
    public partial class migAdminstrativeForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminstrativeForms",
                columns: table => new
                {
                    AdminstrativeFormId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminstrativeFormType = table.Column<bool>(type: "bit", nullable: false),
                    AdminstrativeFormTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminstrativeFormContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminstrativeForms", x => x.AdminstrativeFormId);
                    table.ForeignKey(
                        name: "FK_AdminstrativeForms_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminstrativeForms_UserId",
                table: "AdminstrativeForms",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminstrativeForms");
        }
    }
}
