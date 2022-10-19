using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class RefreshingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PipeNo",
                table: "SD630Headwalls");

            migrationBuilder.DropColumn(
                name: "SD630Description",
                table: "SD630Headwalls");

            migrationBuilder.DropColumn(
                name: "SD630_A",
                table: "SD630Headwalls");

            migrationBuilder.DropColumn(
                name: "SD630_B",
                table: "SD630Headwalls");

            migrationBuilder.DropColumn(
                name: "SD630_C",
                table: "SD630Headwalls");

            migrationBuilder.DropColumn(
                name: "SD630_D",
                table: "SD630Headwalls");

            migrationBuilder.DropColumn(
                name: "SD630_E",
                table: "SD630Headwalls");

            migrationBuilder.DropColumn(
                name: "SD630_F",
                table: "SD630Headwalls");

            migrationBuilder.DropColumn(
                name: "SD630_G",
                table: "SD630Headwalls");

            migrationBuilder.DropColumn(
                name: "SD630_I_D",
                table: "SD630Headwalls");

            migrationBuilder.DropColumn(
                name: "SD630_L",
                table: "SD630Headwalls");

            migrationBuilder.DropColumn(
                name: "CBSqRingL",
                table: "CatchBasins");

            migrationBuilder.DropColumn(
                name: "CBVertBars",
                table: "CatchBasins");

            migrationBuilder.RenameColumn(
                name: "HWCode",
                table: "SD630Headwalls",
                newName: "HWcode");

            migrationBuilder.RenameColumn(
                name: "ThisHeadwall",
                table: "SD630Headwalls",
                newName: "ThisHeadwallId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HWcode",
                table: "SD630Headwalls",
                newName: "HWCode");

            migrationBuilder.RenameColumn(
                name: "ThisHeadwallId",
                table: "SD630Headwalls",
                newName: "ThisHeadwall");

            migrationBuilder.AddColumn<int>(
                name: "PipeNo",
                table: "SD630Headwalls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SD630Description",
                table: "SD630Headwalls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SD630_A",
                table: "SD630Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SD630_B",
                table: "SD630Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SD630_C",
                table: "SD630Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SD630_D",
                table: "SD630Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SD630_E",
                table: "SD630Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SD630_F",
                table: "SD630Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SD630_G",
                table: "SD630Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SD630_I_D",
                table: "SD630Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SD630_L",
                table: "SD630Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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
