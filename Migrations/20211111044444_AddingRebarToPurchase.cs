using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class AddingRebarToPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RebarToPurchase",
                columns: table => new
                {
                    RebarToPurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RebarToPurchaseNomination = table.Column<int>(type: "int", nullable: false),
                    RebarToPurchaseQuantity = table.Column<int>(type: "int", nullable: false),
                    RebarRequest = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RebarToPurchase", x => x.RebarToPurchaseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RebarToPurchase");
        }
    }
}
