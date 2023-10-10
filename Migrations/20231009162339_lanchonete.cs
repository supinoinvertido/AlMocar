using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlMocar.Migrations
{
    /// <inheritdoc />
    public partial class Lanchonete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCategoria = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    itemid = table.Column<int>(type: "INTEGER", maxLength: 25, nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<int>(type: "INTEGER", maxLength: 10, nullable: false),
                    DescricaoCurta = table.Column<int>(type: "INTEGER", maxLength: 50, nullable: false),
                    DescricaoDetalhada = table.Column<int>(type: "INTEGER", maxLength: 150, nullable: false),
                    ImagemUrl = table.Column<string>(type: "TEXT", nullable: true),
                    ImagemPequenaUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Valor = table.Column<double>(type: "REAL", nullable: false),
                    Fazendo = table.Column<bool>(type: "INTEGER", nullable: false),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.itemid);
                    table.ForeignKey(
                        name: "FK_Items_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoriaId",
                table: "Items",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
