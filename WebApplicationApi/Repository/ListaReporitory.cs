using Newtonsoft.Json;
using WebApplicationApi.Model;

namespace WebApplicationApi.Repository
{
    public class ListaReporitory : IListaRepository
    {
        static public Pedidos4EntradaModel Pedidos4Entrada { get; set; } = new Pedidos4EntradaModel();
        static public Pedidos4SaidaModel Pedidos4Saida { get; set; } = new Pedidos4SaidaModel();
        static public List<DimensaoCaixaModel> ListaDimensaoCaixa { get; set; } = new List<DimensaoCaixaModel>();
        public ListaReporitory()
        {
#if false
            if (Pedidos4Entrada.Pedidos.Count == 0)
            {
                Adicionar(new PedidoEntradaModel(1, new List<ProdutoModel> { new ProdutoModel("PS5"    , new DimensaoModel(40, 10, 25)) }));
                Adicionar(new PedidoEntradaModel(1, new List<ProdutoModel> { new ProdutoModel("Volante", new DimensaoModel(40, 30, 30)) }));
            }
#endif
            if (ListaDimensaoCaixa.Count == 0)
            {
                ListaDimensaoCaixa.Add(new DimensaoCaixaModel("Caixa 1", new DimensaoModel(30,40,80)));
                ListaDimensaoCaixa.Add(new DimensaoCaixaModel("Caixa 2", new DimensaoModel(80,50,40)));
                ListaDimensaoCaixa.Add(new DimensaoCaixaModel("Caixa 3", new DimensaoModel(50,80,60)));
            }
        }
        public string Adicionar(PedidoEntradaModel pedido)
        {
            bool result = false;

            PedidoEntradaModel? pedido4Entrada = Pedidos4Entrada.Pedidos.Find( f => f.Pedido_id ==  pedido.Pedido_id);

            if (pedido4Entrada == null)
                Pedidos4Entrada.Pedidos.Add(pedido);
                else
                    foreach (ProdutoModel item in pedido.Produtos)
                        pedido4Entrada.Produtos.Add(item);

            result = Pedidos4Entrada.Pedidos.Count > 0;

            return result ? "Sucesso" : "Falha";
        }

        public Pedidos4EntradaModel ListarEntrada(int id)
        {
            Pedidos4EntradaModel pedidos = Pedidos4Entrada;
            return pedidos;
        }
        public Pedidos4SaidaModel ListarSaida()
        {
            foreach(PedidoEntradaModel pedidos in Pedidos4Entrada.Pedidos)
            {
                int pedido_id = pedidos.Pedido_id;
                string ?caixa_id = null;
                List<string> listProduto_id = new List<string>();
                foreach (ProdutoModel produto in pedidos.Produtos)
                {
                    foreach (var dimensaoCaixa in from DimensaoCaixaModel dimensaoCaixa in ListaDimensaoCaixa.OrderBy(o => o.Dimensao.Altura * o.Dimensao.Largura * o.Dimensao.Comprimento)
                                                  where dimensaoCaixa.Dimensao.Largura >= produto.Dimensoes.Largura
                                                  where dimensaoCaixa.Dimensao.Altura >= produto.Dimensoes.Altura
                                                  where dimensaoCaixa.Dimensao.Comprimento >= produto.Dimensoes.Comprimento
                                                  select dimensaoCaixa)
                    {
                        caixa_id = dimensaoCaixa.Id;
                        break;
                    }

                    listProduto_id.Add(produto.Produto_Id);
                }
                CaixaModel caixaModel = new CaixaModel(caixa_id, listProduto_id);
                PedidoSaidaModel pedidoSaida = new PedidoSaidaModel(pedido_id, new List<CaixaModel> { caixaModel }, pedidos.Produtos, caixa_id == null ? "Produto não cabe em nenhuma caixa disponível." : null);
                Pedidos4Saida.Pedidos.Add(pedidoSaida);

            }
            return Pedidos4Saida;
        }
        public Pedidos4EntradaModel Importar(string ?path = null)
        {
            Pedidos4EntradaModel ?result = null;
            try
            {
                using (StreamReader streamReader = new StreamReader(path ?? @".\Repository\Entrada.json"))
                {
                    string json = streamReader.ReadToEnd();
                    Pedidos4EntradaModel? items = JsonConvert.DeserializeObject<Pedidos4EntradaModel>(json);
                    Pedidos4Entrada = items ?? Pedidos4Entrada;
                    result = Pedidos4Entrada;
                }
            }
            catch
            {
                result = null;
            }
            return result?? new Pedidos4EntradaModel();
        }

        public string Alterar(PedidoEntradaModel model)
        {
            throw new NotImplementedException();
        }

        public string Deletar(PedidoEntradaModel model)
        {
            throw new NotImplementedException();
        }
    }
}
