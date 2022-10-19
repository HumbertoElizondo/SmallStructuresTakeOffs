using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class ToUpdateCommit7bc2e434 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CBSqRingL",
                table: "CatchBasins");

            migrationBuilder.DropColumn(
                name: "CBVertBars",
                table: "CatchBasins");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CBSqRingL",
                table: "CatchBasins",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CBVertBars",
                table: "CatchBasins",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
