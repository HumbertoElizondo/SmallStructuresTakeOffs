using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class AddedProjectPropertyToCatchBasin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CatchBasinProjectId",
                table: "CatchBasins",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ProjectId",
                table: "CatchBasins",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CatchBasins_ProjectId",
                table: "CatchBasins",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_CatchBasins_Projects_ProjectId",
                table: "CatchBasins",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatchBasins_Projects_ProjectId",
                table: "CatchBasins");

            migrationBuilder.DropIndex(
                name: "IX_CatchBasins_ProjectId",
                table: "CatchBasins");

            migrationBuilder.DropColumn(
                name: "CatchBasinProjectId",
                table: "CatchBasins");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "CatchBasins");
        }
    }
}
