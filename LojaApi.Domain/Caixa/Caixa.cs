namespace LojaApi.Domain
{
    public class Caixa : Identificador
    {
        public string Descricao { get; set; }
        public Dimensoes Dimensoes { get; set; }
    }
}
