using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class ProvidingCBc1581Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CBc1510SglT1_CBc1510Confgs",
                table: "CatchBasins");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CBc1510SglT1_CBc1510Confgs",
                table: "CatchBasins",
                type: "int",
                nullable: true);
        }
    }
}
