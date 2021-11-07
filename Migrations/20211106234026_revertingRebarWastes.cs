using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class revertingRebarWastes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RebarWastings_RebarRequests_RebarRequestId",
                table: "RebarWastings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RebarWastings",
                table: "RebarWastings");

            migrationBuilder.RenameTable(
                name: "RebarWastings",
                newName: "RebarWasting");

            migrationBuilder.RenameIndex(
                name: "IX_RebarWastings_RebarRequestId",
                table: "RebarWasting",
                newName: "IX_RebarWasting_RebarRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RebarWasting",
                table: "RebarWasting",
                column: "RebarWastingId");

            migrationBuilder.AddForeignKey(
                name: "FK_RebarWasting_RebarRequests_RebarRequestId",
                table: "RebarWasting",
                column: "RebarRequestId",
                principalTable: "RebarRequests",
                principalColumn: "RebarRequestId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RebarWasting_RebarRequests_RebarRequestId",
                table: "RebarWasting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RebarWasting",
                table: "RebarWasting");

            migrationBuilder.RenameTable(
                name: "RebarWasting",
                newName: "RebarWastings");

            migrationBuilder.RenameIndex(
                name: "IX_RebarWasting_RebarRequestId",
                table: "RebarWastings",
                newName: "IX_RebarWastings_RebarRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RebarWastings",
                table: "RebarWastings",
                column: "RebarWastingId");

            migrationBuilder.AddForeignKey(
                name: "FK_RebarWastings_RebarRequests_RebarRequestId",
                table: "RebarWastings",
                column: "RebarRequestId",
                principalTable: "RebarRequests",
                principalColumn: "RebarRequestId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
