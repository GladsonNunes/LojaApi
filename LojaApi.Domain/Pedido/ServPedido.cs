using LojaApi.Domain.DTO;

namespace LojaApi.Domain
{
    public class ServPedido
    {
        private readonly IServCaixa _serCaixa;
        public ServPedido(IServCaixa servCaixa)
        {
            _serCaixa = servCaixa;      
        }

        public List<DadosEmpacotarPedidoDTO> EmpacotarPedido(List<Pedido> listapedidos)
        {
            var retorno = new List<DadosEmpacotarPedidoDTO>();

            var listaCaixaDisponivel = _serCaixa.TrazCaixaDisponivel();

            foreach (var item in listapedidos)
            {
                var caixaComProduto = Empacotar(listaCaixaDisponivel, item.Produto);
                if (caixaComProduto != null)
                {
                    retorno.Add(new DadosEmpacotarPedidoDTO
                    {
                        Pedido_id = item.IdPedido,
                        Caixas = caixaComProduto,
                    });
                }
                    
            }

            return retorno;
        }

        private List<CaixaComProdutoDTO> Empacotar(List<Caixa> caixasDisponiveis, List<Produto> produtosParaEmpacotar)
        {
            // Ordena as caixas do menor para o maior volume
            var caixasOrdenadas = caixasDisponiveis.OrderBy(c => c.Dimensoes.Volume).ToList();

            // Ordena os produtos do maior para o menor volume
            var produtosOrdenados = produtosParaEmpacotar.OrderByDescending(p => p.Dimensoes.Volume).ToList();

            var resultado = new List<CaixaComProdutoDTO>();
            var produtosRestantes = new List<Produto>(produtosOrdenados);

            foreach (var caixa in caixasOrdenadas)
            {
                if (!produtosRestantes.Any()) break;

                var produtosNaCaixa = new List<Produto>();
                var espacosLivres = new List<Dimensoes> { caixa.Dimensoes };

                foreach (var produto in produtosRestantes.ToList())
                {
                    bool produtoColocado = false;

                    // Tenta todas as rotações do produto
                    foreach (var rotacao in produto.Rotacoes)
                    {
                        for (int i = 0; i < espacosLivres.Count; i++)
                        {
                            var espaco = espacosLivres[i];

                            if (rotacao.Altura <= espaco.Altura &&
                                rotacao.Largura <= espaco.Largura &&
                                rotacao.Comprimento <= espaco.Comprimento)
                            {
                                // Adiciona o produto na caixa
                                produtosNaCaixa.Add(produto);
                                produtosRestantes.Remove(produto);

                                // Remove o espaço ocupado
                                espacosLivres.RemoveAt(i);

                                // Divide o espaço restante em 3 novos espaços
                                if (espaco.Altura - rotacao.Altura > 0)
                                {
                                    espacosLivres.Add(new Dimensoes(
                                        espaco.Altura - rotacao.Altura,
                                        espaco.Largura,
                                        espaco.Comprimento));
                                }

                                if (espaco.Largura - rotacao.Largura > 0)
                                {
                                    espacosLivres.Add(new Dimensoes(
                                        rotacao.Altura,
                                        espaco.Largura - rotacao.Largura,
                                        espaco.Comprimento));
                                }

                                if (espaco.Comprimento - rotacao.Comprimento > 0)
                                {
                                    espacosLivres.Add(new Dimensoes(
                                        rotacao.Altura,
                                        rotacao.Largura,
                                        espaco.Comprimento - rotacao.Comprimento));
                                }

                                produtoColocado = true;
                                break;
                            }
                        }
                        if (produtoColocado) break;
                    }
                }

                if (produtosNaCaixa.Any())
                {
                    resultado.Add(new CaixaComProdutoDTO
                    {
                        IdCaixa = caixa.IdCaixa,
                        IdProduto = produtosNaCaixa.Select(x => x.IdProduto).ToList()
                    });
                    //resultado.Add((caixa, produtosNaCaixa));
                }
            }

            return resultado;
        }


