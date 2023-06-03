using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TesteASP.Models;
     
namespace TesteASP.Controllers
{
    public class LoginController : Controller
    {
        private LoginModel? model;

        private bool sucesso;

        public LoginController()
        {
            model = new LoginModel();
            //view = new LoginView();

            if (model != null)
            {
                model.LoginEfetuado += LoginEfetuado;
                model.LoginIncorreto += LoginIncorreto;
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EfetuarLogin(string login, string pw)
        {   
            if (model is null) return View() ;
         
            model.VerificarLogin(login, pw);

            if (sucesso)
                return RedirectToAction("UnidadesCurriculares", "UnidadesCurriculares");
            else { 
                TempData["AlertMessage"] = "Falha no Login!";
            return RedirectToAction("Login", "Login");
            }

        }
        
        public void LoginEfetuado(UtilizadorModel user)
        {
            UtilizadorLogin.utilizador = user;

            TempData["User"] = SQLiteModel.ObterNomeUtilizador(user.IDAluno);
            sucesso = true;

        }
        
        public void  LoginIncorreto()
        {
            TempData["AlertMessage"] = "Falha no Login!";
            sucesso = false;
        }
    }
}
