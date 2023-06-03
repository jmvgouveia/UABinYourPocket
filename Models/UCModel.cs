namespace TesteASP.Models
{
    public class UCModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public short ESCTS { get; set; }
        public short Ano { get; set; }
        public short Semestre { get; set; }
        public DateTime EFolioA { get; set; }
        public DateTime EFolioB { get; set; }
        public DateTime EFolioGlobal { get; set; }
        public bool Ativa { get; set; } 

        public UCModel(int id, string nome, string sigla, short escts, short ano, short semestre, DateTime efolioA, DateTime efolioB, DateTime efolioGlobal, bool ativa = true)
        {
            this.ID = id;
            this.Nome = nome;
            this.Sigla = sigla;
            this.ESCTS = escts;
            this.Ano = ano;
            this.Semestre = semestre;
            this.EFolioA = efolioA;
            this.EFolioB = efolioB;
            this.EFolioGlobal = efolioGlobal;
            this.Ativa = ativa;

        }


    }
}
