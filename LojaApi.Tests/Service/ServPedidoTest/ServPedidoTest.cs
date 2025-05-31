using LojaApi.Domain;
using LojaApi.Domain.DTO;
using Moq;

namespace LojaApi.Tests.Service.ServPedidoTest
{
    public class ServPedidoTest
    {
        private readonly Mock<IServCaixa> _mockServCaixa;
        private readonly ServPedido _servPedido;

        public ServPedidoTest()
        {
            _mockServCaixa = new Mock<IServCaixa>();
            //_servPedido = new ServPedido(_mockServCaixa.Object);
        }

        [Fact]
        public void EmpacotarPedido_QuandoListaPedidosVazia_DeveRetornarMensagem()
        {
            // Arrange

            var caixa = new Caixa
            {
                Dimensoes = new Dimensoes(1, 2, 3),
                Descricao = "Caixa Pequena"
            };

            _mockServCaixa.Setup(x => x.TrazCaixaDisponivel()).Returns(new List<Caixa> { caixa });
            var pedidos = new EmpacotarVariosPedidoDTO();

            // Act
            var result = _servPedido.EmpacotarVariosPedido(pedidos);

            // Assert
            Assert.Equal("Pedido sem produtos.", result.Mensagem);
        }

        [Fact]
        public void EmpacotarPedido_QuandoListaPedidosNull_DeveRetornarMensagem()
        {
            // Arrange

            var caixa = new Caixa
            {
                Dimensoes = new Dimensoes(1, 2, 3),
                Descricao = "Caixa Pequena"
            };

            _mockServCaixa.Setup(x => x.TrazCaixaDisponivel()).Returns(new List<Caixa> { caixa });
            EmpacotarVariosPedidoDTO pedidos = null;

            // Act
            var result = _servPedido.EmpacotarVariosPedido(pedidos);

            // Assert
            Assert.Equal("Pedido sem produtos.", result.Mensagem);
        }

        [Fact]
        public void EmpacotarPedido_QuandoProdutoNaoCaberNaCaixa_DeveRetornarMensagem()
        {
            // Arrange

            var produtos = new List<EmpacotarProdutoDTO>
            {
                new EmpacotarProdutoDTO { Descricao = "Cadeira Gamer Mancer" , Dimensoes = new Dimensoes(100, 20, 30) },
                new EmpacotarProdutoDTO { Descricao = "Cadeira Gamer Pichau" , Dimensoes = new Dimensoes(1, 2, 3) }
            };

            var caixa = new Caixa
            {
                Dimensoes = new Dimensoes(1, 2, 3),
                Descricao = "Caixa Pequena"
            };

            var listaCaixa = new List<Caixa> { caixa };

            // Act
            var result = _servPedido.Empacotar(listaCaixa, produtos);

            var resultado = result.Where(p => p == null).FirstOrDefault();

            // Assert
            Assert.Equal("Produto não cabe em nenhuma caixa disponível.", resultado.Observacao);
        }


        [Fact]
        public void EmpacotarPedido_QuandoCaixasDisponiveisVazias_DeveRetornarMensagem()
        {
            // Arrange
            var pedidos = new EmpacotarVariosPedidoDTO
            {
               ListaPedidos  = new List<EmpacotarPedidoDTO>
                {
                    new EmpacotarPedidoDTO { CodigoPedido = 1, ListaProdutos = new List<EmpacotarProdutoDTO>() }
                }
            };

            _mockServCaixa.Setup(x => x.TrazCaixaDisponivel()).Returns(new List<Caixa>());

            // Act
            var result = _servPedido.EmpacotarVariosPedido(pedidos);

            // Assert
            Assert.Equal("Nenhuma caixa disponível para alocar os produtos.", result.Mensagem);
        }

