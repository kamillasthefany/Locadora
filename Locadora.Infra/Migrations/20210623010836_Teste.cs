using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Infra.Migrations
{
    public partial class Teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeMime",
                table: "Filmes");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Filmes",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Filmes");

            migrationBuilder.AddColumn<string>(
                name: "TypeMime",
                table: "Filmes",
                type: "text",
                nullable: true);
        }
    }
}
