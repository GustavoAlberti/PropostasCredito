using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigitacaoProposta.Migrations
{
    /// <inheritdoc />
    public partial class AJUSTESNOMESTABELAS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agentes_Conveniadas_ConveniadaId",
                table: "Agentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Propostas_Agentes_AgenteId",
                table: "Propostas");

            migrationBuilder.DropForeignKey(
                name: "FK_Propostas_Conveniadas_ConveniadaId",
                table: "Propostas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Propostas",
                table: "Propostas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estados",
                table: "Estados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conveniadas",
                table: "Conveniadas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agentes",
                table: "Agentes");

            migrationBuilder.DropIndex(
                name: "IX_Agentes_ConveniadaId",
                table: "Agentes");

            migrationBuilder.DropColumn(
                name: "ConveniadaId",
                table: "Agentes");

            migrationBuilder.RenameTable(
                name: "Propostas",
                newName: "PROPOSTAS");

            migrationBuilder.RenameTable(
                name: "Estados",
                newName: "ESTADOS");

            migrationBuilder.RenameTable(
                name: "Conveniadas",
                newName: "CONVENIADAS");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "CLIENTES");

            migrationBuilder.RenameTable(
                name: "Agentes",
                newName: "AGENTES");

            migrationBuilder.RenameColumn(
                name: "ValorParcela",
                table: "PROPOSTAS",
                newName: "VALORPARCELA");

            migrationBuilder.RenameColumn(
                name: "ValorEmprestimo",
                table: "PROPOSTAS",
                newName: "VALOREMPRESTIMO");

            migrationBuilder.RenameColumn(
                name: "TipoOperacao",
                table: "PROPOSTAS",
                newName: "TIPOOPERACAO");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "PROPOSTAS",
                newName: "STATUS");

            migrationBuilder.RenameColumn(
                name: "NumeroParcelas",
                table: "PROPOSTAS",
                newName: "NUMEROPARCELAS");

            migrationBuilder.RenameColumn(
                name: "DataPrimeiraParcela",
                table: "PROPOSTAS",
                newName: "DATAPRIMEIRAPARCELA");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "PROPOSTAS",
                newName: "DATACRIACAO");

            migrationBuilder.RenameColumn(
                name: "CpfCliente",
                table: "PROPOSTAS",
                newName: "CPFCLIENTE");

            migrationBuilder.RenameColumn(
                name: "ConveniadaId",
                table: "PROPOSTAS",
                newName: "CONVENIADAID");

            migrationBuilder.RenameColumn(
                name: "AgenteId",
                table: "PROPOSTAS",
                newName: "AGENTEID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PROPOSTAS",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Propostas_ConveniadaId",
                table: "PROPOSTAS",
                newName: "IX_PROPOSTAS_CONVENIADAID");

            migrationBuilder.RenameIndex(
                name: "IX_Propostas_AgenteId",
                table: "PROPOSTAS",
                newName: "IX_PROPOSTAS_AGENTEID");

            migrationBuilder.RenameColumn(
                name: "Uf",
                table: "ESTADOS",
                newName: "UF");

            migrationBuilder.RenameColumn(
                name: "RestricaoDeValor",
                table: "ESTADOS",
                newName: "RESTRICAODEVALOR");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "ESTADOS",
                newName: "NOME");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ESTADOS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Uf",
                table: "CONVENIADAS",
                newName: "UF");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "CONVENIADAS",
                newName: "NOME");

            migrationBuilder.RenameColumn(
                name: "AceitaRefinanciamento",
                table: "CONVENIADAS",
                newName: "ACEITAREFINANCIAMENTO");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CONVENIADAS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "CLIENTES",
                newName: "TELEFONE");

            migrationBuilder.RenameColumn(
                name: "StatusCpf",
                table: "CLIENTES",
                newName: "STATUSCPF");

            migrationBuilder.RenameColumn(
                name: "RendimentoMensal",
                table: "CLIENTES",
                newName: "RENDIMENTOMENSAL");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "CLIENTES",
                newName: "NOME");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "CLIENTES",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "CLIENTES",
                newName: "DATANASCIMENTO");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "CLIENTES",
                newName: "CPF");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CLIENTES",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Uf",
                table: "CLIENTES",
                newName: "UFRESIDENCIAL");

            migrationBuilder.RenameColumn(
                name: "Cidade",
                table: "CLIENTES",
                newName: "CIDADERESIDENCIAL");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "AGENTES",
                newName: "NOME");

            migrationBuilder.RenameColumn(
                name: "CpfAgente",
                table: "AGENTES",
                newName: "CPFAGENTE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AGENTES",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "varchar(20)",
                table: "AGENTES",
                newName: "STATUS");

            migrationBuilder.AddColumn<string>(
                name: "TIPOASSINATURA",
                table: "PROPOSTAS",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DDD",
                table: "ESTADOS",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "REQUERASSINATURAHIBRIDA",
                table: "ESTADOS",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CODIGO",
                table: "CONVENIADAS",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CIDADENATURALIDADE",
                table: "CLIENTES",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SEXO",
                table: "CLIENTES",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TELEFONEDDD",
                table: "CLIENTES",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UFNATURALIDADE",
                table: "CLIENTES",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "STATUS",
                table: "AGENTES",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "AGENTES",
                type: "nchar(2)",
                fixedLength: true,
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PROPOSTAS",
                table: "PROPOSTAS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESTADOS",
                table: "ESTADOS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CONVENIADAS",
                table: "CONVENIADAS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CLIENTES",
                table: "CLIENTES",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AGENTES",
                table: "AGENTES",
                column: "ID");

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
                table: "CONVENIADAS",
                columns: new[] { "ID", "ACEITAREFINANCIAMENTO", "CODIGO", "NOME", "UF" },
                values: new object[,]
                {
                    { new Guid("0b9bfb95-b9af-41de-9b02-fc301ba33302"), true, "CONV002", "SIAPE", "SP" },
                    { new Guid("b31c34af-ac07-46b0-ba62-853335ecb140"), true, "CONV001", "INSS", "SP" },
                    { new Guid("ed8081c8-5aa6-41ef-a5c2-9b405cc989f8"), false, "CONV003", "MARINHA", "SP" }
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_PROPOSTAS_AGENTES_AGENTEID",
                table: "PROPOSTAS",
                column: "AGENTEID",
                principalTable: "AGENTES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PROPOSTAS_CONVENIADAS_CONVENIADAID",
                table: "PROPOSTAS",
                column: "CONVENIADAID",
                principalTable: "CONVENIADAS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PROPOSTAS_AGENTES_AGENTEID",
                table: "PROPOSTAS");

            migrationBuilder.DropForeignKey(
                name: "FK_PROPOSTAS_CONVENIADAS_CONVENIADAID",
                table: "PROPOSTAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PROPOSTAS",
                table: "PROPOSTAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESTADOS",
                table: "ESTADOS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CONVENIADAS",
                table: "CONVENIADAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CLIENTES",
                table: "CLIENTES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AGENTES",
                table: "AGENTES");

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
                table: "CONVENIADAS",
                keyColumn: "ID",
                keyValue: new Guid("0b9bfb95-b9af-41de-9b02-fc301ba33302"));

            migrationBuilder.DeleteData(
                table: "CONVENIADAS",
                keyColumn: "ID",
                keyValue: new Guid("b31c34af-ac07-46b0-ba62-853335ecb140"));

            migrationBuilder.DeleteData(
                table: "CONVENIADAS",
                keyColumn: "ID",
                keyValue: new Guid("ed8081c8-5aa6-41ef-a5c2-9b405cc989f8"));

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

            migrationBuilder.DropColumn(
                name: "TIPOASSINATURA",
                table: "PROPOSTAS");

            migrationBuilder.DropColumn(
                name: "DDD",
                table: "ESTADOS");

            migrationBuilder.DropColumn(
                name: "REQUERASSINATURAHIBRIDA",
                table: "ESTADOS");

            migrationBuilder.DropColumn(
                name: "CODIGO",
                table: "CONVENIADAS");

            migrationBuilder.DropColumn(
                name: "CIDADENATURALIDADE",
                table: "CLIENTES");

            migrationBuilder.DropColumn(
                name: "SEXO",
                table: "CLIENTES");

            migrationBuilder.DropColumn(
                name: "TELEFONEDDD",
                table: "CLIENTES");

            migrationBuilder.DropColumn(
                name: "UFNATURALIDADE",
                table: "CLIENTES");

            migrationBuilder.DropColumn(
                name: "UF",
                table: "AGENTES");

            migrationBuilder.RenameTable(
                name: "PROPOSTAS",
                newName: "Propostas");

            migrationBuilder.RenameTable(
                name: "ESTADOS",
                newName: "Estados");

            migrationBuilder.RenameTable(
                name: "CONVENIADAS",
                newName: "Conveniadas");

            migrationBuilder.RenameTable(
                name: "CLIENTES",
                newName: "Clientes");

            migrationBuilder.RenameTable(
                name: "AGENTES",
                newName: "Agentes");

            migrationBuilder.RenameColumn(
                name: "VALORPARCELA",
                table: "Propostas",
                newName: "ValorParcela");

            migrationBuilder.RenameColumn(
                name: "VALOREMPRESTIMO",
                table: "Propostas",
                newName: "ValorEmprestimo");

            migrationBuilder.RenameColumn(
                name: "TIPOOPERACAO",
                table: "Propostas",
                newName: "TipoOperacao");

            migrationBuilder.RenameColumn(
                name: "STATUS",
                table: "Propostas",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "NUMEROPARCELAS",
                table: "Propostas",
                newName: "NumeroParcelas");

            migrationBuilder.RenameColumn(
                name: "DATAPRIMEIRAPARCELA",
                table: "Propostas",
                newName: "DataPrimeiraParcela");

            migrationBuilder.RenameColumn(
                name: "DATACRIACAO",
                table: "Propostas",
                newName: "DataCriacao");

            migrationBuilder.RenameColumn(
                name: "CPFCLIENTE",
                table: "Propostas",
                newName: "CpfCliente");

            migrationBuilder.RenameColumn(
                name: "CONVENIADAID",
                table: "Propostas",
                newName: "ConveniadaId");

            migrationBuilder.RenameColumn(
                name: "AGENTEID",
                table: "Propostas",
                newName: "AgenteId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Propostas",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_PROPOSTAS_CONVENIADAID",
                table: "Propostas",
                newName: "IX_Propostas_ConveniadaId");

            migrationBuilder.RenameIndex(
                name: "IX_PROPOSTAS_AGENTEID",
                table: "Propostas",
                newName: "IX_Propostas_AgenteId");

            migrationBuilder.RenameColumn(
                name: "UF",
                table: "Estados",
                newName: "Uf");

            migrationBuilder.RenameColumn(
                name: "RESTRICAODEVALOR",
                table: "Estados",
                newName: "RestricaoDeValor");

            migrationBuilder.RenameColumn(
                name: "NOME",
                table: "Estados",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Estados",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UF",
                table: "Conveniadas",
                newName: "Uf");

            migrationBuilder.RenameColumn(
                name: "NOME",
                table: "Conveniadas",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "ACEITAREFINANCIAMENTO",
                table: "Conveniadas",
                newName: "AceitaRefinanciamento");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Conveniadas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TELEFONE",
                table: "Clientes",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "STATUSCPF",
                table: "Clientes",
                newName: "StatusCpf");

            migrationBuilder.RenameColumn(
                name: "RENDIMENTOMENSAL",
                table: "Clientes",
                newName: "RendimentoMensal");

            migrationBuilder.RenameColumn(
                name: "NOME",
                table: "Clientes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "Clientes",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "DATANASCIMENTO",
                table: "Clientes",
                newName: "DataNascimento");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Clientes",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Clientes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UFRESIDENCIAL",
                table: "Clientes",
                newName: "Uf");

            migrationBuilder.RenameColumn(
                name: "CIDADERESIDENCIAL",
                table: "Clientes",
                newName: "Cidade");

            migrationBuilder.RenameColumn(
                name: "NOME",
                table: "Agentes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "CPFAGENTE",
                table: "Agentes",
                newName: "CpfAgente");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Agentes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "STATUS",
                table: "Agentes",
                newName: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "varchar(20)",
                table: "Agentes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AddColumn<Guid>(
                name: "ConveniadaId",
                table: "Agentes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Propostas",
                table: "Propostas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estados",
                table: "Estados",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conveniadas",
                table: "Conveniadas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agentes",
                table: "Agentes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Agentes_ConveniadaId",
                table: "Agentes",
                column: "ConveniadaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agentes_Conveniadas_ConveniadaId",
                table: "Agentes",
                column: "ConveniadaId",
                principalTable: "Conveniadas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Propostas_Agentes_AgenteId",
                table: "Propostas",
                column: "AgenteId",
                principalTable: "Agentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Propostas_Conveniadas_ConveniadaId",
                table: "Propostas",
                column: "ConveniadaId",
                principalTable: "Conveniadas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
