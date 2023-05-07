namespace TesteASP.Models
{
    public class LoginModel
    {
        public delegate void Login(object sender, UtilizadorModel utilizador);
        public event Login? LoginEfetuado;

        public LoginModel()
        {

        }

        public void EfetuarLogin(string login, string password)
        {
            //se login se verificar
            //criar objecto Utilizador

            if (LoginEfetuado != null)
                LoginEfetuado(this, new UtilizadorModel());
        }
    }
}
