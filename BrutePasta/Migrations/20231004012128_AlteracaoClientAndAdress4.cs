using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrutePasta.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoClientAndAdress4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CliendId",
                table: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CliendId",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
