namespace TesteASP.Models
{
    public class UtilizadorModel
    {
        public int? IDUtilizador { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public int IDAluno { get; set; }

        public UtilizadorModel() { } //Controtor sem login efetuado
        public UtilizadorModel(int id, string login, string pw, int idAluno)
        {
            this.IDUtilizador = id;
            this.Login = login;
            this.Password = pw;
            this.IDAluno = idAluno;
        }

        public static bool VerificarUtilizadorExistente(string login, string pw)
        {
            return SQLiteModel.VerificarLogin(login, pw);
        }
    }
}
