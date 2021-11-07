using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class rebarWastes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RebarWastings",
                columns: table => new
                {
                    RebarWastingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RebarWastingNomination = table.Column<int>(type: "int", nullable: false),
                    RebarWastingQuantity = table.Column<int>(type: "int", nullable: false),
                    RebarWastingLength = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RebarWastingReqNo = table.Column<int>(type: "int", nullable: false),
                    IsItAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ReqNo = table.Column<int>(type: "int", nullable: false),
                    RebarRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RebarWastings", x => x.RebarWastingId);
                    table.ForeignKey(
                        name: "FK_RebarWastings_RebarRequests_RebarRequestId",
                        column: x => x.RebarRequestId,
                        principalTable: "RebarRequests",
                        principalColumn: "RebarRequestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RebarWastings_RebarRequestId",
                table: "RebarWastings",
                column: "RebarRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RebarWastings");
        }
    }
}
