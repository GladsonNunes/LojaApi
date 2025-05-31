using LojaApi.Domain;

namespace LojaApi.Repository
{
    public class RepPedido : RepCore<Pedido>, IRepPedido
    {
        public RepPedido(AppDbContext context) : base(context)
        {
        }
    }
}
