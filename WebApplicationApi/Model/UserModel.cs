namespace WebApplicationApi.Model
{
    public class UserModel : IModel
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
        public string Senha { get; set; }
        public UserModel() 
        {
            Id = 0;
            Nome = string.Empty;
            Senha = string.Empty;
        }
        public UserModel(int id, string nome, string senha)
        {
            Id = id;
            Nome = nome;
            Senha = senha;
        }
    }
}
