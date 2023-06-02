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
        public void EfetuarLogin(string email, string pw)
        {
            //if (model is null) return View(model);
            if (model is null) return;

            model.VerificarLogin(email, pw); 
        }

        public void LoginEfetuado(UtilizadorModel user)
        {
            UtilizadorModel utilizador = user;
            TempData["User"] = user.Login;
            RedirectToAction("UnidadesCurriculares", "UnidadesCurriculares");
        }

        public void LoginIncorreto()
        {
            TempData["AlertMessage"] = "Falha no Login!";
            RedirectToAction("Login", "Login");
        }
    }
}
