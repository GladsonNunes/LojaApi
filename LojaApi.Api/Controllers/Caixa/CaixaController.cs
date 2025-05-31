using AutoMapper;
using LojaApi.Domain;
using LojaApi.Domain.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CaixaController : CoreController<CaixaDTO,Caixa>
    {
        public CaixaController(IServCore<Caixa> service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
