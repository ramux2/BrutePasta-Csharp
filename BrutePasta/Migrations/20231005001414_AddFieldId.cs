using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrutePasta.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_RestaurantOrder_RestaurantOrderId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantOrder_DeliveryMan_DeliveryManCpf",
                table: "RestaurantOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_DeliveryMan_DeliveryManCpf",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_DeliveryManCpf",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantOrder",
                table: "RestaurantOrder");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantOrder_DeliveryManCpf",
                table: "RestaurantOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryMan",
                table: "DeliveryMan");

            migrationBuilder.DropColumn(
                name: "DeliveryManCpf",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "DeliveryManCpf",
                table: "RestaurantOrder");

            migrationBuilder.RenameColumn(
                name: "RestaurantOrderId",
                table: "RestaurantOrder",
                newName: "DeliveryManId");

            migrationBuilder.RenameColumn(
                name: "ProductTypeId",
                table: "ProductType",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Product",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PaymentMethodId",
                table: "PaymentMethod",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PaymentId",
                table: "Payment",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Item",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Address",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "LicensePlate",
                table: "Vehicle",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryManId",
                table: "Vehicle",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryManId",
                table: "RestaurantOrder",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RestaurantOrder",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "DeliveryMan",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DeliveryMan",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantOrder",
                table: "RestaurantOrder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryMan",
                table: "DeliveryMan",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_DeliveryManId",
                table: "Vehicle",
                column: "DeliveryManId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrder_DeliveryManId",
                table: "RestaurantOrder",
                column: "DeliveryManId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_RestaurantOrder_RestaurantOrderId",
                table: "Item",
                column: "RestaurantOrderId",
                principalTable: "RestaurantOrder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantOrder_DeliveryMan_DeliveryManId",
                table: "RestaurantOrder",
                column: "DeliveryManId",
                principalTable: "DeliveryMan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_DeliveryMan_DeliveryManId",
                table: "Vehicle",
                column: "DeliveryManId",
                principalTable: "DeliveryMan",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_RestaurantOrder_RestaurantOrderId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantOrder_DeliveryMan_DeliveryManId",
                table: "RestaurantOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_DeliveryMan_DeliveryManId",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_DeliveryManId",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantOrder",
                table: "RestaurantOrder");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantOrder_DeliveryManId",
                table: "RestaurantOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryMan",
                table: "DeliveryMan");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "DeliveryManId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RestaurantOrder");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DeliveryMan");

            migrationBuilder.RenameColumn(
                name: "DeliveryManId",
                table: "RestaurantOrder",
                newName: "RestaurantOrderId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductType",
                newName: "ProductTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Product",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PaymentMethod",
                newName: "PaymentMethodId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Payment",
                newName: "PaymentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Item",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Address",
                newName: "AddressId");

            migrationBuilder.AlterColumn<string>(
                name: "LicensePlate",
                table: "Vehicle",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryManCpf",
                table: "Vehicle",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantOrderId",
                table: "RestaurantOrder",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryManCpf",
                table: "RestaurantOrder",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "DeliveryMan",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "LicensePlate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantOrder",
                table: "RestaurantOrder",
                column: "RestaurantOrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryMan",
                table: "DeliveryMan",
                column: "Cpf");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_DeliveryManCpf",
                table: "Vehicle",
                column: "DeliveryManCpf");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrder_DeliveryManCpf",
                table: "RestaurantOrder",
                column: "DeliveryManCpf");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_RestaurantOrder_RestaurantOrderId",
                table: "Item",
                column: "RestaurantOrderId",
                principalTable: "RestaurantOrder",
                principalColumn: "RestaurantOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantOrder_DeliveryMan_DeliveryManCpf",
                table: "RestaurantOrder",
                column: "DeliveryManCpf",
                principalTable: "DeliveryMan",
                principalColumn: "Cpf");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_DeliveryMan_DeliveryManCpf",
                table: "Vehicle",
                column: "DeliveryManCpf",
                principalTable: "DeliveryMan",
                principalColumn: "Cpf");
        }
    }
}
