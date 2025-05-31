namespace LojaApi.Domain.DTO
{
    public class DadosEmpacotarPedidoDTO
    {
        public int CodigoPedido { get; set; }
        public List<CaixaComProdutoDTO> ListaCaixa { get; set; }
    }
}
