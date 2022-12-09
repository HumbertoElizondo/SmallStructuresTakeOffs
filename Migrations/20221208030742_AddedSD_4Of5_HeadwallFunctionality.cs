using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class AddedSD_4Of5_HeadwallFunctionality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ConcrCY",
                table: "Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ReinfLB",
                table: "Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SD630_H",
                table: "Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SD630_X",
                table: "Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SD630_Y",
                table: "Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SD630_Z",
                table: "Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Skews",
                table: "Headwalls",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slopes",
                table: "Headwalls",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcrCY",
                table: "Headwalls");

            migrationBuilder.DropColumn(
                name: "ReinfLB",
                table: "Headwalls");

            migrationBuilder.DropColumn(
                name: "SD630_H",
                table: "Headwalls");

            migrationBuilder.DropColumn(
                name: "SD630_X",
                table: "Headwalls");

            migrationBuilder.DropColumn(
                name: "SD630_Y",
                table: "Headwalls");

            migrationBuilder.DropColumn(
                name: "SD630_Z",
                table: "Headwalls");

            migrationBuilder.DropColumn(
                name: "Skews",
                table: "Headwalls");

            migrationBuilder.DropColumn(
                name: "Slopes",
                table: "Headwalls");
        }
    }
}
