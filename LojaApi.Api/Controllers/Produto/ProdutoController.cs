using AutoMapper;
using LojaApi.Domain;
using LojaApi.Domain.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : CoreController<ProdutoDTO, Produto>
    {
        public ProdutoController(IServCore<Produto> service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
