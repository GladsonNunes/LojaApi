using LojaApi.Domain;
using LojaApi.Domain.DTO;

namespace LojaApi.Application
{
    
    public class AplicPedido : IAplicPedido
    {
        private readonly IServPedido _servPedido;
        public AplicPedido(IServPedido servPedido)
        {
            _servPedido = servPedido;
        }

        public ResponseModel<List<DadosEmpacotarPedidoDTO>> EmpacotarVariosPedido(EmpacotarVariosPedidoDTO dto)
        {
           return _servPedido.EmpacotarVariosPedido(dto);
        }
    }
}
