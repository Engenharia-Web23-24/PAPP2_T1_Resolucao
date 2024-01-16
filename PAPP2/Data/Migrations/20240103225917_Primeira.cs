using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAPP2.Data.Migrations
{
    /// <inheritdoc />
    public partial class Primeira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnidadesCurriculares",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ECTS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesCurriculares", x => x.Codigo);
                });
    
            migrationBuilder.CreateTable(
                name: "Inscricoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UCId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscricoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscricoes_UnidadesCurriculares_UCId",
                        column: x => x.UCId,
                        principalTable: "UnidadesCurriculares",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });
    
            migrationBuilder.CreateIndex(
                name: "IX_Inscricoes_UCId",
                table: "Inscricoes",
                column: "UCId");
        }
    
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscricoes");
    
            migrationBuilder.DropTable(
                name: "UnidadesCurriculares");
        }
    }
}
