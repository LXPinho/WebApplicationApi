namespace WebApplicationApi.Model
{
    public class DimensaoCaixaModel : IModel
    {
        public string Id { get; set; }
        public DimensaoModel Dimensao { get; set; }    
        public DimensaoCaixaModel(string id, DimensaoModel dimensao)
        {
            Id= id;
            Dimensao= dimensao;
        }
    }
}
