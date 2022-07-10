using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class anotherSameIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatchBasins_Projects_ProjectId",
                table: "CatchBasins");

            migrationBuilder.DropIndex(
                name: "IX_CatchBasins_ProjectId",
                table: "CatchBasins");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "CatchBasins");

            migrationBuilder.CreateIndex(
                name: "IX_CatchBasins_ProjId",
                table: "CatchBasins",
                column: "ProjId");

            migrationBuilder.AddForeignKey(
                name: "FK_CatchBasins_Projects_ProjId",
                table: "CatchBasins",
                column: "ProjId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatchBasins_Projects_ProjId",
                table: "CatchBasins");

            migrationBuilder.DropIndex(
                name: "IX_CatchBasins_ProjId",
                table: "CatchBasins");

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
    }
}
