namespace WebApplicationApi.Model
{
    public class DimensaoModel : IModel
    {
        public int Altura { get; set; }
        public int Largura {  get; set; }
        public int Comprimento { get; set; }
        public DimensaoModel(int altura = 0, int largura = 0, int comprimento = 0)
        {
            Altura = altura;
            Largura = largura;
            Comprimento = comprimento; 
        }
    }
}
