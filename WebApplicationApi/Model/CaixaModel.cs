namespace WebApplicationApi.Model
{
    public class CaixaModel
    {
        public string ?Caixa_id { get; set; }
        public List<string> Produtos { get; set; }  
        public CaixaModel() 
        {
            Caixa_id = null;
            Produtos = new List<string>();
        }
        public CaixaModel(string caixa_Id, List<string> produtos )
        {
            Caixa_id = caixa_Id;
            Produtos = produtos;
        }
    }
}
