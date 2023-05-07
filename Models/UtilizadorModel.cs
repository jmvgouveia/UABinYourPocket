namespace TesteASP.Models
{
    public class UtilizadorModel : AlunoModel
    {
        public int? IDUtilizador { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

        public UtilizadorModel() : base() { }

        public UtilizadorModel(int id, string nome, DateOnly dataNascimento, string morada, 
                               string codPostal, int nif, int contacto, string pais, string email, 
                               int idUtilizador, string login, string password) : base(id, nome, dataNascimento, morada, codPostal, nif, contacto, pais, email)
        {
            this.IDUtilizador = idUtilizador;
            this.Login = login;
            this.Password = password;
        }
    }
}
