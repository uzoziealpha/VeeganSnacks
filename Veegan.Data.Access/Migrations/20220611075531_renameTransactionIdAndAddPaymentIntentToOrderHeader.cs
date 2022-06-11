using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veegan.Data.Access.Migrations
{
    public partial class renameTransactionIdAndAddPaymentIntentToOrderHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "OrderHeader",
                newName: "SessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "OrderHeader",
                newName: "TransactionId");
        }
    }
}
