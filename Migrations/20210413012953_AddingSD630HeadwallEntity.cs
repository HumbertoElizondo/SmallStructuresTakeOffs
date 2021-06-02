using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class AddingSD630HeadwallEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SD630Headwalls",
                columns: table => new
                {
                    SD630HeadwallId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SD630Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PipeNo = table.Column<int>(type: "int", nullable: false),
                    SD630_I_D = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SD630_A = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SD630_B = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SD630_C = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SD630_D = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SD630_E = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SD630_F = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SD630_G = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SD630_L = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RebNo4Req = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RebNo4Purch = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SD630Headwalls", x => x.SD630HeadwallId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SD630Headwalls");
        }
    }
}
