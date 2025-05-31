using LojaApi.Domain.DTO;

namespace LojaApi.Domain
{
    public interface IAplicPedido
    {
        ResponseModel<List<DadosEmpacotarPedidoDTO>> EmpacotarVariosPedido(EmpacotarVariosPedidoDTO dto);
    }
}
