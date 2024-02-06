using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Local_community_Back.Migrations
{
    /// <inheritdoc />
    public partial class NewInfrastructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Infrastructure",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Infrastructure",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Infrastructure");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Infrastructure");
        }
    }
}
