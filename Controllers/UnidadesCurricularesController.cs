using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Data;
using TesteASP.Models;

namespace TesteASP.Controllers
{
    public class UnidadesCurricularesController : Controller
    {
        private UnidadesCurricularesModel? model;

        public UnidadesCurricularesController()
        {
            this.model = new UnidadesCurricularesModel();
           
        }

        public IActionResult UnidadesCurriculares()
        {
            return View(model.colecaoUcs);
        }
        public IActionResult Inscrever()
        {
            return View();
        }
        public IActionResult Editar()
        {
            return View();
        }


        public IActionResult GerarPDF()
        {
            return PDFModel.GerarDocumentoUCs(model.colecaoUcs, UtilizadorLogin.utilizador == null ? "Sem Login" : SQLiteModel.ObterNomeUtilizador(UtilizadorLogin.utilizador.IDAluno));
        }
    }
}
