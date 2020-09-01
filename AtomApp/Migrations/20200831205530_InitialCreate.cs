using Microsoft.EntityFrameworkCore.Migrations;

namespace AtomApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "classes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomClasse = table.Column<string>(nullable: true),
                    nbMaxEt = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "modules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomModule = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "etudiants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(nullable: true),
                    adresse = table.Column<string>(nullable: true),
                    cin = table.Column<string>(nullable: true),
                    numTel = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    classeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etudiants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_etudiants_classes_classeId",
                        column: x => x.classeId,
                        principalTable: "classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "matieres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomMatiere = table.Column<string>(nullable: true),
                    moduleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matieres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_matieres_modules_moduleId",
                        column: x => x.moduleId,
                        principalTable: "modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "seances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<string>(nullable: true),
                    classeId = table.Column<int>(nullable: true),
                    matiereId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_seances_classes_classeId",
                        column: x => x.classeId,
                        principalTable: "classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_seances_matieres_matiereId",
                        column: x => x.matiereId,
                        principalTable: "matieres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "absences",
                columns: table => new
                {
                    etudiantId = table.Column<int>(nullable: false),
                    seanceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_absences", x => new { x.etudiantId, x.seanceId });
                    table.ForeignKey(
                        name: "FK_absences_etudiants_etudiantId",
                        column: x => x.etudiantId,
                        principalTable: "etudiants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_absences_seances_seanceId",
                        column: x => x.seanceId,
                        principalTable: "seances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_absences_seanceId",
                table: "absences",
                column: "seanceId");

            migrationBuilder.CreateIndex(
                name: "IX_etudiants_classeId",
                table: "etudiants",
                column: "classeId");

            migrationBuilder.CreateIndex(
                name: "IX_matieres_moduleId",
                table: "matieres",
                column: "moduleId");

            migrationBuilder.CreateIndex(
                name: "IX_seances_classeId",
                table: "seances",
                column: "classeId");

            migrationBuilder.CreateIndex(
                name: "IX_seances_matiereId",
                table: "seances",
                column: "matiereId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "absences");

            migrationBuilder.DropTable(
                name: "etudiants");

            migrationBuilder.DropTable(
                name: "seances");

            migrationBuilder.DropTable(
                name: "classes");

            migrationBuilder.DropTable(
                name: "matieres");

            migrationBuilder.DropTable(
                name: "modules");
        }
    }
}
