using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessProject.DataModelLayer.Migrations
{
    public partial class migsystemjob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.CreateTable(
                name: "SystemJobs_tbl",
                columns: table => new
                {
                    JobsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobsLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemJobs_tbl", x => x.JobsID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemJobs_tbl");

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobsChartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobsChartDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobsChartLevel = table.Column<int>(type: "int", nullable: false),
                    JobsChartName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobsChartId);
                });
        }
    }
}
