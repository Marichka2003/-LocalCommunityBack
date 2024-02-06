using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Local_community_Back.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigrationMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CATOTTG",
                table: "Map",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "COATUU",
                table: "Map",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Population",
                table: "Map",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CATOTTG",
                table: "Map");

            migrationBuilder.DropColumn(
                name: "COATUU",
                table: "Map");

            migrationBuilder.DropColumn(
                name: "Population",
                table: "Map");
        }
    }
}
