namespace LojaApi.Domain
{
    public class PedidoProduto : Identificador
    {
        public int CodigoPedido { get; set; }
        public Pedido Pedido { get; set; }

        public int CodigoProduto { get; set; }
        public Produto Produto { get; set; }
    }
}
