using LojaApi.Domain.DTO;
using LojaApi.Domain.Mapper;

namespace LojaApi.Domain
{
    public class ServPedido : ServCore<Pedido>, IServPedido
    {
        private readonly IServCaixa _servCaixa;
        public ServPedido(IRepCore<Pedido> rep, IServCaixa servCaixa) : base(rep)
        {
            _servCaixa = servCaixa;
        }
        public ResponseModel<List<DadosEmpacotarPedidoDTO>> EmpacotarVariosPedido(EmpacotarVariosPedidoDTO dto)
        {
            var dados = new List<DadosEmpacotarPedidoDTO>();

            if (dto.ListaPedidos?.Any() != true)
                return ResponseModel<List<DadosEmpacotarPedidoDTO>>.Falha("Pedido sem produtos.");

            var listaCaixaDisponivel = _servCaixa.TrazCaixaDisponivel();

            if (listaCaixaDisponivel?.Any() != true)
                return ResponseModel<List<DadosEmpacotarPedidoDTO>>.Falha("Nenhuma caixa disponível para alocar os produtos.");

            foreach (var pedido in dto.ListaPedidos)
            {
                
                var listacaixaComProduto = Empacotar(listaCaixaDisponivel, pedido.ListaProdutos);
                if (listacaixaComProduto != null)
                {
                    dados.Add(new DadosEmpacotarPedidoDTO
                    {
                        CodigoPedido = pedido.CodigoPedido,
                        ListaCaixa = listacaixaComProduto,
                    });
                }

            }

            return ResponseModel<List<DadosEmpacotarPedidoDTO>>.Ok(dados);
        }
        private void AdicionarNovoEspacoSeValido(List<Dimensoes> espacos, decimal altura, decimal largura, decimal comprimento)
        {
            if (altura >= 0 && largura >= 0 && comprimento >= 0)
            {
                espacos.Add(new Dimensoes(altura, largura, comprimento));
            }
        }
        private void AtualizarEspacosLivres(List<Dimensoes> espacosLivres, int indiceEspaco, Dimensoes rotacao)
        {
            var espaco = espacosLivres[indiceEspaco];
            espacosLivres.RemoveAt(indiceEspaco);

            AdicionarNovoEspacoSeValido(espacosLivres,
                espaco.Altura - rotacao.Altura,
                espaco.Largura - rotacao.Largura,
                espaco.Comprimento - rotacao.Comprimento);

        }
        private bool ProdutoCabeNoEspaco(Dimensoes rotacao, Dimensoes espaco)
        {
            return rotacao.Altura <= espaco.Altura &&
                   rotacao.Largura <= espaco.Largura &&
                   rotacao.Comprimento <= espaco.Comprimento;
        }
        private bool TentarColocarProduto(Produto produto, List<Dimensoes> espacosLivres)
        {
            if (produto.Dimensoes.Volume > espacosLivres[0].Volume)
                return false;

            foreach (var rotacao in produto.Rotacoes)
            {
                for (int i = 0; i < espacosLivres.Count; i++)
                {
                    if (ProdutoCabeNoEspaco(rotacao, espacosLivres[i]))
                    {
                        AtualizarEspacosLivres(espacosLivres, i, rotacao);
                        return true;
                    }
                }
            }
            return false;
        }
        private DadosTentarEmpacotarDTO TentarEmpacotarNaCaixa(Caixa caixa, List<Produto> produtos)
        {
            var produtosNaCaixa = new List<Produto>();
            var espacosLivres = new List<Dimensoes> { caixa.Dimensoes };
            var produtosRestantes = new List<Produto>(produtos);

            produtosRestantes = produtosRestantes.OrderByDescending(p => p.Dimensoes.Volume).ToList();

            foreach (var produto in produtosRestantes.ToList())
            {
                if (TentarColocarProduto(produto, espacosLivres))
                {
                    produtosNaCaixa.Add(produto);
                    produtosRestantes.Remove(produto);
                }
            }

            return new DadosTentarEmpacotarDTO(produtosNaCaixa, produtosRestantes);
        }
        public List<CaixaComProdutoDTO> Empacotar(List<Caixa> caixasDisponiveis, List<EmpacotarProdutoDTO> Listaproduto)
        {
            var caixasOrdenadas = caixasDisponiveis
                .OrderByDescending(c => c.Dimensoes.Volume)
                .ToList();

            var produtosRestantes = new List<Produto>();
            foreach (var produto in Listaproduto)
            {
                produtosRestantes.Add(new Produto
                {
                    Dimensoes = produto.Dimensoes,
                    Id = produto.CodigoProduto,
                    Descricao = produto.Descricao
                });
            }

            var resultado = new List<CaixaComProdutoDTO>();

            foreach (var caixa in caixasOrdenadas)
            {
                if (!produtosRestantes.Any()) break;

                var empacotamento = TentarEmpacotarNaCaixa(caixa, produtosRestantes);
                if (empacotamento.ProdutosEmpacotados.Any())
                {
                    resultado.Add(new CaixaComProdutoDTO
                    {
                        DescricaoCaixa = caixa.Descricao,
                        DescricaoProduto = empacotamento.ProdutosEmpacotados.Select(p => p.Descricao).ToList(),
                    });

                    produtosRestantes = empacotamento.ProdutosRestantes;
                }

            }

            if (produtosRestantes.Count > 0)
            {
                resultado.Add(new CaixaComProdutoDTO
                {
                    DescricaoProduto = produtosRestantes.Select(x => x.Descricao).ToList(),
                    Observacao = EnumObservacao.ProdutoNaoCabeEmNenhumaCaixa.GetDescription(),
                });
            }

            return resultado;
        }
    }
}
