namespace LojaApi.Domain
{
    public class Pedido : Identificador
    {
        public ICollection<PedidoProduto> ListaProduto { get; set; } = new List<PedidoProduto>();
    }
}
