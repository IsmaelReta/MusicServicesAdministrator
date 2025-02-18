using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicServicesAdministrator.Migrations
{
    /// <inheritdoc />
    public partial class PlayListIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlayListId",
                table: "Playlists",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayListId",
                table: "Playlists");
        }
    }
}
