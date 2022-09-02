using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class AddedPropertiesToCB1591 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CBCurbType",
                table: "CatchBasins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CBSlottedDrain",
                table: "CatchBasins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CBc1520T3_CBConfg",
                table: "CatchBasins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CBc1520T3_CBwings",
                table: "CatchBasins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CBc1520T3_Genres",
                table: "CatchBasins",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CBCurbType",
                table: "CatchBasins");

            migrationBuilder.DropColumn(
                name: "CBSlottedDrain",
                table: "CatchBasins");

            migrationBuilder.DropColumn(
                name: "CBc1520T3_CBConfg",
                table: "CatchBasins");

            migrationBuilder.DropColumn(
                name: "CBc1520T3_CBwings",
                table: "CatchBasins");

            migrationBuilder.DropColumn(
                name: "CBc1520T3_Genres",
                table: "CatchBasins");
        }
    }
}
