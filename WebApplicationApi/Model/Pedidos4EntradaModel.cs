namespace WebApplicationApi.Model
{
    public class Pedidos4EntradaModel : IModel
    {
        public List<PedidoEntradaModel> Pedidos { get; set; }
        public Pedidos4EntradaModel()
        {
            Pedidos = new List<PedidoEntradaModel>();
        }
        public Pedidos4EntradaModel(List<PedidoEntradaModel> pedidos)
        {
            Pedidos = pedidos;
        }
    }
}
