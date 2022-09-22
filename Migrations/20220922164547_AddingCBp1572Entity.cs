using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class AddingCBp1572Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CBp1570Typ1",
                table: "CatchBasins",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CBp1570Typ1",
                table: "CatchBasins");
        }
    }
}
