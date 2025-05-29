namespace LojaApi.Domain.DTO
{
    public class DadosEmpacotarPedidoDTO
    {
        public int Pedido_id { get; set; }
        public List<CaixaComProdutoDTO> Caixas { get; set; }
    }
}
