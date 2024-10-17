using Newtonsoft.Json;
using System.Text.Json.Serialization;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace WebApplicationApi.Model
{
    public class PedidoSaidaModel : IModel
    {
        public int Pedido_id { get; set; }
        public List<CaixaModel> Caixas { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ?Observacao { get; set; }
        public PedidoSaidaModel()
        {
            Pedido_id = 0;
            Caixas = new List<CaixaModel>();
            Observacao = null;
        }
        public PedidoSaidaModel(int pedido_id, List<CaixaModel> caixa, List<ProdutoModel> produtos, string ?observacao)
        {
            Pedido_id = pedido_id;
            Caixas = caixa;
            Observacao = observacao;
        }
    }
}
