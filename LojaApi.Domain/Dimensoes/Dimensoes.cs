namespace LojaApi.Domain
{
    public class Dimensoes
    {
        public Dimensoes()
        {
        }

        public Dimensoes(decimal altura, decimal largura, decimal comprimento)
        {
            Altura = altura;
            Largura = largura;
            Comprimento = comprimento;
        }

        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
        public decimal Comprimento { get; set; }
        public decimal Volume => Altura * Largura * Comprimento;
        
        
    }
}