        public DadosEmpacotarProdutosDTO EmpacotarProdutos(EmpacotarProdutosDTO dto)
        {
            var retorno = new DadosEmpacotarProdutosDTO();

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

            var caixas = new List<Caixa> { caixa1, caixa2 };
            var caixasOrdenada = caixas.OrderBy(p => p.Dimensoes.Volume).ToList();

            foreach (var caixa in caixasOrdenada)
            {
                var cabem = ProdutosCabemNaCaixa(dto.listaProduto, caixa);
                if (cabem)
                {
                    List<CaixaComProdutoDTO> ListaComProduto = new List<CaixaComProdutoDTO>();
                    ListaComProduto.Add(new CaixaComProdutoDTO
                    {
                        IdCaixa = caixa.IdCaixa,
                        IdProduto = dto.listaProduto.Select(x => x.IdProduto).ToList()
                    });

                    retorno.PedidoEmpacotado.Add(new PedidoEmpacotadosDTO
                    {
                        caixaComProduto = ListaComProduto
                    });

                }
                else
                {

                }
            }

            return retorno;

        }

        public bool ProdutosCabemNaCaixa(List<Produto> produtos, Caixa caixa)
        {

            decimal volumeTotalProdutos = produtos.Sum(p => p.Dimensoes.Volume);
            if (volumeTotalProdutos > caixa.Dimensoes.Volume)
                return false;


            return TentarEmpacotar(caixa, produtos);
        }

        private static bool TentarEmpacotar(Caixa caixa, List<Produto> produtos)
        {
            // Ordena produtos do maior para o menor volume
            var produtosOrdenados = produtos.OrderByDescending(p => p.Dimensoes.Volume).ToList();

            // Cria um espaço inicial do tamanho da caixa
            var espacos = new List<Dimensoes> { caixa.Dimensoes };

            foreach (var produto in produtosOrdenados)
            {
                bool produtoColocado = false;

                // Tenta todas as rotações do produto
                foreach (var rotacao in produto.Rotacoes)
                {
                    // Procura um espaço onde o produto caiba
                    for (int i = 0; i < espacos.Count; i++)
                    {
                        if (rotacao.Altura <= espacos[i].Altura &&
                            rotacao.Largura <= espacos[i].Largura &&
                            rotacao.Comprimento <= espacos[i].Comprimento)
                        {
                            // Encontrou um espaço que cabe
                            var espaco = espacos[i];
                            espacos.RemoveAt(i);

                            // Divide o espaço restante em 3 novos espaços possíveis
                            if (espaco.Altura - rotacao.Altura > 0)
                            {
                                espacos.Add(new Dimensoes(
                                    espaco.Altura - rotacao.Altura,
                                    espaco.Largura,
                                    espaco.Comprimento));
                            }

                            if (espaco.Largura - rotacao.Largura > 0)
                            {
                                espacos.Add(new Dimensoes(
                                    rotacao.Altura,
                                    espaco.Largura - rotacao.Largura,
                                    espaco.Comprimento));
                            }

                            if (espaco.Comprimento - rotacao.Comprimento > 0)
                            {
                                espacos.Add(new Dimensoes(
                                    rotacao.Altura,
                                    rotacao.Largura,
                                    espaco.Comprimento - rotacao.Comprimento));
                            }

                            produtoColocado = true;
                            break;
                        }
                    }

                    if (produtoColocado) break;
                }

                if (!produtoColocado) return false;
            }

            return true;
        }
    }



    /* public List<ResultadoProdutoCaixa> VerificarMelhorCaixaParaProdutos(List<Produto> produtos)
     {
         return produtos.Select(produto => new ResultadoProdutoCaixa
         {
             ProdutoId = produto.idProduto,
             CaixaId = EncontrarMelhorCaixaComRotacao(produto)?.CaixaId
         }).ToList();
     }*/

    /* private Caixa? EncontrarMelhorCaixaComRotacao(Produto produto)
     {

         var listaCaixa = new List<Caixa>(); 
         return listaCaixa
             .Where(caixa =>
                 produto.Dimensoes.ObterRotacoes().Any(rot =>
                     rot.Altura <= caixa.Dimensoes.Altura &&
                     rot.Largura <= caixa.Dimensoes.Largura &&
                     rot.Comprimento <= caixa.Dimensoes.Comprimento
                 )
             )
             .OrderBy(caixa => caixa.Dimensoes.Volume)
             .FirstOrDefault();
     }*/

}
