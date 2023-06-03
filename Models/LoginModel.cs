using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Data;

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
                DataTable dtUtil = SQLiteModel.ObterDadosUtilizadorLogin(login, pw);

                DataRow util = dtUtil.Rows[0];

                OnLoginEfetuado(new UtilizadorModel(Convert.ToInt32(util["id"]), (string)util["login"], (string)util["password"], Convert.ToInt32(util["id_aluno"])));
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
