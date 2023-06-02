using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace TesteASP.Models
{
    public class LoginModel
    {
        public delegate void LoginCheck(UtilizadorModel utilizador);
        public delegate void LoginUncheck();

        public event LoginCheck? LoginEfetuado;
        public event LoginUncheck? LoginIncorreto;

        public string login { get; set; }
        public string pw { get; set; }

        public LoginModel()
        {
            this.login = "";
            this.pw = "";
        }

        public void VerificarLogin(string login, string pw)
        {
            if (UtilizadorModel.VerificarUtilizadorExistente(login, pw))
            {
                //obter id de utilizador e id de aluno associado
                //TODO: acabar
                int id = 0;

                OnLoginEfetuado(new UtilizadorModel(id, login, pw, 0));
            }
            else
                OnLoginIncorreto();
        }

        protected virtual void OnLoginEfetuado(UtilizadorModel utilizador)
        {
            LoginEfetuado?.Invoke(utilizador);
        }

        protected virtual void OnLoginIncorreto()
        {
            LoginIncorreto?.Invoke();
        }
    }
}
