using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessProject.DataModelLayer.Migrations
{
    public partial class migCreateletter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Letters",
                columns: table => new
                {
                    LetterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LetterContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LetterSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImmediatellyStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    Classification = table.Column<byte>(type: "tinyint", nullable: false),
                    AttachmentStatus = table.Column<bool>(type: "bit", nullable: false),
                    replayDateStatus = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReplyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LetterCreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttachmentFile = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Letters");
        }
    }
}
