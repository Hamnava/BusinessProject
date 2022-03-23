using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessProject.DataModelLayer.Migrations
{
    public partial class migleaves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    LeaveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveType = table.Column<byte>(type: "tinyint", nullable: false),
                    FromDate_Day = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate_Day = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FromTime_Saati = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToTime_Saati = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveRequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID_Request = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserID_Confirm = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LeaveAccept = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.LeaveID);
                    table.ForeignKey(
                        name: "FK_Leaves_Users_UserID_Confirm",
                        column: x => x.UserID_Confirm,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Leaves_Users_UserID_Request",
                        column: x => x.UserID_Request,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_UserID_Confirm",
                table: "Leaves",
                column: "UserID_Confirm");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_UserID_Request",
                table: "Leaves",
                column: "UserID_Request");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leaves");
        }
    }
}
