using LojaApi.Domain;

namespace LojaApi.Repository
{
    public class RepProduto : RepCore<Produto>
    {
        public RepProduto(AppDbContext context) : base(context)
        {
        }
    }
}
