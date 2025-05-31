using LojaApi.Domain;
using LojaApi.Repository.ConfiguracaoEF;
using Microsoft.EntityFrameworkCore;

namespace LojaApi.Repository
{
    public class AppDbContext : DbContext
    {
        // Construtor que recebe as opções de configuração
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public AppDbContext()
        {
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoProduto> PedidoProdutos { get; set; }
        public DbSet<Caixa> Caixa { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoConfig());
            modelBuilder.ApplyConfiguration(new CaixaConfig());
            modelBuilder.ApplyConfiguration(new PedidoConfig());
            modelBuilder.ApplyConfiguration(new PedidoProdutoConfig());
        }
    }
}
