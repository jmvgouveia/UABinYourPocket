using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UABinYourPocket.ViewModels
{
    public class ProfileViewModel
    {
        public ObservableCollection<UnidadeCurricular> Unidadecurricular { get; set; }

        public ProfileViewModel()
        {
            Unidadecurricular = new ObservableCollection<UnidadeCurricular>()
            {


                new UnidadeCurricular { FileName = "Laboratório de Desenvolvimento de Software",
                                        ImageSource = "lds.jpeg",
                                        eFolioA="eFolio A: 3",
                                        eFolioB="eFolio B: 2,8",
                                        eFolioG="eFolio G: 9",
                                        Ano="2. Ano",
                                        Semestre="2. Semestre",
                                        Docente="Leonel Caseiro Morgado"},

                new UnidadeCurricular { FileName = "Introdução à Programação",
                                        ImageSource = "ip.png",
                                        eFolioA="eFolio A: 3,5",
                                        eFolioB="eFolio B: 3",
                                        eFolioG="eFolio G: 9",
                                        Ano="1. Ano",
                                        Semestre="1. Semestre",
                                        Docente="José Coelho"},

                
                new UnidadeCurricular { FileName = "Inteligência Artificial",
                                        ImageSource = "ia.jpeg",
                                        eFolioA="A: 26 Abril",
                                        eFolioB="B: 12 Maio",
                                        eFolioG="G: 12 Julho",
                                        Ano="2. Ano",
                                        Semestre="2. Semestre",
                                        Docente="José Coelho"},


            };
        }
    }

}
