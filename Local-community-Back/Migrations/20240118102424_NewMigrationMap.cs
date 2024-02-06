using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Local_community_Back.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrationMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Map",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Map");
        }
    }
}
