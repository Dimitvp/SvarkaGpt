using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SvarkaGameApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddNamePropForLobby : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Lobbies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Lobbies");
        }
    }
}
