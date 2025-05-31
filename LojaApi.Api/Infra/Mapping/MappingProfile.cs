using AutoMapper;
using LojaApi.Domain;
using LojaApi.Domain.Mapper;

namespace LojaApi.Api.Infra
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PedidoDTO, Pedido>();
            CreateMap<CaixaDTO, Caixa>();
            CreateMap<ProdutoDTO, Produto>();
            CreateMap<PedidoProdutoDTO, PedidoProduto>();

            // outros mapeamentos que você precisar
        }
    }
}
