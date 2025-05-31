using LojaApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaApi.Repository.ConfiguracaoEF
{
    public class PedidoProdutoConfig : IEntityTypeConfiguration<PedidoProduto>
    {
        public void Configure(EntityTypeBuilder<PedidoProduto> builder)
        {

            builder.ToTable("PEDIDO_PRODUTO");

            builder.HasKey(pp => new { pp.Id});


            builder.Property(p => p.Id)
               .HasColumnName("IDPEDIDOPRODUTO")
               .ValueGeneratedOnAdd(); // Auto-incremento

            builder.Property(p => p.CodigoProduto)
             .HasColumnName("IDPRODUTO");

            builder.Property(p => p.CodigoPedido)
             .HasColumnName("IDPEDIDO");

            builder.Property(p => p.Id)
             .HasColumnName("IDPEDIDOPRODUTO")
             .ValueGeneratedOnAdd();


            builder.HasOne(pi => pi.Pedido)
                        .WithMany(p => p.ListaProduto)
                        .HasForeignKey(pi => pi.CodigoPedido)
                        .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pi => pi.Produto)
                .WithMany(p => p.Itens)
                .HasForeignKey(pi => pi.CodigoProduto)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
