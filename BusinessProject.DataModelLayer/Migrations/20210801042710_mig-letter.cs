using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessProject.DataModelLayer.Migrations
{
    public partial class migletter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Letters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Letters",
                columns: table => new
                {
                    LetterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachmentFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentStatus = table.Column<bool>(type: "bit", nullable: false),
                    Classification = table.Column<byte>(type: "tinyint", nullable: false),
                    ImmediatellyStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    LetterContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LetterCreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LetterSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    replayDateStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Letters", x => x.LetterId);
                    table.ForeignKey(
                        name: "FK_Letters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Letters_UserId",
                table: "Letters",
                column: "UserId");
        }
    }
}
