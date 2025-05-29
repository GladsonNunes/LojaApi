using LojaApi.Domain;
using LojaApi.Domain.DTO;

namespace LojaApi.Tests.Service.ServPedidoTest
{
    public class ServPedidoTest
    {

        [Fact]
        public void Deve_Retornar_True_Se_Produtos_Cabem_Na_Caixa()
        {

        }

        [Fact]
        public void Deve_Retornar_True_Se_Produtos_Cabem_Na_Caixa()
        {
            var servPedido = new ServPedido();
            // Arrange
            var produto1 = new Produto
            {
                IdProduto = "PS5",
                Dimensoes = new Dimensoes { Altura = 40, Largura = 10, Comprimento = 25 }
            };
            var produto2 = new Produto
            {
                IdProduto = "Volante",
                Dimensoes = new Dimensoes { Altura = 40, Largura = 30, Comprimento = 30 }
            };

            var caixa1 = new Caixa
            {
                IdCaixa = "Caixa 1",
                Dimensoes = new Dimensoes { Altura = 80, Largura = 100, Comprimento = 40 }
            };

            var caixa2 = new Caixa
            {
                IdCaixa = "Caixa 2",
                Dimensoes = new Dimensoes { Altura = 80, Largura = 50, Comprimento = 40 }
            };

            var produtos = new List<Produto> { produto1, produto2 };

            var caixas = new List<Caixa> { caixa1, caixa2  };

            // Act
            //var resultado = servPedido.ProdutosCabemNaCaixa(produtos, caixas);

            // Assert
           // Assert.True(resultado);
        }

        [Fact]
        public void Deve_Retornar_False_Se_Produtos_Nao_Cabem()
        {
            var servPedido = new ServPedido();
            // Arrange
            var produto1 = new Produto
            {
                IdProduto = "Geladeira",
                Dimensoes = new Dimensoes { Altura = 10, Largura = 90, Comprimento = 10 }
            };

            var produto2 = new Produto
            {
                IdProduto = "Celular",
                Dimensoes = new Dimensoes { Altura = 10, Largura = 30, Comprimento = 10 }
            };

            var caixa2 = new Caixa
            {
                IdCaixa = "Caixa Media",
                Dimensoes = new Dimensoes { Altura = 100, Largura = 30, Comprimento = 50 }
            };

            var produto3 = new Produto
            {
                IdProduto = "Fogão",
                Dimensoes = new Dimensoes { Altura = 10, Largura = 10, Comprimento = 10 }
            };

            var caixa1 = new Caixa
            {
                IdCaixa = "Caixa Pequena",
                Dimensoes = new Dimensoes { Altura = 20, Largura = 10, Comprimento = 10 }
            };

            

            var produtos = new List<Produto> { produto1, produto2, produto3 };

            var caixa = new List<Caixa> { caixa1, caixa2 };

            // Act
            var resultado = servPedido.Empacotar(caixa, produtos);

            // Assert
            //Assert.False(resultado);
        }
    }
}
