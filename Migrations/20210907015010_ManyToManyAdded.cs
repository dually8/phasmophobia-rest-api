using Microsoft.EntityFrameworkCore.Migrations;

namespace PhasmoRESTApi.Migrations
{
    public partial class ManyToManyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evidences_Ghosts_GhostId",
                table: "Evidences");

            migrationBuilder.DropIndex(
                name: "IX_Evidences_GhostId",
                table: "Evidences");

            migrationBuilder.DropColumn(
                name: "GhostId",
                table: "Evidences");

            migrationBuilder.CreateTable(
                name: "Ghost_Evidences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GhostId = table.Column<long>(type: "bigint", nullable: false),
                    EvidenceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ghost_Evidences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ghost_Evidences_Evidences_EvidenceId",
                        column: x => x.EvidenceId,
                        principalTable: "Evidences",
                        principalColumn: "EvidenceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ghost_Evidences_Ghosts_GhostId",
                        column: x => x.GhostId,
                        principalTable: "Ghosts",
                        principalColumn: "GhostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ghost_Evidences_EvidenceId",
                table: "Ghost_Evidences",
                column: "EvidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Ghost_Evidences_GhostId",
                table: "Ghost_Evidences",
                column: "GhostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ghost_Evidences");

            migrationBuilder.AddColumn<long>(
                name: "GhostId",
                table: "Evidences",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evidences_GhostId",
                table: "Evidences",
                column: "GhostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evidences_Ghosts_GhostId",
                table: "Evidences",
                column: "GhostId",
                principalTable: "Ghosts",
                principalColumn: "GhostId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
