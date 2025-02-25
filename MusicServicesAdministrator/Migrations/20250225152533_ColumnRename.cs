using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicServicesAdministrator.Migrations
{
    /// <inheritdoc />
    public partial class ColumnRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlayListId",
                table: "Playlists",
                newName: "PlayListPlatformId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlayListPlatformId",
                table: "Playlists",
                newName: "PlayListId");
        }
    }
}
