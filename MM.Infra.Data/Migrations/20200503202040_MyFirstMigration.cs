using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MM.Infra.Data.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Apelido = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: true),
                    Telefone = table.Column<int>(nullable: false),
                    Genero = table.Column<int>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Senha = table.Column<string>(maxLength: 500, nullable: false),
                    Salt = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
