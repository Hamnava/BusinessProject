using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessProject.DataModelLayer.Migrations
{
    public partial class miguserJobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserJobs",
                columns: table => new
                {
                    UserJobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    StartJobDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndJobDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsHaveJob = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJobs", x => x.UserJobId);
                    table.ForeignKey(
                        name: "FK_UserJobs_SystemJobs_tbl_JobId",
                        column: x => x.JobId,
                        principalTable: "SystemJobs_tbl",
                        principalColumn: "JobsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserJobs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserJobs_JobId",
                table: "UserJobs",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJobs_UserId",
                table: "UserJobs",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserJobs");
        }
    }
}
