using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class adjustingP1569 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Reb3FandI",
                table: "P1569_1Ms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Reb3Purch",
                table: "P1569_1Ms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Reb4FandI",
                table: "P1569_1Ms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Reb4Purch",
                table: "P1569_1Ms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reb3FandI",
                table: "P1569_1Ms");

            migrationBuilder.DropColumn(
                name: "Reb3Purch",
                table: "P1569_1Ms");

            migrationBuilder.DropColumn(
                name: "Reb4FandI",
                table: "P1569_1Ms");

            migrationBuilder.DropColumn(
                name: "Reb4Purch",
                table: "P1569_1Ms");
        }
    }
}
