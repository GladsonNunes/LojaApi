using AutoMapper;
using LojaApi.Domain;
using LojaApi.Domain.DTO;
using LojaApi.Domain.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : CoreController<PedidoDTO,Pedido>
    {
        private readonly IAplicPedido _aplicPedido;  
        public PedidoController(IServCore<Pedido> service, IMapper mapper, IAplicPedido aplicPedido) : base(service, mapper)
        {
            _aplicPedido = aplicPedido;
        }

        [HttpPost("Empacotar")]
        public IActionResult EmpacotarVariosPedido([FromBody] EmpacotarVariosPedidoDTO dto)
        {
            try
            {
                var items = _aplicPedido.EmpacotarVariosPedido(dto);
                if(items.Sucesso)
                    return Ok(items.Dados);

                return BadRequest(items.Mensagem);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro inesperado.", details = ex.Message });
            }
        }

    }
}
