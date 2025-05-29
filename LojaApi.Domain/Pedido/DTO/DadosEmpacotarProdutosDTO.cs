namespace LojaApi.Domain.DTO
{
    public class DadosEmpacotarProdutosDTO
    {
        public DadosEmpacotarProdutosDTO()
        {
            PedidoEmpacotado = new List<PedidoEmpacotadosDTO>();
        }
        public List<PedidoEmpacotadosDTO> PedidoEmpacotado { get; set; }
    }

    public class PedidoEmpacotadosDTO
    {
        public PedidoEmpacotadosDTO()
        {
            caixaComProduto = new List<CaixaComProdutoDTO>();
        }
        public List<CaixaComProdutoDTO> caixaComProduto { get; set; }
    }

    public class CaixaComProdutoDTO
    {
        public string IdCaixa { get; set; }
        public List<string> IdProduto { get; set; }
    }
}
