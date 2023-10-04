using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrutePasta.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoClientAndAdress7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Client_ClientId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CliendId",
                table: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Client_ClientId",
                table: "Address",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Client_ClientId",
                table: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Address",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CliendId",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Client_ClientId",
                table: "Address",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");
        }
    }
}
