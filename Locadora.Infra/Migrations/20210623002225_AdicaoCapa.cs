using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Infra.Migrations
{
    public partial class AdicaoCapa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Capa",
                table: "Filmes",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeMime",
                table: "Filmes",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capa",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "TypeMime",
                table: "Filmes");
        }
    }
}
