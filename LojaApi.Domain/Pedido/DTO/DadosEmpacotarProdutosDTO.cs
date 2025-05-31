using System.ComponentModel;
using System.Reflection;

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
        public string DescricaoCaixa { get; set; }
        public List<string> DescricaoProduto { get; set; }
        public string Observacao { get; set; }
    }

    public enum EnumObservacao
    {
        [Description("Produto não cabe em nenhuma caixa disponível.")]
        ProdutoNaoCabeEmNenhumaCaixa,

        [Description("Não há caixa disponível")]
        NaoHaCaixaDisponivel
    }

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            var attribute = field.GetCustomAttribute<DescriptionAttribute>();

            return attribute?.Description ?? value.ToString();
        }
    }
}
