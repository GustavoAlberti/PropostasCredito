using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitacaoProposta.Migrations
{
    /// <inheritdoc />
    public partial class incluiagenteeconveniada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: new Guid("9189cc8a-c268-48b1-ae32-6e6caaaa65b9"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("e3fc60d4-7310-4bd6-911a-b6695bf02645"));

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Cidade", "Cpf", "DataNascimento", "Email", "Nome", "RendimentoMensal", "StatusCpf", "Telefone", "Uf" },
                values: new object[] { new Guid("5ee2eb04-bc25-4970-bded-5cf8c1ddd98b"), "São Paulo", "12345678900", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cliente@exemplo.com", "Cliente Ativo", 5000m, "Liberado", "11999999999", "SP" });

            migrationBuilder.InsertData(
                table: "Conveniadas",
                columns: new[] { "Id", "AceitaRefinanciamento", "Nome", "Uf" },
                values: new object[] { new Guid("b31c34af-ac07-46b0-ba62-853335ecb140"), true, "Conveniada Exemplo", "SP" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "Nome", "RestricaoDeValor", "Uf" },
                values: new object[] { new Guid("da92227a-4fec-4772-bebf-35b77f8c043d"), "São Paulo", 100000m, "SP" });

            migrationBuilder.InsertData(
                table: "Agentes",
                columns: new[] { "Id", "ConveniadaId", "CpfAgente", "Nome", "Status" },
                values: new object[] { new Guid("feea68ea-57ab-433f-bcf2-f825bf5b36d9"), new Guid("b31c34af-ac07-46b0-ba62-853335ecb140"), "12345678901", "Agente Ativo", "Ativo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agentes",
                keyColumn: "Id",
                keyValue: new Guid("feea68ea-57ab-433f-bcf2-f825bf5b36d9"));

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: new Guid("5ee2eb04-bc25-4970-bded-5cf8c1ddd98b"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("da92227a-4fec-4772-bebf-35b77f8c043d"));

            migrationBuilder.DeleteData(
                table: "Conveniadas",
                keyColumn: "Id",
                keyValue: new Guid("b31c34af-ac07-46b0-ba62-853335ecb140"));

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Cidade", "Cpf", "DataNascimento", "Email", "Nome", "RendimentoMensal", "StatusCpf", "Telefone", "Uf" },
                values: new object[] { new Guid("9189cc8a-c268-48b1-ae32-6e6caaaa65b9"), "São Paulo", "12345678900", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cliente@exemplo.com", "Cliente Ativo", 5000m, "Liberado", "11999999999", "SP" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "Nome", "RestricaoDeValor", "Uf" },
                values: new object[] { new Guid("e3fc60d4-7310-4bd6-911a-b6695bf02645"), "São Paulo", 100000m, "SP" });
        }
    }
}
