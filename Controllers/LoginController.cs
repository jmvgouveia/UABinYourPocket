using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TesteASP.Models;

namespace TesteASP.Controllers
{
    public class LoginController : Controller
    {
        private LoginModel? model;

        public LoginController()
        {
            model = new LoginModel();
            //view = new LoginView();

            if (model != null)
                model.LoginEfetuado += ExecutarVerificacaoLogin;
        }

        public void ExecutarVerificacaoLogin(object sender, UtilizadorModel utilizador)
        {
            
        }
    }
}
