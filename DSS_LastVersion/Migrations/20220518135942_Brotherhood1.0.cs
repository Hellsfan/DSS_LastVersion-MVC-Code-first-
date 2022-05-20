using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSS_LastVersion.Migrations
{
    public partial class Brotherhood10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brotherhoods",
                columns: table => new
                {
                    BrotherhoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrotherhoodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrotherhoodLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brotherhoods", x => x.BrotherhoodId);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    MissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MissionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MissionLevel = table.Column<int>(type: "int", nullable: false),
                    Target = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.MissionID);
                });

            migrationBuilder.CreateTable(
                name: "Assassins",
                columns: table => new
                {
                    AssassinID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssassinName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssassinRank = table.Column<int>(type: "int", nullable: false),
                    BrotherhoodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assassins", x => x.AssassinID);
                    table.ForeignKey(
                        name: "FK_Assassins_Brotherhoods_BrotherhoodID",
                        column: x => x.BrotherhoodID,
                        principalTable: "Brotherhoods",
                        principalColumn: "BrotherhoodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssassinID = table.Column<int>(type: "int", nullable: false),
                    MissionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractID);
                    table.ForeignKey(
                        name: "FK_Contracts_Assassins_AssassinID",
                        column: x => x.AssassinID,
                        principalTable: "Assassins",
                        principalColumn: "AssassinID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Missions_MissionID",
                        column: x => x.MissionID,
                        principalTable: "Missions",
                        principalColumn: "MissionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assassins_BrotherhoodID",
                table: "Assassins",
                column: "BrotherhoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_AssassinID",
                table: "Contracts",
                column: "AssassinID");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_MissionID",
                table: "Contracts",
                column: "MissionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Assassins");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "Brotherhoods");
        }
    }
}
