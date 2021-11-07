using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class AddingRebarRequestEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RebarRequest_Projects_ProjectId",
                table: "RebarRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RebarRequest",
                table: "RebarRequest");

            migrationBuilder.RenameTable(
                name: "RebarRequest",
                newName: "RebarRequests");

            migrationBuilder.RenameIndex(
                name: "IX_RebarRequest_ProjectId",
                table: "RebarRequests",
                newName: "IX_RebarRequests_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RebarRequests",
                table: "RebarRequests",
                column: "RebarRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_RebarRequests_Projects_ProjectId",
                table: "RebarRequests",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RebarRequests_Projects_ProjectId",
                table: "RebarRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RebarRequests",
                table: "RebarRequests");

            migrationBuilder.RenameTable(
                name: "RebarRequests",
                newName: "RebarRequest");

            migrationBuilder.RenameIndex(
                name: "IX_RebarRequests_ProjectId",
                table: "RebarRequest",
                newName: "IX_RebarRequest_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RebarRequest",
                table: "RebarRequest",
                column: "RebarRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_RebarRequest_Projects_ProjectId",
                table: "RebarRequest",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
