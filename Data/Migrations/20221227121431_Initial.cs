using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PACIENTES",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "nchar(14)", fixedLength: true, maxLength: 14, nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATANASCIMENTO = table.Column<DateTime>(name: "DATA_NASCIMENTO", type: "date", nullable: false),
                    SEXO = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTES", x => x.CPF);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PACIENTES");
        }
    }
}
