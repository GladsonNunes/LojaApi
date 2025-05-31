using LojaApi.Domain.DTO;

namespace LojaApi.Domain
{
    public interface IServPedido : IServCore<Pedido>
    {
        ResponseModel<List<DadosEmpacotarPedidoDTO>> EmpacotarVariosPedido(EmpacotarVariosPedidoDTO dto);
    }
}
