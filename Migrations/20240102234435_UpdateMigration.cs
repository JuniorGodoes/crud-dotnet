using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_allCategorias_allBooks_LivrosId",
                table: "allCategorias");

            migrationBuilder.DropIndex(
                name: "IX_allCategorias_LivrosId",
                table: "allCategorias");

            migrationBuilder.DropColumn(
                name: "LivrosId",
                table: "allCategorias");

            migrationBuilder.AddColumn<string>(
                name: "Categorias",
                table: "allBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categorias",
                table: "allBooks");

            migrationBuilder.AddColumn<int>(
                name: "LivrosId",
                table: "allCategorias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_allCategorias_LivrosId",
                table: "allCategorias",
                column: "LivrosId");

            migrationBuilder.AddForeignKey(
                name: "FK_allCategorias_allBooks_LivrosId",
                table: "allCategorias",
                column: "LivrosId",
                principalTable: "allBooks",
                principalColumn: "Id");
        }
    }
}
