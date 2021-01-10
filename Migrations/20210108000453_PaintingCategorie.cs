using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect.Migrations
{
    public partial class PaintingCategorie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GalerieID",
                table: "Painting",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCategorie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Galerie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeGalerie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galerie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PaintingCategorie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaintingID = table.Column<int>(nullable: false),
                    CategorieID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaintingCategorie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PaintingCategorie_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaintingCategorie_Painting_PaintingID",
                        column: x => x.PaintingID,
                        principalTable: "Painting",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Painting_GalerieID",
                table: "Painting",
                column: "GalerieID");

            migrationBuilder.CreateIndex(
                name: "IX_PaintingCategorie_CategorieID",
                table: "PaintingCategorie",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_PaintingCategorie_PaintingID",
                table: "PaintingCategorie",
                column: "PaintingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Painting_Galerie_GalerieID",
                table: "Painting",
                column: "GalerieID",
                principalTable: "Galerie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Painting_Galerie_GalerieID",
                table: "Painting");

            migrationBuilder.DropTable(
                name: "Galerie");

            migrationBuilder.DropTable(
                name: "PaintingCategorie");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Painting_GalerieID",
                table: "Painting");

            migrationBuilder.DropColumn(
                name: "GalerieID",
                table: "Painting");
        }
    }
}
