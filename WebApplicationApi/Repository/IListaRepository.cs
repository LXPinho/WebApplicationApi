using WebApplicationApi.Model;

namespace WebApplicationApi.Repository
{
    public interface IListaRepository
    {
        Pedidos4EntradaModel ListarEntrada(int id);
        Pedidos4SaidaModel ListarSaida();
        string Adicionar(PedidoEntradaModel model);
        string Alterar(PedidoEntradaModel model);
        string Deletar(PedidoEntradaModel model);
    }
}
