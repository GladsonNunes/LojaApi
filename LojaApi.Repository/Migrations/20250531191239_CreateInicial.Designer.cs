﻿// <auto-generated />
using LojaApi.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LojaApi.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250531191239_CreateInicial")]
    partial class CreateInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LojaApi.Domain.Caixa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDCAIXA");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("DESCRICAO");

                    b.HasKey("Id");

                    b.ToTable("CAIXA", (string)null);
                });

            modelBuilder.Entity("LojaApi.Domain.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("IDPEDIDO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("PEDIDO", (string)null);
                });

            modelBuilder.Entity("LojaApi.Domain.PedidoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDPEDIDOPRODUTO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CodigoPedido")
                        .HasColumnType("int")
                        .HasColumnName("IDPEDIDO");

                    b.Property<int>("CodigoProduto")
                        .HasColumnType("int")
                        .HasColumnName("IDPRODUTO");

                    b.HasKey("Id");

                    b.HasIndex("CodigoPedido");

                    b.HasIndex("CodigoProduto");

                    b.ToTable("PEDIDO_PRODUTO", (string)null);
                });

            modelBuilder.Entity("LojaApi.Domain.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDPRODUTO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("DESCRICAO");

                    b.HasKey("Id");

                    b.ToTable("PRODUTO", (string)null);
                });

            modelBuilder.Entity("LojaApi.Domain.Caixa", b =>
                {
                    b.OwnsOne("LojaApi.Domain.Dimensoes", "Dimensoes", b1 =>
                        {
                            b1.Property<int>("CaixaId")
                                .HasColumnType("int");

                            b1.Property<decimal>("Altura")
                                .HasColumnType("DECIMAL(10,2)")
                                .HasColumnName("ALTURA");

                            b1.Property<decimal>("Comprimento")
                                .HasColumnType("DECIMAL(10,2)")
                                .HasColumnName("COMPRIMENTO");

                            b1.Property<decimal>("Largura")
                                .HasColumnType("DECIMAL(10,2)")
                                .HasColumnName("LARGURA");

                            b1.HasKey("CaixaId");

                            b1.ToTable("CAIXA");

                            b1.WithOwner()
                                .HasForeignKey("CaixaId");
                        });

                    b.Navigation("Dimensoes")
                        .IsRequired();
                });

            modelBuilder.Entity("LojaApi.Domain.PedidoProduto", b =>
                {
                    b.HasOne("LojaApi.Domain.Pedido", "Pedido")
                        .WithMany("ListaProduto")
                        .HasForeignKey("CodigoPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LojaApi.Domain.Produto", "Produto")
                        .WithMany("Itens")
                        .HasForeignKey("CodigoProduto")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("LojaApi.Domain.Produto", b =>
                {
                    b.OwnsOne("LojaApi.Domain.Dimensoes", "Dimensoes", b1 =>
                        {
                            b1.Property<int>("ProdutoId")
                                .HasColumnType("int");

                            b1.Property<decimal>("Altura")
                                .HasColumnType("DECIMAL(10,2)")
                                .HasColumnName("ALTURA");

                            b1.Property<decimal>("Comprimento")
                                .HasColumnType("DECIMAL(10,2)")
                                .HasColumnName("COMPRIMENTO");

                            b1.Property<decimal>("Largura")
                                .HasColumnType("DECIMAL(10,2)")
                                .HasColumnName("LARGURA");

                            b1.HasKey("ProdutoId");

                            b1.ToTable("PRODUTO");

                            b1.WithOwner()
                                .HasForeignKey("ProdutoId");
                        });

                    b.Navigation("Dimensoes")
                        .IsRequired();
                });

            modelBuilder.Entity("LojaApi.Domain.Pedido", b =>
                {
                    b.Navigation("ListaProduto");
                });

            modelBuilder.Entity("LojaApi.Domain.Produto", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
