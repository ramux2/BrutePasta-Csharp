using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrutePasta.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoClientAndAdress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Address_AddressId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantOrder_Motoboy_MotoboyId",
                table: "RestaurantOrder");

            migrationBuilder.DropTable(
                name: "Motoboy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantOrder_MotoboyId",
                table: "RestaurantOrder");

            migrationBuilder.DropIndex(
                name: "IX_Client_AddressId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "MotoboyId",
                table: "RestaurantOrder");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Client");

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

            migrationBuilder.AddColumn<string>(
                name: "DeliveryManCpf",
                table: "RestaurantOrder",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "StreetName",
                table: "Address",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Address",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Address",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CliendId",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "LicensePlate");

            migrationBuilder.CreateTable(
                name: "DeliveryMan",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderTax = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMan", x => x.Cpf);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_DeliveryManCpf",
                table: "Vehicle",
                column: "DeliveryManCpf");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrder_DeliveryManCpf",
                table: "RestaurantOrder",
                column: "DeliveryManCpf");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ClientId",
                table: "Address",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Client_ClientId",
                table: "Address",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Client_ClientId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantOrder_DeliveryMan_DeliveryManCpf",
                table: "RestaurantOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_DeliveryMan_DeliveryManCpf",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "DeliveryMan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_DeliveryManCpf",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantOrder_DeliveryManCpf",
                table: "RestaurantOrder");

            migrationBuilder.DropIndex(
                name: "IX_Address_ClientId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "DeliveryManCpf",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "DeliveryManCpf",
                table: "RestaurantOrder");

            migrationBuilder.DropColumn(
                name: "CliendId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Address");

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
                name: "VehicleId",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "MotoboyId",
                table: "RestaurantOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Address",
                keyColumn: "StreetName",
                keyValue: null,
                column: "StreetName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "StreetName",
                table: "Address",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Address",
                keyColumn: "Number",
                keyValue: null,
                column: "Number",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Address",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Address",
                keyColumn: "Cep",
                keyValue: null,
                column: "Cep",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Address",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "VehicleId");

            migrationBuilder.CreateTable(
                name: "Motoboy",
                columns: table => new
                {
                    MotoboyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(type: "int", nullable: true),
                    Cpf = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderTax = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoboy", x => x.MotoboyId);
                    table.ForeignKey(
                        name: "FK_Motoboy_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrder_MotoboyId",
                table: "RestaurantOrder",
                column: "MotoboyId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_AddressId",
                table: "Client",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Motoboy_VehicleId",
                table: "Motoboy",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Address_AddressId",
                table: "Client",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantOrder_Motoboy_MotoboyId",
                table: "RestaurantOrder",
                column: "MotoboyId",
                principalTable: "Motoboy",
                principalColumn: "MotoboyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
