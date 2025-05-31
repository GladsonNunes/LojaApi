using LojaApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaApi.Repository.ConfiguracaoEF
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTO");

            // Configuração das propriedades simples
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("IDPRODUTO")
                .ValueGeneratedOnAdd(); // Auto-incremento

            builder.Property(p => p.Descricao)
                .HasColumnName("DESCRICAO")
                .IsRequired()
                .HasMaxLength(50);

            // Configuração do value object Dimensoes como owned entity
            builder.OwnsOne(p => p.Dimensoes, dimensoes =>
            {
                dimensoes.Property(d => d.Altura)
                    .HasColumnName("ALTURA")
                    .HasColumnType("DECIMAL(10,2)");

                dimensoes.Property(d => d.Largura)
                    .HasColumnName("LARGURA")
                    .HasColumnType("DECIMAL(10,2)");

                dimensoes.Property(d => d.Comprimento)
                    .HasColumnName("COMPRIMENTO")
                    .HasColumnType("DECIMAL(10,2)");


            });

            builder.Ignore(p => p.Rotacoes);

        }
    }
}
