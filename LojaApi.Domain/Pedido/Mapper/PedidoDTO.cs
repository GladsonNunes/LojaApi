namespace LojaApi.Domain.Mapper
{
    public class PedidoDTO
    {
        public PedidoDTO()
        {
            ListaProduto = new List<PedidoProdutoDTO>();
        }
        public List<PedidoProdutoDTO> ListaProduto { get; set; }
       
    }

}
