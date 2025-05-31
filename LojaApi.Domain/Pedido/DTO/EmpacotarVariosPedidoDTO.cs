namespace LojaApi.Domain.DTO
{
    public class EmpacotarVariosPedidoDTO
    {
        public EmpacotarVariosPedidoDTO()
        {
            ListaPedidos = new List<EmpacotarPedidoDTO>();
        }
        public List<EmpacotarPedidoDTO> ListaPedidos { get; set; }
    }

    public class EmpacotarPedidoDTO
    {
        public EmpacotarPedidoDTO()
        {
            ListaProdutos = new List<EmpacotarProdutoDTO>();
        }
        public int CodigoPedido { get; set; }

        public List<EmpacotarProdutoDTO> ListaProdutos { get; set; }
    }

    public class EmpacotarProdutoDTO
    {
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; }
        public Dimensoes Dimensoes { get; set; }
    }

}
