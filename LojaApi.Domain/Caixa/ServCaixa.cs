namespace LojaApi.Domain
{
    public class ServCaixa : ServCore<Caixa>, IServCaixa
    {
        public ServCaixa(IRepCore<Caixa> rep) : base(rep)
        {
        }

        public List<Caixa> TrazCaixaDisponivel()
        {
            return GetAll();
        }
    }
}
