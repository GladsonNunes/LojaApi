using LojaApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaApi.Repository.ConfiguracaoEF
{
    public class PedidoConfig : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("PEDIDO");

            // Configuração das propriedades simples
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                    .HasColumnName("IDPEDIDO")
                    .IsRequired()
                    .HasMaxLength(50);

            
        }
    }
}
