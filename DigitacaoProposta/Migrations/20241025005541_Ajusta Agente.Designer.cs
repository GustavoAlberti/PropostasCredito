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
    [Migration("20241025005541_Ajusta Agente")]
    partial class AjustaAgente
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
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConveniadaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CpfAgente")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ConveniadaId");

                    b.ToTable("Agentes", (string)null);
                });

            modelBuilder.Entity("DigitacaoProposta.Dominio.GravarProposta.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("RendimentoMensal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("StatusCpf")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("Id");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("DigitacaoProposta.Dominio.GravarProposta.Conveniada", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AceitaRefinanciamento")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nchar(2)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("Conveniadas", (string)null);
                });

            modelBuilder.Entity("DigitacaoProposta.Dominio.GravarProposta.Estado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("RestricaoDeValor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nchar(2)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("Estados", (string)null);
                });

            modelBuilder.Entity("DigitacaoProposta.Dominio.GravarProposta.Proposta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AgenteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConveniadaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CpfCliente")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrimeiraParcela")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumeroParcelas")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("TipoOperacao")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<decimal>("ValorEmprestimo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorParcela")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AgenteId");

                    b.HasIndex("ConveniadaId");

                    b.ToTable("Propostas", (string)null);
                });

            modelBuilder.Entity("DigitacaoProposta.Dominio.GravarProposta.Agente", b =>
                {
                    b.HasOne("DigitacaoProposta.Dominio.GravarProposta.Conveniada", null)
                        .WithMany()
                        .HasForeignKey("ConveniadaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
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
