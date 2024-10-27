﻿// <auto-generated />
using System;
using DigitacaoProposta.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DigitacaoProposta.Migrations
{
    [DbContext(typeof(GravarPropostaDbContext))]
    [Migration("20241027232259_Ajuste na tabela de propostas")]
    partial class Ajustenatabeladepropostas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DigitacaoProposta.Dominio.GravarProposta.Agente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("CpfAgente")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("CPFAGENTE");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NOME");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("STATUS");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nchar(2)")
                        .HasColumnName("UF")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("AGENTES", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("e133a99d-fd0e-40a5-a598-f33a5722c2fa"),
                            CpfAgente = "12345678901",
                            Nome = "Marcio Junior",
                            Status = "Ativo",
                            Uf = "SP"
                        },
                        new
                        {
                            Id = new Guid("6a291a3a-367a-45ad-8b8f-94d256112e9e"),
                            CpfAgente = "32165498701",
                            Nome = "Maria Rita",
                            Status = "Ativo",
                            Uf = "SP"
                        },
                        new
                        {
                            Id = new Guid("26f17195-496b-41e8-90f2-54a48cb4eeea"),
                            CpfAgente = "02635418097",
                            Nome = "Joao Pedro",
                            Status = "Ativo",
                            Uf = "RS"
                        });
                });

            modelBuilder.Entity("DigitacaoProposta.Dominio.GravarProposta.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("CidadeNaturalidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CIDADENATURALIDADE");

                    b.Property<string>("CidadeResidencial")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CIDADERESIDENCIAL");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("CPF");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATANASCIMENTO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NOME");

                    b.Property<decimal>("RendimentoMensal")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("RENDIMENTOMENSAL");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("SEXO");

                    b.Property<string>("StatusCpf")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("STATUSCPF");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("TELEFONE");

                    b.Property<string>("TelefoneDDD")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("TELEFONEDDD");

                    b.Property<string>("UfNaturalidade")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("UFNATURALIDADE");

                    b.Property<string>("UfResidencial")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("UFRESIDENCIAL");

                    b.HasKey("Id");

                    b.ToTable("CLIENTES", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("53888a25-456c-4d10-a5eb-a0098f0bc5ac"),
                            CidadeNaturalidade = "Campinas",
                            CidadeResidencial = "São Paulo",
                            Cpf = "12345678901",
                            DataNascimento = new DateTime(1980, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "joao.silva@example.com",
                            Nome = "João Silva",
                            RendimentoMensal = 3500.00m,
                            Sexo = "Masculino",
                            StatusCpf = "Liberado",
                            Telefone = "987654321",
                            TelefoneDDD = "11",
                            UfNaturalidade = "SP",
                            UfResidencial = "SP"
                        });
                });

            modelBuilder.Entity("DigitacaoProposta.Dominio.GravarProposta.Conveniada", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<bool>("AceitaRefinanciamento")
                        .HasColumnType("bit")
                        .HasColumnName("ACEITAREFINANCIAMENTO");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("CODIGO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NOME");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nchar(2)")
                        .HasColumnName("UF")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("CONVENIADAS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("b31c34af-ac07-46b0-ba62-853335ecb140"),
                            AceitaRefinanciamento = true,
                            Codigo = "CONV001",
                            Nome = "INSS",
                            Uf = "SP"
                        },
                        new
                        {
                            Id = new Guid("0b9bfb95-b9af-41de-9b02-fc301ba33302"),
                            AceitaRefinanciamento = true,
                            Codigo = "CONV002",
                            Nome = "SIAPE",
                            Uf = "SP"
                        },
                        new
                        {
                            Id = new Guid("ed8081c8-5aa6-41ef-a5c2-9b405cc989f8"),
                            AceitaRefinanciamento = false,
                            Codigo = "CONV003",
                            Nome = "MARINHA",
                            Uf = "SP"
                        });
                });

            modelBuilder.Entity("DigitacaoProposta.Dominio.GravarProposta.Estado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Ddd")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("DDD");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NOME");

                    b.Property<bool>("RequerAssinaturaHibrida")
                        .HasColumnType("bit")
                        .HasColumnName("REQUERASSINATURAHIBRIDA");

                    b.Property<decimal>("RestricaoDeValor")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("RESTRICAODEVALOR");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nchar(2)")
                        .HasColumnName("UF")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("ESTADOS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("5553a8ba-7d98-438c-bf98-4509ef568ade"),
                            Ddd = "51",
                            Nome = "Rio Grande do Sul",
                            RequerAssinaturaHibrida = true,
                            RestricaoDeValor = 50000.00m,
                            Uf = "RS"
                        },
                        new
                        {
                            Id = new Guid("85d9a02b-df22-4e24-a29c-3e4df8f43cf1"),
                            Ddd = "11",
                            Nome = "São Paulo",
                            RequerAssinaturaHibrida = false,
                            RestricaoDeValor = 100000.00m,
                            Uf = "SP"
                        },
                        new
                        {
                            Id = new Guid("00800786-8a8f-434a-a0cd-2674ba9c91bb"),
                            Ddd = "31",
                            Nome = "Minas Gerais",
                            RequerAssinaturaHibrida = false,
                            RestricaoDeValor = 75000.00m,
                            Uf = "MG"
                        },
                        new
                        {
                            Id = new Guid("9ec008ec-4f45-4b44-98f9-e3a8dd9fb577"),
                            Ddd = "21",
                            Nome = "Rio de Janeiro",
                            RequerAssinaturaHibrida = true,
                            RestricaoDeValor = 85000.00m,
                            Uf = "RJ"
                        });
                });

            modelBuilder.Entity("DigitacaoProposta.Dominio.GravarProposta.Proposta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<Guid>("AgenteId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AGENTEID");

                    b.Property<Guid>("ConveniadaId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CONVENIADAID");

                    b.Property<string>("CpfCliente")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("CPFCLIENTE");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATACRIACAO");

                    b.Property<DateTime>("DataPrimeiraParcela")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATAPRIMEIRAPARCELA");

                    b.Property<DateTime>("DataUltimaParcela")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATAULTIMAPARCELA");

                    b.Property<int>("NumeroParcelas")
                        .HasColumnType("int")
                        .HasColumnName("NUMEROPARCELAS");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("STATUS");

                    b.Property<string>("TipoAssinatura")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("TIPOASSINATURA");

                    b.Property<string>("TipoOperacao")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("TIPOOPERACAO");

                    b.Property<decimal>("ValorEmprestimo")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("VALOREMPRESTIMO");

                    b.Property<decimal>("ValorParcela")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("VALORPARCELA");

                    b.HasKey("Id");

                    b.HasIndex("AgenteId");

                    b.HasIndex("ConveniadaId");

                    b.ToTable("PROPOSTAS", (string)null);
                });

            modelBuilder.Entity("DigitacaoProposta.Dominio.GravarProposta.Proposta", b =>
                {
                    b.HasOne("DigitacaoProposta.Dominio.GravarProposta.Agente", null)
                        .WithMany()
                        .HasForeignKey("AgenteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DigitacaoProposta.Dominio.GravarProposta.Conveniada", null)
                        .WithMany()
                        .HasForeignKey("ConveniadaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}