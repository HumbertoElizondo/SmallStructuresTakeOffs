using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallStructuresTakeOffs.Migrations
{
    public partial class AfterRemovingPreviousMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "P1569_1s",
                columns: table => new
                {
                    P1569_1Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    P1569_1MCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P1569_1MDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reb4FandI = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reb3Purch = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reb3FandI = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reb4Purch = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P1569_1s", x => x.P1569_1Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "RebarToPurchase",
                columns: table => new
                {
                    RebarToPurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RebarToPurchaseNomination = table.Column<int>(type: "int", nullable: false),
                    RebarToPurchaseQuantity = table.Column<int>(type: "int", nullable: false),
                    RebarRequest = table.Column<int>(type: "int", nullable: false),
                    RebarNomLengths = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RebarToPurchase", x => x.RebarToPurchaseId);
                });

            migrationBuilder.CreateTable(
                name: "CatchBasins",
                columns: table => new
                {
                    CatchBasinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CBCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CBHeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CBLength = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CBWidth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CBWallThickness = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CBBaseThickness = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CBRebFandI = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CBRebPurch = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProjId = table.Column<long>(type: "bigint", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CBc1510Confgs = table.Column<int>(type: "int", nullable: true),
                    CBc1520T3_Genres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CBc1520T3_CBConfg = table.Column<int>(type: "int", nullable: true),
                    CBc1520T3_CBwings = table.Column<int>(type: "int", nullable: true),
                    CBc1530Confgs = table.Column<int>(type: "int", nullable: true),
                    CBc1581Slps = table.Column<int>(type: "int", nullable: true),
                    CBc1591_CBSlottedDrain = table.Column<int>(type: "int", nullable: true),
                    CBc1591_CBCurbType = table.Column<int>(type: "int", nullable: true),
                    Genres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CBc1591_CBConfg = table.Column<int>(type: "int", nullable: true),
                    CBc1591_CBwings = table.Column<int>(type: "int", nullable: true),
                    CBSlottedDrain = table.Column<int>(type: "int", nullable: true),
                    CBCurbType = table.Column<int>(type: "int", nullable: true),
                    CBc1592_CBConfg = table.Column<int>(type: "int", nullable: true),
                    CBc1592_CBwings = table.Column<int>(type: "int", nullable: true),
                    CBConfg = table.Column<int>(type: "int", nullable: true),
                    CBwings = table.Column<int>(type: "int", nullable: true),
                    CBp1569Types = table.Column<int>(type: "int", nullable: true),
                    CBp1569Wings = table.Column<int>(type: "int", nullable: true),
                    CBp1570Typ = table.Column<int>(type: "int", nullable: true),
                    CBp1570Typ1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatchBasins", x => x.CatchBasinId);
                    table.ForeignKey(
                        name: "FK_CatchBasins_Projects_ProjId",
                        column: x => x.ProjId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Headwalls",
                columns: table => new
                {
                    HeadwallId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HWProjId = table.Column<long>(type: "bigint", nullable: false),
                    ThisHeadwallId = table.Column<int>(type: "int", nullable: false),
                    HWcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HWDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PipeNo = table.Column<int>(type: "int", nullable: false),
                    SD630_I_D = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SD630_A = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SD630_B = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SD630_C = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SD630_D = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SD630_E = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SD630_F = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SD630_G = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SD630_L = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SD630_H = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SD630_X = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SD630_Y = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SD630_Z = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConcrCY = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReinfLB = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RebNo4Req = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RebNo4Purch = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HWRebFandI = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HWRebPurch = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlowSides = table.Column<int>(type: "int", nullable: true),
                    Slopes = table.Column<int>(type: "int", nullable: true),
                    Skews = table.Column<int>(type: "int", nullable: true),
                    PipeDiameters = table.Column<int>(type: "int", nullable: true),
                    SD630_4Of5_Headwall_Slopes = table.Column<int>(type: "int", nullable: true),
                    SD630_4Of5_Headwall_Skews = table.Column<int>(type: "int", nullable: true),
                    SD630_4Of5_Headwall_PipeDiameters = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headwalls", x => x.HeadwallId);
                    table.ForeignKey(
                        name: "FK_Headwalls_Projects_HWProjId",
                        column: x => x.HWProjId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RebarRequests",
                columns: table => new
                {
                    RebarRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RebarRequestNomination = table.Column<int>(type: "int", nullable: false),
                    RebarRequestQty = table.Column<int>(type: "int", nullable: false),
                    RebarRequestLength = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RebReqProjId = table.Column<long>(type: "bigint", nullable: false),
                    Structure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RebReqDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RebarRequests", x => x.RebarRequestId);
                    table.ForeignKey(
                        name: "FK_RebarRequests_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId");
                });

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
                        principalColumn: "RebarRequestId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatchBasins_ProjId",
                table: "CatchBasins",
                column: "ProjId");

            migrationBuilder.CreateIndex(
                name: "IX_Headwalls_HWProjId",
                table: "Headwalls",
                column: "HWProjId");

            migrationBuilder.CreateIndex(
                name: "IX_RebarRequests_ProjectId",
                table: "RebarRequests",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RebarWastings_RebarRequestId",
                table: "RebarWastings",
                column: "RebarRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatchBasins");

            migrationBuilder.DropTable(
                name: "Headwalls");

            migrationBuilder.DropTable(
                name: "P1569_1s");

            migrationBuilder.DropTable(
                name: "RebarToPurchase");

            migrationBuilder.DropTable(
                name: "RebarWastings");

            migrationBuilder.DropTable(
                name: "RebarRequests");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
