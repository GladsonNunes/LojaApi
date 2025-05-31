namespace LojaApi.Domain
{
    public interface IServCaixa : IServCore<Caixa>
    {
        public List<Caixa> TrazCaixaDisponivel();
    }
}
