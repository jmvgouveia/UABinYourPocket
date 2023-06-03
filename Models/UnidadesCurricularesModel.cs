using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Data;


namespace TesteASP.Models
{
    public class UnidadesCurricularesModel
    {
        public ObservableCollection<UCModel> colecaoUcs = new ObservableCollection<UCModel>();

        public UnidadesCurricularesModel()
        {
            this.colecaoUcs = new ObservableCollection<UCModel>();
            //obter UCs
            DataTable dtAux = SQLiteModel.ObterUCs();

            foreach (DataRow row in dtAux.Rows)
            {
                colecaoUcs.Add(new UCModel(Convert.ToInt32(row["id"]), (string)row["nome"], (string)row["sigla"],
                                           Convert.ToInt16(row["escts"]), Convert.ToInt16(row["ano"]), Convert.ToInt16(row["semestre"]),
                                           (DateTime)row["efolio_a"], (DateTime)row["efolio_b"], (DateTime)row["efolio_global"]));
            }

            var teste = 0; //break para testar como se encontra a coleção

            
        }

       
    }
}
