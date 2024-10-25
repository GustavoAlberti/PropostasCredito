using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitacaoProposta.Migrations
{
    /// <inheritdoc />
    public partial class incluiclienteeestado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Cidade", "Cpf", "DataNascimento", "Email", "Nome", "RendimentoMensal", "StatusCpf", "Telefone", "Uf" },
                values: new object[] { new Guid("9189cc8a-c268-48b1-ae32-6e6caaaa65b9"), "São Paulo", "12345678900", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cliente@exemplo.com", "Cliente Ativo", 5000m, "Liberado", "11999999999", "SP" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "Nome", "RestricaoDeValor", "Uf" },
                values: new object[] { new Guid("e3fc60d4-7310-4bd6-911a-b6695bf02645"), "São Paulo", 100000m, "SP" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: new Guid("9189cc8a-c268-48b1-ae32-6e6caaaa65b9"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("e3fc60d4-7310-4bd6-911a-b6695bf02645"));
        }
    }
}
