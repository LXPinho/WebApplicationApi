namespace WebApplicationApi.Model
{
    public class ProdutoModel : IModel
    {
        public string Produto_Id { get; set; }
        public DimensaoModel Dimensoes { get; set; }
        public ProdutoModel(string produto_Id , DimensaoModel Dimensao) 
        {
            Produto_Id = produto_Id;
            this.Dimensoes = Dimensao;
        }
    }
}
