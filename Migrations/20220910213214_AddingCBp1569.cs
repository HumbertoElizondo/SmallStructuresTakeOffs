using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class AddingCBp1569 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CBc1592_CBConfg",
                table: "CatchBasins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CBc1592_CBwings",
                table: "CatchBasins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CBc1592_Genres",
                table: "CatchBasins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CBp1569Types",
                table: "CatchBasins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CBp1569Wings",
                table: "CatchBasins",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CBc1592_CBConfg",
                table: "CatchBasins");

            migrationBuilder.DropColumn(
                name: "CBc1592_CBwings",
                table: "CatchBasins");

            migrationBuilder.DropColumn(
                name: "CBc1592_Genres",
                table: "CatchBasins");

            migrationBuilder.DropColumn(
                name: "CBp1569Types",
                table: "CatchBasins");

            migrationBuilder.DropColumn(
                name: "CBp1569Wings",
                table: "CatchBasins");
        }
    }
}
