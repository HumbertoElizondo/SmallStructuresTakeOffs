using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class AddingCBConfigurationToC1520 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CBConfg",
                table: "CatchBasins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genres",
                table: "CatchBasins",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CBConfg",
                table: "CatchBasins");

            migrationBuilder.DropColumn(
                name: "Genres",
                table: "CatchBasins");
        }
    }
}
