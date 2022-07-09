using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class mig02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RebLength",
                table: "RebarRequests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RebLength",
                table: "RebarRequests",
                type: "int",
                nullable: true);
        }
    }
}
