using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class AddingCBc1592Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "C1580CBs");

            migrationBuilder.AddColumn<int>(
                name: "CBc1591_CBConfg",
                table: "CatchBasins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CBc1591_CBCurbType",
                table: "CatchBasins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CBc1591_CBSlottedDrain",
                table: "CatchBasins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CBc1591_CBwings",
                table: "CatchBasins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CBc1591_Genres",
                table: "CatchBasins",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CBc1591_CBConfg",
                table: "CatchBasins");

            migrationBuilder.DropColumn(
                name: "CBc1591_CBCurbType",
                table: "CatchBasins");

            migrationBuilder.DropColumn(
                name: "CBc1591_CBSlottedDrain",
                table: "CatchBasins");

            migrationBuilder.DropColumn(
                name: "CBc1591_CBwings",
                table: "CatchBasins");

            migrationBuilder.DropColumn(
                name: "CBc1591_Genres",
                table: "CatchBasins");

            migrationBuilder.CreateTable(
                name: "C1580CBs",
                columns: table => new
                {
                    C1580CBId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C1580CBCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C1580CBDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C1580CBHeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    C1580Reb4FandI = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    C1580Reb4Purch = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C1580CBs", x => x.C1580CBId);
                });
        }
    }
}
