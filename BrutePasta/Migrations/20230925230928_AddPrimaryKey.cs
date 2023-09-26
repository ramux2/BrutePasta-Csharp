using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrutePasta.Migrations
{
    /// <inheritdoc />
    public partial class AddPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Order_OrderId",
                table: "Item");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Item",
                newName: "RestaurantOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_OrderId",
                table: "Item",
                newName: "IX_Item_RestaurantOrderId");

            migrationBuilder.CreateTable(
                name: "RestaurantOrder",
                columns: table => new
                {
                    RestaurantOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    MotoboyId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TotalValue = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantOrder", x => x.RestaurantOrderId);
                    table.ForeignKey(
                        name: "FK_RestaurantOrder_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantOrder_Motoboy_MotoboyId",
                        column: x => x.MotoboyId,
                        principalTable: "Motoboy",
                        principalColumn: "MotoboyId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrder_ClientId",
                table: "RestaurantOrder",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrder_MotoboyId",
                table: "RestaurantOrder",
                column: "MotoboyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_RestaurantOrder_RestaurantOrderId",
                table: "Item",
                column: "RestaurantOrderId",
                principalTable: "RestaurantOrder",
                principalColumn: "RestaurantOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_RestaurantOrder_RestaurantOrderId",
                table: "Item");

            migrationBuilder.DropTable(
                name: "RestaurantOrder");

            migrationBuilder.RenameColumn(
                name: "RestaurantOrderId",
                table: "Item",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_RestaurantOrderId",
                table: "Item",
                newName: "IX_Item_OrderId");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    MotoboyId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TotalValue = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Motoboy_MotoboyId",
                        column: x => x.MotoboyId,
                        principalTable: "Motoboy",
                        principalColumn: "MotoboyId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientId",
                table: "Order",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_MotoboyId",
                table: "Order",
                column: "MotoboyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Order_OrderId",
                table: "Item",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId");
        }
    }
}
