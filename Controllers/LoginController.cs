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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EfetuarLogin(string email, string pw)
        {
            if (model is null) return View(model);

            if (!model.EfetuarLogin(email, pw))
            {


                //TODO: Adicionar comentário de falha login
              
                TempData["AlertMessage"] = "Falha no Login!";
                return RedirectToAction("Login", "Login");
               //
            }
            else
            {
                TempData["User"] = email;
                UtilizadorModel utilizador = new UtilizadorModel();
                return RedirectToAction("UnidadesCurriculares", "UnidadesCurriculares");
            }
                
        }

        public void ExecutarVerificacaoLogin(object sender, UtilizadorModel utilizador)
        {
            
        }
    }
}
