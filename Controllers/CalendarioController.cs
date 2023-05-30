using Microsoft.AspNetCore.Mvc;

namespace TesteASP.Controllers
{
    public class CalendarioController : Controller
    {
        public IActionResult Calendario()
        {
            return View();
        }
    }
}
