using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class AddingCBp1570Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CBc1510SglT1_CBc1510Confgs",
                table: "CatchBasins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CBp1570Typ",
                table: "CatchBasins",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CBc1510SglT1_CBc1510Confgs",
                table: "CatchBasins");

            migrationBuilder.DropColumn(
                name: "CBp1570Typ",
                table: "CatchBasins");
        }
    }
}
