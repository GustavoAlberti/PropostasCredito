using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigitacaoProposta.Migrations
{
    /// <inheritdoc />
    public partial class Ajustenatabeladepropostas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AGENTES",
                keyColumn: "ID",
                keyValue: new Guid("35165012-9794-499d-a0a1-506ed30e7a53"));

            migrationBuilder.DeleteData(
                table: "AGENTES",
                keyColumn: "ID",
                keyValue: new Guid("5f3cd5b6-40cb-436a-88e7-f2d1160e2470"));

            migrationBuilder.DeleteData(
                table: "AGENTES",
                keyColumn: "ID",
                keyValue: new Guid("98f15011-5c9a-4c53-a275-fe1a299f89c9"));

            migrationBuilder.DeleteData(
                table: "CLIENTES",
                keyColumn: "ID",
                keyValue: new Guid("c25b1c2c-b08a-4ff3-8866-86973c41d7db"));

            migrationBuilder.DeleteData(
                table: "ESTADOS",
                keyColumn: "ID",
                keyValue: new Guid("727572ab-0a5b-4956-992b-3ab43ab7c349"));

            migrationBuilder.DeleteData(
                table: "ESTADOS",
                keyColumn: "ID",
                keyValue: new Guid("7d6fcf71-4fd1-45f5-8e8f-349f251d3997"));

            migrationBuilder.DeleteData(
                table: "ESTADOS",
                keyColumn: "ID",
                keyValue: new Guid("b070ce09-3fe6-4cc0-9616-bf4ca9a52ab8"));

            migrationBuilder.DeleteData(
                table: "ESTADOS",
                keyColumn: "ID",
                keyValue: new Guid("e0501a9c-3be2-4c99-84e7-53f4cba886ee"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAULTIMAPARCELA",
                table: "PROPOSTAS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AGENTES",
                columns: new[] { "ID", "CPFAGENTE", "NOME", "STATUS", "UF" },
                values: new object[,]
                {
                    { new Guid("26f17195-496b-41e8-90f2-54a48cb4eeea"), "02635418097", "Joao Pedro", "Ativo", "RS" },
                    { new Guid("6a291a3a-367a-45ad-8b8f-94d256112e9e"), "32165498701", "Maria Rita", "Ativo", "SP" },
                    { new Guid("e133a99d-fd0e-40a5-a598-f33a5722c2fa"), "12345678901", "Marcio Junior", "Ativo", "SP" }
                });

            migrationBuilder.InsertData(
                table: "CLIENTES",
                columns: new[] { "ID", "CIDADENATURALIDADE", "CIDADERESIDENCIAL", "CPF", "DATANASCIMENTO", "EMAIL", "NOME", "RENDIMENTOMENSAL", "SEXO", "STATUSCPF", "TELEFONE", "TELEFONEDDD", "UFNATURALIDADE", "UFRESIDENCIAL" },
                values: new object[] { new Guid("53888a25-456c-4d10-a5eb-a0098f0bc5ac"), "Campinas", "São Paulo", "12345678901", new DateTime(1980, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "joao.silva@example.com", "João Silva", 3500.00m, "Masculino", "Liberado", "987654321", "11", "SP", "SP" });

            migrationBuilder.InsertData(
                table: "ESTADOS",
                columns: new[] { "ID", "DDD", "NOME", "REQUERASSINATURAHIBRIDA", "RESTRICAODEVALOR", "UF" },
                values: new object[,]
                {
                    { new Guid("00800786-8a8f-434a-a0cd-2674ba9c91bb"), "31", "Minas Gerais", false, 75000.00m, "MG" },
                    { new Guid("5553a8ba-7d98-438c-bf98-4509ef568ade"), "51", "Rio Grande do Sul", true, 50000.00m, "RS" },
                    { new Guid("85d9a02b-df22-4e24-a29c-3e4df8f43cf1"), "11", "São Paulo", false, 100000.00m, "SP" },
                    { new Guid("9ec008ec-4f45-4b44-98f9-e3a8dd9fb577"), "21", "Rio de Janeiro", true, 85000.00m, "RJ" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AGENTES",
                keyColumn: "ID",
                keyValue: new Guid("26f17195-496b-41e8-90f2-54a48cb4eeea"));

            migrationBuilder.DeleteData(
                table: "AGENTES",
                keyColumn: "ID",
                keyValue: new Guid("6a291a3a-367a-45ad-8b8f-94d256112e9e"));

            migrationBuilder.DeleteData(
                table: "AGENTES",
                keyColumn: "ID",
                keyValue: new Guid("e133a99d-fd0e-40a5-a598-f33a5722c2fa"));

            migrationBuilder.DeleteData(
                table: "CLIENTES",
                keyColumn: "ID",
                keyValue: new Guid("53888a25-456c-4d10-a5eb-a0098f0bc5ac"));

            migrationBuilder.DeleteData(
                table: "ESTADOS",
                keyColumn: "ID",
                keyValue: new Guid("00800786-8a8f-434a-a0cd-2674ba9c91bb"));

            migrationBuilder.DeleteData(
                table: "ESTADOS",
                keyColumn: "ID",
                keyValue: new Guid("5553a8ba-7d98-438c-bf98-4509ef568ade"));

            migrationBuilder.DeleteData(
                table: "ESTADOS",
                keyColumn: "ID",
                keyValue: new Guid("85d9a02b-df22-4e24-a29c-3e4df8f43cf1"));

            migrationBuilder.DeleteData(
                table: "ESTADOS",
                keyColumn: "ID",
                keyValue: new Guid("9ec008ec-4f45-4b44-98f9-e3a8dd9fb577"));

            migrationBuilder.DropColumn(
                name: "DATAULTIMAPARCELA",
                table: "PROPOSTAS");

            migrationBuilder.InsertData(
                table: "AGENTES",
                columns: new[] { "ID", "CPFAGENTE", "NOME", "STATUS", "UF" },
                values: new object[,]
                {
                    { new Guid("35165012-9794-499d-a0a1-506ed30e7a53"), "12345678901", "Marcio Junior", "Ativo", "SP" },
                    { new Guid("5f3cd5b6-40cb-436a-88e7-f2d1160e2470"), "32165498701", "Maria Rita", "Ativo", "SP" },
                    { new Guid("98f15011-5c9a-4c53-a275-fe1a299f89c9"), "02635418097", "Joao Pedro", "Ativo", "RS" }
                });

            migrationBuilder.InsertData(
                table: "CLIENTES",
                columns: new[] { "ID", "CIDADENATURALIDADE", "CIDADERESIDENCIAL", "CPF", "DATANASCIMENTO", "EMAIL", "NOME", "RENDIMENTOMENSAL", "SEXO", "STATUSCPF", "TELEFONE", "TELEFONEDDD", "UFNATURALIDADE", "UFRESIDENCIAL" },
                values: new object[] { new Guid("c25b1c2c-b08a-4ff3-8866-86973c41d7db"), "Campinas", "São Paulo", "12345678901", new DateTime(1980, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "joao.silva@example.com", "João Silva", 3500.00m, "Masculino", "Liberado", "987654321", "11", "SP", "SP" });

            migrationBuilder.InsertData(
                table: "ESTADOS",
                columns: new[] { "ID", "DDD", "NOME", "REQUERASSINATURAHIBRIDA", "RESTRICAODEVALOR", "UF" },
                values: new object[,]
                {
                    { new Guid("727572ab-0a5b-4956-992b-3ab43ab7c349"), "31", "Minas Gerais", false, 75000.00m, "MG" },
                    { new Guid("7d6fcf71-4fd1-45f5-8e8f-349f251d3997"), "51", "Rio Grande do Sul", true, 50000.00m, "RS" },
                    { new Guid("b070ce09-3fe6-4cc0-9616-bf4ca9a52ab8"), "21", "Rio de Janeiro", true, 85000.00m, "RJ" },
                    { new Guid("e0501a9c-3be2-4c99-84e7-53f4cba886ee"), "11", "São Paulo", false, 100000.00m, "SP" }
                });
        }
    }
}