        [Fact]
        public void EmpacosPedido_Pedido()
        {
            // 1. Produtos do pedido 1
            var PS5 = new EmpacotarProdutoDTO { Descricao = "PS5", Dimensoes = new Dimensoes(40, 10, 25) };
            var Volante = new EmpacotarProdutoDTO { Descricao = "Volante", Dimensoes = new Dimensoes(40, 30, 30) };

            // 2. Produtos do pedido 2
            var Joystick = new EmpacotarProdutoDTO { Descricao = "Joystick", Dimensoes = new Dimensoes(15, 20, 10) };
            var Fifa24 = new EmpacotarProdutoDTO { Descricao = "Fifa 24", Dimensoes = new Dimensoes(10, 30, 10) };
            var CallOfDuty = new EmpacotarProdutoDTO { Descricao = "Call of Duty", Dimensoes = new Dimensoes(30, 15, 10) };

            // 3. Produtos do pedido 3
            var Headset = new EmpacotarProdutoDTO { Descricao = "Headset", Dimensoes = new Dimensoes(25, 15, 20) };

            // 4. Produtos do pedido 4
            var MouseGamer = new EmpacotarProdutoDTO { Descricao = "Mouse Gamer", Dimensoes = new Dimensoes(5, 8, 12) };
            var TecladoMecanico = new EmpacotarProdutoDTO { Descricao = "Teclado Mecânico", Dimensoes = new Dimensoes(4, 45, 15) };

            // 5. Produtos do pedido 5
            var CadeiraGamer = new EmpacotarProdutoDTO { Descricao = "Cadeira Gamer", Dimensoes = new Dimensoes(120, 60, 70) };

            // 6. Produtos do pedido 6
            var Webcam = new EmpacotarProdutoDTO { Descricao = "Webcam", Dimensoes = new Dimensoes(7, 10, 5) };
            var Microfone = new EmpacotarProdutoDTO { Descricao = "Microfone", Dimensoes = new Dimensoes(25, 10, 10) };
            var Monitor = new EmpacotarProdutoDTO { Descricao = "Monitor", Dimensoes = new Dimensoes(50, 60, 20) };
            var Notebook = new EmpacotarProdutoDTO { Descricao = "Notebook", Dimensoes = new Dimensoes(2, 35, 25) };

            // 7. Produtos do pedido 7
            var JogoDeCabos = new EmpacotarProdutoDTO { Descricao = "Jogo de Cabos", Dimensoes = new Dimensoes(5, 15, 10) };

            // 8. Produtos do pedido 8
            var ControleXbox = new EmpacotarProdutoDTO { Descricao = "Controle Xbox", Dimensoes = new Dimensoes(10, 15, 10) };
            var Carregador = new EmpacotarProdutoDTO { Descricao = "Carregador", Dimensoes = new Dimensoes(3, 8, 8) };

            // 9. Produtos do pedido 9
            var Tablet = new EmpacotarProdutoDTO { Descricao = "Tablet", Dimensoes = new Dimensoes(1, 25, 17) };

            // 10. Produtos do pedido 10
            var HDExterno = new EmpacotarProdutoDTO { Descricao = "HD Externo", Dimensoes = new Dimensoes(2, 8, 12) };
            var Pendrive = new EmpacotarProdutoDTO { Descricao = "Pendrive", Dimensoes = new Dimensoes(1, 2, 5) };

            var pedidos = new EmpacotarVariosPedidoDTO
            {
                ListaPedidos = new List<EmpacotarPedidoDTO>
            {
                //new EmpacotarPedido { Pedido_Id = 1, Produto = new List<EmpacotarProdutoDTO> { PS5, Volante } },
                new EmpacotarPedidoDTO { CodigoPedido = 2, ListaProdutos  = new List<EmpacotarProdutoDTO> { Joystick, Fifa24, CallOfDuty } },
                //new EmpacotarPedido { Pedido_Id = 3, Produto = new List<EmpacotarProdutoDTO> { Headset } },
                //new EmpacotarPedido { Pedido_Id = 4, Produto = new List<EmpacotarProdutoDTO> { MouseGamer, TecladoMecanico } },
                //new EmpacotarPedido { Pedido_Id = 5, Produto = new List<EmpacotarProdutoDTO> { CadeiraGamer } },
                //new EmpacotarPedido { Pedido_Id = 6, Produto = new List<EmpacotarProdutoDTO> { Webcam, Microfone, Monitor, Notebook } },
                //new EmpacotarPedido { Pedido_Id = 7, Produto = new List<EmpacotarProdutoDTO> { JogoDeCabos } },
                //new EmpacotarPedido { Pedido_Id = 8, Produto = new List<EmpacotarProdutoDTO> { ControleXbox, Carregador } },
                //new EmpacotarPedido { Pedido_Id = 9, Produto = new List<EmpacotarProdutoDTO> { Tablet } },
                //new EmpacotarPedido { Pedido_Id = 10, Produto  = new List<EmpacotarProdutoDTO> { HDExterno, Pendrive } }
            }
            };


            _mockServCaixa.Setup(x => x.TrazCaixaDisponivel()).Returns(new List<Caixa>()
            {
                new Caixa { Descricao  = "1", Dimensoes = new Dimensoes(5,5,5) },
                new Caixa { Descricao  = "2", Dimensoes = new Dimensoes(5,5,5) },
                new Caixa { Descricao  = "3", Dimensoes = new Dimensoes(50,80,60) }
             });

            // Act
            var result = _servPedido.EmpacotarVariosPedido(pedidos);

            // Assert
            Assert.Equal("Nenhuma caixa disponível para alocar os produtos.", result.Mensagem);
        }

    }
}
