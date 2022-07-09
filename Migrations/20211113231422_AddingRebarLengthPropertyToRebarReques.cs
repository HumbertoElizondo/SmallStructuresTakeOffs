using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class AddingRebarLengthPropertyToRebarReques : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RebLength",
                table: "RebarRequests",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RebLength",
                table: "RebarRequests");
        }
    }
}
