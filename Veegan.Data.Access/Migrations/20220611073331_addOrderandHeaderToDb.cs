using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veegan.Data.Access.Migrations
{
    public partial class addOrderandHeaderToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PickUpName",
                table: "OrderHeader",
                newName: "PickupName");

            migrationBuilder.AddColumn<string>(
                name: "PaymentIntentId",
                table: "OrderHeader",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentIntentId",
                table: "OrderHeader");

            migrationBuilder.RenameColumn(
                name: "PickupName",
                table: "OrderHeader",
                newName: "PickUpName");
        }
    }
}
