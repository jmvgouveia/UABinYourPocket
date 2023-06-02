using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Data;
using TesteASP.Models;

namespace TesteASP.Controllers
{
    public class UnidadesCurricularesController : Controller
    {
        private UnidadesCurricularesModel? model;

        private ObservableCollection<UCModel> colecaoUcs;

        public UnidadesCurricularesController()
        {
            this.model = new UnidadesCurricularesModel();
            this.colecaoUcs = new ObservableCollection<UCModel>();
            //obter UCs
            DataTable dtAux = SQLiteModel.ObterUCs();

            foreach (DataRow row in dtAux.Rows)
            {
                //colecaoUcs.Add(new UCModel((int)row["id"], (string)row["nome"], (string)row["sigla"], 
                //                           (int)row["escts"], (int)row["ano"], (int)row["semestre"], 
                //                           (DateTime)row["efolio_a"], (DateTime)row["efolio_b"], (DateTime)row["efolio_global"]));
            }

            var teste = 0; //break para testar como se encontra a coleção
        }


        public IActionResult UnidadesCurriculares()
        {
            return View();
        }
        public IActionResult Inscrever()
        {
            return View();
        }
        public IActionResult Editar()
        {
            return View();
        }

    }
}
