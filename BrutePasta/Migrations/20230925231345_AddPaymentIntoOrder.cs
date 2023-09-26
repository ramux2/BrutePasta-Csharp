using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrutePasta.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentIntoOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "RestaurantOrder");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "RestaurantOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrder_PaymentId",
                table: "RestaurantOrder",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantOrder_Payment_PaymentId",
                table: "RestaurantOrder",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantOrder_Payment_PaymentId",
                table: "RestaurantOrder");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantOrder_PaymentId",
                table: "RestaurantOrder");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "RestaurantOrder");

            migrationBuilder.AddColumn<float>(
                name: "TotalValue",
                table: "RestaurantOrder",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
