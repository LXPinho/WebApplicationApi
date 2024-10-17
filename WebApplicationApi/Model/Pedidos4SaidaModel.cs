namespace WebApplicationApi.Model
{
    public class Pedidos4SaidaModel : IModel
    {
        public List<PedidoSaidaModel> Pedidos { get; set; }
        public Pedidos4SaidaModel()
        {
            Pedidos = new List<PedidoSaidaModel>();
        }
        public Pedidos4SaidaModel(List<PedidoSaidaModel> pedidos)
        {
            Pedidos = pedidos;
        }

    }
}
