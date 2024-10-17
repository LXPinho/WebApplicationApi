namespace WebApplicationApi.Model
{
    public class PedidoEntradaModel : IModel
    {
        public int Pedido_id { get; set; }
        public List<ProdutoModel> Produtos { get; set; }
        public PedidoEntradaModel()
        {
            Produtos=new List<ProdutoModel>();
        }
        public PedidoEntradaModel(int pedido_id, List<ProdutoModel> listaProduto)
        {
            Pedido_id = pedido_id;
            Produtos = listaProduto ;
        }
    }
}
