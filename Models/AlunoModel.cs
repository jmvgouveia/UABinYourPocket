using System.Globalization;

namespace TesteASP.Models
{
    public class AlunoModel
    {
        public int? ID { get; set; }
        public string? Nome { get; set; }
        public DateOnly? DataNascimento { get; set; }
        public string? Morada { get; set; }
        public string? CodigoPostal { get; set; }
        public int? NIF { get; set; }
        public int? Contacto { get; set; }
        public string? Pais { get; set; }
        public string? Email { get; set; }

        public AlunoModel() { } 

        public AlunoModel(int id, string nome, DateOnly dataNascimento, string morada, string codigoPostal, int nif, int contacto, string pais, string email) 
        {
            this.ID = id;
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.Morada = morada;
            this.CodigoPostal = codigoPostal;
            this.NIF = nif;
            this.Contacto = contacto;
            this.Pais = pais;
            this.Email = email;
        }
    }
}
