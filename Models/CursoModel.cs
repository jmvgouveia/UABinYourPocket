namespace TesteASP.Models
{
    public class CursoModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Area { get; set; }

        public CursoModel(int id, string nome, string area) 
        {
            this.ID = id;
            this.Nome = nome;
            this.Area = area;
        }
    }
}
