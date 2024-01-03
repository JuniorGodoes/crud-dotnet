using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "allBooks");

            migrationBuilder.AddColumn<int>(
                name: "Ano",
                table: "allBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "allCategorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LivrosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_allCategorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_allCategorias_allBooks_LivrosId",
                        column: x => x.LivrosId,
                        principalTable: "allBooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_allCategorias_LivrosId",
                table: "allCategorias",
                column: "LivrosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "allCategorias");

            migrationBuilder.DropColumn(
                name: "Ano",
                table: "allBooks");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "allBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
