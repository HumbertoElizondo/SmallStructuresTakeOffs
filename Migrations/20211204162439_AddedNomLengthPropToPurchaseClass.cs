using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class AddedNomLengthPropToPurchaseClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RebarNomLengths",
                table: "RebarToPurchase",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RebarNomLengths",
                table: "RebarToPurchase");
        }
    }
}
