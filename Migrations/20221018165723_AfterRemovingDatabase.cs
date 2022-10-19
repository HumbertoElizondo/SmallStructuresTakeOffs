using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class AfterRemovingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProjId",
                table: "SD630Headwalls",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "SmallStructures",
                columns: table => new
                {
                    SmStId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThisStructure = table.Column<int>(type: "int", nullable: false),
                    HWcode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmallStructures", x => x.SmStId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SD630Headwalls_ProjId",
                table: "SD630Headwalls",
                column: "ProjId");

            migrationBuilder.AddForeignKey(
                name: "FK_SD630Headwalls_Projects_ProjId",
                table: "SD630Headwalls",
                column: "ProjId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SD630Headwalls_Projects_ProjId",
                table: "SD630Headwalls");

            migrationBuilder.DropTable(
                name: "SmallStructures");

            migrationBuilder.DropIndex(
                name: "IX_SD630Headwalls_ProjId",
                table: "SD630Headwalls");

            migrationBuilder.DropColumn(
                name: "ProjId",
                table: "SD630Headwalls");
        }
    }
}
