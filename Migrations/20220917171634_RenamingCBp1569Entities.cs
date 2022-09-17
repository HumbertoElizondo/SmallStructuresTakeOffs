using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class RenamingCBp1569Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "P1569_1Ms");

            migrationBuilder.RenameColumn(
                name: "Cbc1510Confgs",
                table: "CatchBasins",
                newName: "CBc1510Confgs");

            migrationBuilder.CreateTable(
                name: "P1569_1s",
                columns: table => new
                {
                    P1569_1Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    P1569_1MCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P1569_1MDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reb4FandI = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reb3Purch = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reb3FandI = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reb4Purch = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P1569_1s", x => x.P1569_1Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "P1569_1s");

            migrationBuilder.RenameColumn(
                name: "CBc1510Confgs",
                table: "CatchBasins",
                newName: "Cbc1510Confgs");

            migrationBuilder.CreateTable(
                name: "P1569_1Ms",
                columns: table => new
                {
                    P1569_1MId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    P1569_1MCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P1569_1MDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reb3FandI = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reb3Purch = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reb4FandI = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reb4Purch = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P1569_1Ms", x => x.P1569_1MId);
                });
        }
    }
}
