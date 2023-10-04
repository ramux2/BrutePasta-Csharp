using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrutePasta.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoClientAndAdress5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Client",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "CliendId",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CliendId",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Client",
                newName: "ClientId");
        }
    }
}
