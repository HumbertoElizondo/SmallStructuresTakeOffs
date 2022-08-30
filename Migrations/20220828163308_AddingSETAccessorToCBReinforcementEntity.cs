using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class AddingSETAccessorToCBReinforcementEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CBreinforcement",
                columns: table => new
                {
                    CBreinforcementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CBId = table.Column<int>(type: "int", nullable: false),
                    CBreinfCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CBreinfShape = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CBreinfLength = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CBreinfQty = table.Column<int>(type: "int", nullable: false),
                    TotalLength = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CBRebarNom = table.Column<int>(type: "int", nullable: false),
                    CatchBasinId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CBreinforcement", x => x.CBreinforcementId);
                    table.ForeignKey(
                        name: "FK_CBreinforcement_CatchBasins_CatchBasinId",
                        column: x => x.CatchBasinId,
                        principalTable: "CatchBasins",
                        principalColumn: "CatchBasinId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CBreinforcement_CatchBasinId",
                table: "CBreinforcement",
                column: "CatchBasinId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CBreinforcement");
        }
    }
}
