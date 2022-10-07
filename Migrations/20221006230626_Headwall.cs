using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class Headwall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SD630Headwalls",
                table: "SD630Headwalls");

            migrationBuilder.DropColumn(
                name: "CBSqRingL",
                table: "CatchBasins");

            migrationBuilder.DropColumn(
                name: "CBVertBars",
                table: "CatchBasins");

            migrationBuilder.RenameTable(
                name: "SD630Headwalls",
                newName: "Headwalls");

            migrationBuilder.RenameColumn(
                name: "HWCode",
                table: "Headwalls",
                newName: "HWcode");

            migrationBuilder.RenameColumn(
                name: "ThisHeadwall",
                table: "Headwalls",
                newName: "ThisHeadwallId");

            migrationBuilder.AlterColumn<decimal>(
                name: "SD630_L",
                table: "Headwalls",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SD630_I_D",
                table: "Headwalls",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SD630_G",
                table: "Headwalls",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SD630_F",
                table: "Headwalls",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SD630_E",
                table: "Headwalls",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SD630_D",
                table: "Headwalls",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SD630_C",
                table: "Headwalls",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SD630_B",
                table: "Headwalls",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SD630_A",
                table: "Headwalls",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "RebNo4Req",
                table: "Headwalls",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "RebNo4Purch",
                table: "Headwalls",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "PipeNo",
                table: "Headwalls",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SD630HeadwallId",
                table: "Headwalls",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "HeadwallId",
                table: "Headwalls",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Headwalls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "HWProjId",
                table: "Headwalls",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Headwalls",
                table: "Headwalls",
                column: "HeadwallId");

            migrationBuilder.CreateIndex(
                name: "IX_Headwalls_HWProjId",
                table: "Headwalls",
                column: "HWProjId");

            migrationBuilder.AddForeignKey(
                name: "FK_Headwalls_Projects_HWProjId",
                table: "Headwalls",
                column: "HWProjId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Headwalls_Projects_HWProjId",
                table: "Headwalls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Headwalls",
                table: "Headwalls");

            migrationBuilder.DropIndex(
                name: "IX_Headwalls_HWProjId",
                table: "Headwalls");

            migrationBuilder.DropColumn(
                name: "HeadwallId",
                table: "Headwalls");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Headwalls");

            migrationBuilder.DropColumn(
                name: "HWProjId",
                table: "Headwalls");

            migrationBuilder.RenameTable(
                name: "Headwalls",
                newName: "SD630Headwalls");

            migrationBuilder.RenameColumn(
                name: "HWcode",
                table: "SD630Headwalls",
                newName: "HWCode");

            migrationBuilder.RenameColumn(
                name: "ThisHeadwallId",
                table: "SD630Headwalls",
                newName: "ThisHeadwall");

            migrationBuilder.AddColumn<decimal>(
                name: "CBSqRingL",
                table: "CatchBasins",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CBVertBars",
                table: "CatchBasins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "SD630_L",
                table: "SD630Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SD630_I_D",
                table: "SD630Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SD630_G",
                table: "SD630Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SD630_F",
                table: "SD630Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SD630_E",
                table: "SD630Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SD630_D",
                table: "SD630Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SD630_C",
                table: "SD630Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SD630_B",
                table: "SD630Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SD630_A",
                table: "SD630Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SD630HeadwallId",
                table: "SD630Headwalls",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "RebNo4Req",
                table: "SD630Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "RebNo4Purch",
                table: "SD630Headwalls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PipeNo",
                table: "SD630Headwalls",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SD630Headwalls",
                table: "SD630Headwalls",
                column: "SD630HeadwallId");
        }
    }
}
