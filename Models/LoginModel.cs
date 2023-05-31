using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace TesteASP.Models
{
    public class LoginModel
    {
        public delegate void Login(object sender, UtilizadorModel utilizador);
        public event Login? LoginEfetuado;

        public string email { get; set; }
        public string pw { get; set; }

        public LoginModel()
        {
            this.email = "";
            this.pw = "";
        }

        public bool EfetuarLogin(string email, string pw)
        {
            return SQLiteModel.VerificarLogin(email, pw);

            //se login se verificar


            //criar objecto Utilizador
            

            //if (LoginEfetuado != null)
                //LoginEfetuado(this, new UtilizadorModel());
        }
    }
}
