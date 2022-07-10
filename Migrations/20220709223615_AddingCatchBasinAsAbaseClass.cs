using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class AddingCatchBasinAsAbaseClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "RebarNomLengths",
                table: "RebarToPurchase",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "C1580CBHeight",
                table: "C1580CBs",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.CreateTable(
                name: "CatchBasins",
                columns: table => new
                {
                    CatchBasinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CBCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CBHeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CBLength = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CBWidth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CBWallThickness = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CBBaseThickness = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CBVertBars = table.Column<int>(type: "int", nullable: false),
                    CBSqRingL = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CBRebFandI = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CBRebPurch = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatchBasins", x => x.CatchBasinId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatchBasins");

            migrationBuilder.AlterColumn<int>(
                name: "RebarNomLengths",
                table: "RebarToPurchase",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "C1580CBHeight",
                table: "C1580CBs",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
