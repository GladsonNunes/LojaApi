namespace LojaApi.Domain
{
    public class Produto : Identificador
    {
        //public int Id { get; set; }
        public string Descricao { get; set; }
        public Dimensoes Dimensoes { get; set; }
        public List<Dimensoes> Rotacoes => ObterRotacoes();

        public ICollection<PedidoProduto> Itens { get; set; } = new List<PedidoProduto>();

        private List<Dimensoes> ObterRotacoes()
        {
            return new List<Dimensoes>
        {
            new() { Altura = Dimensoes.Altura, Largura = Dimensoes.Largura, Comprimento = Dimensoes.Comprimento },
            new() { Altura = Dimensoes.Altura, Largura = Dimensoes.Comprimento, Comprimento = Dimensoes.Largura },
            new() { Altura = Dimensoes.Largura, Largura = Dimensoes.Altura, Comprimento = Dimensoes.Comprimento },
            new() { Altura = Dimensoes.Largura, Largura = Dimensoes.Comprimento, Comprimento = Dimensoes.Altura },
            new() { Altura = Dimensoes.Comprimento, Largura = Dimensoes.Altura, Comprimento = Dimensoes.Largura },
            new() { Altura = Dimensoes.Comprimento, Largura = Dimensoes.Largura, Comprimento = Dimensoes.Altura },
        };

        }

    }
}



