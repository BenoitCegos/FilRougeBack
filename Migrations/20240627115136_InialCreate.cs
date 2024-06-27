using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilRouge.Migrations
{
    /// <inheritdoc />
    public partial class InialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projet",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Liste",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    projet_id = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liste", x => x.id);
                    table.ForeignKey(
                        name: "FK_Liste_Projet_projet_id",
                        column: x => x.projet_id,
                        principalTable: "Projet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tache",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    endDate = table.Column<DateOnly>(type: "DATE", nullable: true),
                    liste_id = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tache", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tache_Liste_liste_id",
                        column: x => x.liste_id,
                        principalTable: "Liste",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commentaire",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    tache_id = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaire", x => x.id);
                    table.ForeignKey(
                        name: "FK_Commentaire_Tache_tache_id",
                        column: x => x.tache_id,
                        principalTable: "Tache",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commentaire_tache_id",
                table: "Commentaire",
                column: "tache_id");

            migrationBuilder.CreateIndex(
                name: "IX_Liste_projet_id",
                table: "Liste",
                column: "projet_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tache_liste_id",
                table: "Tache",
                column: "liste_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commentaire");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Tache");

            migrationBuilder.DropTable(
                name: "Liste");

            migrationBuilder.DropTable(
                name: "Projet");
        }
    }
}
