using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class AddingHWentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Headwalls",
                columns: table => new
                {
                    HeadwallId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HWProjId = table.Column<long>(type: "bigint", nullable: false),
                    ThisHeadwallId = table.Column<int>(type: "int", nullable: false),
                    HWcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HWDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SD630Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PipeNo = table.Column<int>(type: "int", nullable: true),
                    SD630_I_D = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SD630_A = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SD630_B = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SD630_C = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SD630_D = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SD630_E = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SD630_F = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SD630_G = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SD630_L = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RebNo4Req = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RebNo4Purch = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headwalls", x => x.HeadwallId);
                    table.ForeignKey(
                        name: "FK_Headwalls_Projects_HWProjId",
                        column: x => x.HWProjId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Headwalls_HWProjId",
                table: "Headwalls",
                column: "HWProjId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Headwalls");
        }
    }
}
