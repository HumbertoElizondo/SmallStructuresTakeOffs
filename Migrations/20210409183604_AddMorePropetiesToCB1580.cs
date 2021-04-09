using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class AddMorePropetiesToCB1580 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "C1580Reb4FandI",
                table: "C1580CBs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "C1580Reb4Purch",
                table: "C1580CBs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "C1580Reb4FandI",
                table: "C1580CBs");

            migrationBuilder.DropColumn(
                name: "C1580Reb4Purch",
                table: "C1580CBs");
        }
    }
}
