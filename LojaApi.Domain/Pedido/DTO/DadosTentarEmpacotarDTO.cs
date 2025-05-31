namespace LojaApi.Domain.DTO
{
    public class DadosTentarEmpacotarDTO
    {
        public DadosTentarEmpacotarDTO(List<Produto> empacotados, List<Produto> restantes)
        {
            ProdutosEmpacotados = empacotados;
            ProdutosRestantes = restantes;
        }
        public List<Produto> ProdutosEmpacotados { get; }
        public List<Produto> ProdutosRestantes { get; }

        
    }


}
