namespace LojaApi.Domain
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public List<Produto> Produto { get; set; }
    }
}
