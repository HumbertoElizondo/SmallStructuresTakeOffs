using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class chgRebarReqProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RebarRequests_Projects_ProjectId",
                table: "RebarRequests");

            migrationBuilder.AlterColumn<long>(
                name: "ProjectId",
                table: "RebarRequests",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "RebReqProjId",
                table: "RebarRequests",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_RebarRequests_Projects_ProjectId",
                table: "RebarRequests",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RebarRequests_Projects_ProjectId",
                table: "RebarRequests");

            migrationBuilder.DropColumn(
                name: "RebReqProjId",
                table: "RebarRequests");

            migrationBuilder.AlterColumn<long>(
                name: "ProjectId",
                table: "RebarRequests",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RebarRequests_Projects_ProjectId",
                table: "RebarRequests",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
