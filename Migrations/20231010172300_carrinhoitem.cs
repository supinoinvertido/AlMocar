using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlMocar.Migrations
{
    /// <inheritdoc />
    public partial class carrinhoitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fazendo",
                table: "Items",
                newName: "Destaque");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Items",
                type: "TEXT",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CarrinhoItems",
                columns: table => new
                {
                    CarrinhoItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    itemid = table.Column<int>(type: "INTEGER", nullable: true),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    CarrinhoId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoItems", x => x.CarrinhoItemId);
                    table.ForeignKey(
                        name: "FK_CarrinhoItems_Items_itemid",
                        column: x => x.itemid,
                        principalTable: "Items",
                        principalColumn: "itemid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoItems_itemid",
                table: "CarrinhoItems",
                column: "itemid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoItems");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Destaque",
                table: "Items",
                newName: "Fazendo");

            migrationBuilder.AlterColumn<int>(
                name: "Nome",
                table: "Items",
                type: "INTEGER",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 10);
        }
    }
}
