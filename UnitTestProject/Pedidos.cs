using Microsoft.AspNetCore.Http.HttpResults;
using WebApplicationApi.Model;
using WebApplicationApi.Repository;

namespace UnitTestProject
{
    public class UnitTest1
    {
        [Fact]
        public void CriarPedidoEntrada()
        {
            // Arrange
            Pedidos4EntradaModel pedidos4Entrada = new Pedidos4EntradaModel();

            // Action
            ListaReporitory.Pedidos4Entrada.Pedidos.Clear();
            new ListaReporitory().Adicionar(new PedidoEntradaModel(1, new List<ProdutoModel> { new ProdutoModel("PS5", new DimensaoModel(40, 10, 25)) }));

            // Assert
            Assert.NotNull(ListaReporitory.Pedidos4Entrada);
            Assert.NotNull(ListaReporitory.Pedidos4Entrada.Pedidos);
            Assert.NotEmpty(ListaReporitory.Pedidos4Entrada.Pedidos);
            Assert.True(ListaReporitory.Pedidos4Entrada.Pedidos.Count > 0);

            foreach(PedidoEntradaModel pedido in ListaReporitory.Pedidos4Entrada.Pedidos)
            {
                Assert.Equal(1, pedido.Pedido_id);
                Assert.True(pedido.Produtos.Count > 0);

                foreach (ProdutoModel produto in pedido.Produtos)
                {
                    Assert.Equal("PS5", produto.Produto_Id);
                    Assert.Equal(40, produto.Dimensoes.Altura);
                    Assert.Equal(10, produto.Dimensoes.Largura);
                    Assert.Equal(25, produto.Dimensoes.Comprimento);
                }
            }
        }
        [Fact]
        public void ImportarPedidoEntrada()
        {
            // Arrange

            // Action
            new ListaReporitory().Importar(@"..\..\..\..\WebApplicationApi\Repository\Entrada.json");

            // Assert
            Assert.NotNull(ListaReporitory.Pedidos4Entrada);
            Assert.NotNull(ListaReporitory.Pedidos4Entrada.Pedidos);
            Assert.NotEmpty(ListaReporitory.Pedidos4Entrada.Pedidos);

            foreach (PedidoEntradaModel pedido in ListaReporitory.Pedidos4Entrada.Pedidos)
            {
                Assert.True(pedido.Pedido_id > 0);
                Assert.True(pedido.Produtos.Count > 0);

                foreach (ProdutoModel produto in pedido.Produtos)
                {
                    Assert.NotEmpty( produto.Produto_Id);
                    Assert.True(produto.Dimensoes.Altura > 0);
                    Assert.True(produto.Dimensoes.Largura> 0);
                    Assert.True(produto.Dimensoes.Comprimento > 0);
                }
            }
        }
        [Fact]
        public void ListarPedidoSaida()
        {
            // Arrange

            // Action
            new ListaReporitory().Importar(@"..\..\..\..\WebApplicationApi\Repository\Entrada.json");
            new ListaReporitory().ListarSaida();

            // Assert
            Assert.NotNull(ListaReporitory.Pedidos4Saida);
            Assert.NotNull(ListaReporitory.Pedidos4Saida.Pedidos);
            Assert.NotEmpty(ListaReporitory.Pedidos4Saida.Pedidos);

            foreach(PedidoSaidaModel pedido in (ListaReporitory.Pedidos4Saida.Pedidos))
            {
                Assert.True(pedido.Pedido_id > 0);
                Assert.True(pedido.Caixas.Count > 0);

                foreach (CaixaModel caixas in pedido.Caixas)
                {
                    Assert.True( !string.IsNullOrEmpty(caixas.Caixa_id) || (string.IsNullOrEmpty(caixas.Caixa_id) && !string.IsNullOrEmpty(pedido.Observacao)));
                }
            }
        }
    }
}