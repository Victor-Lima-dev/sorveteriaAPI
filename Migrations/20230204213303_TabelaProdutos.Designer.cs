﻿// <auto-generated />
using System;
using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace sorveteriaApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230204213303_TabelaProdutos")]
    partial class TabelaProdutos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Model.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoId"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepositoId")
                        .HasColumnType("int");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<string>("Sabor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProdutoId");

                    b.HasIndex("DepositoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("sorveteriaApi.Model.Deposito", b =>
                {
                    b.Property<int>("DepositoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepositoId"));

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("DepositoId");

                    b.ToTable("Deposito");
                });

            modelBuilder.Entity("Model.Produto", b =>
                {
                    b.HasOne("sorveteriaApi.Model.Deposito", null)
                        .WithMany("Produtos")
                        .HasForeignKey("DepositoId");
                });

            modelBuilder.Entity("sorveteriaApi.Model.Deposito", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}