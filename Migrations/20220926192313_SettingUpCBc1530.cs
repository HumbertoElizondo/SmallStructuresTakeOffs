using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class SettingUpCBc1530 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CBc1530Confgs",
                table: "CatchBasins",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CBc1530Confgs",
                table: "CatchBasins");
        }
    }
}
