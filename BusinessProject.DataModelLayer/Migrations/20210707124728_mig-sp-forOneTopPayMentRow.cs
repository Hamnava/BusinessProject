using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessProject.DataModelLayer.Migrations
{
    public partial class migspforOneTopPayMentRow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string payment = @"Create procedure Sp_GetTopOnePayment 
                                 @UserId varchar(150)

                                 As
                                 Begin
                                 select top 1 * from Payments where UserID = @UserId order by PaymentDate Desc 
                                End";
            migrationBuilder.Sql(payment);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string payment = @"Drop procedure Sp_GetTopOnePayment";
            migrationBuilder.Sql(payment);
        }
    }
}
