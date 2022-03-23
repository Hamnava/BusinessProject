using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessProject.DataModelLayer.Migrations
{
    public partial class migselectOneTopUserJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string UserJob = @"Create procedure Sp_SelectTopOneUserJob 
                                 @UserId varchar(150)

                                 As
                                 Begin
                                 select top 1 * from UserJobs where UserID = @UserId order by StartJobDate Desc 
                                End";
            migrationBuilder.Sql(UserJob);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string UserJob = @"Drop procedure Sp_SelectTopOneUserJob";
            migrationBuilder.Sql(UserJob);
        }
    }
}
