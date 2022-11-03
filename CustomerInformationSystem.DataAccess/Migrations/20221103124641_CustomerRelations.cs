using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerInformationSystem.DataAccess.Migrations
{
    public partial class CustomerRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CustomerPhoneNumbers_CustomerId",
                table: "CustomerPhoneNumbers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_CustomerId",
                table: "CustomerAddresses",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddresses_Customers_CustomerId",
                table: "CustomerAddresses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPhoneNumbers_Customers_CustomerId",
                table: "CustomerPhoneNumbers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddresses_Customers_CustomerId",
                table: "CustomerAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPhoneNumbers_Customers_CustomerId",
                table: "CustomerPhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPhoneNumbers_CustomerId",
                table: "CustomerPhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAddresses_CustomerId",
                table: "CustomerAddresses");
        }
    }
}
