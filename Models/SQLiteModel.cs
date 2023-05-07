using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace TesteASP.Models
{
    public class SQLiteModel
    {
        private static string ConnectionString = "Data Source=database.db; Version = 3; New = True; Compress = True; ";
        //static SQLiteConnection Ligacao { get; set; }

        /*static SQLiteModel()
        {
            Ligacao = new SQLiteConnection(ConnectionString);

            try
            {
                Ligacao.Open();
            }
            catch (Exception) { }
        }*/

        /// <summary>
        /// Iniciar tabelas
        /// </summary>
        public static void IniciarTabelas()
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Open();

            //tabela alunos
            string sqlTabAlunos = "CREATE TABLE IF NOT EXISTS alunos (id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                                     "nome VARCHAR(100) NOT NULL, " +
                                                                     "data_nascimento DATE NOT NULL, " +
                                                                     "morada VARCHAR(100) NOT NULL, " +
                                                                     "codigo_postal VARCHAR(50) NOT NULL, " +
                                                                     "nif INT NOT NULL, " +
                                                                     "contacto INT NOT NULL, " +
                                                                     "pais VARCHAR(100) NOT NULL, " +
                                                                     "email VARCHAR(100) NOT NULL, " +
                                                                     "UNIQUE(nif));";
            CriarTabela(connection, sqlTabAlunos);

            //tabela utilizadores
            string sqlTabUti = "CREATE TABLE IF NOT EXISTS utilizadores (id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                                        "login VARCHAR(100) NOT NULL, " +
                                                                        "password VARCHAR(100) NOT NULL, " +
                                                                        "id_aluno INT NOT NULL, " +
                                                                        "CONSTRAINT fk_utilizador_aluno FOREIGN KEY (id_aluno) " +
                                                                        "REFERENCES alunos (id) ON DELETE CASCADE ON UPDATE NO ACTION, " +
                                                                        "UNIQUE(login));";

            CriarTabela(connection, sqlTabUti);

            //tabela cursos
            string sqlTabCursos = "CREATE TABLE IF NOT EXISTS cursos (id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                                     "nome VARCHAR(100) NOT NULL, " +
                                                                     "area VARCHAR(100) NOT NULL," +
                                                                     "UNIQUE(nome));";
            CriarTabela(connection, sqlTabCursos);

            //tabela cursos
            string sqlTabUC = "CREATE TABLE IF NOT EXISTS ucs (id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                              "nome VARCHAR(100) NOT NULL, " +
                                                              "sigla VARCHAR(15) NOT NULL, " +
                                                              "escts TINYINT NOT NULL, " +
                                                              "ano TINYINT NOT NULL," +
                                                              "semestre TINYINT NOT NULL, " +
                                                              "efolio_a DATETIME NOT NULL, " +
                                                              "efolio_b DATETIME NOT NULL, " +
                                                              "efolio_global DATETIME NOT NULL," +
                                                              "UNIQUE(nome));";
            CriarTabela(connection, sqlTabUC);

            connection.Close();
        }

        /// <summary>
        /// Executar comando para criar tabela
        /// </summary>
        /// <param name="connection">SQLite connection</param>
        /// <param name="createString">Create string</param>
        static void CriarTabela(SQLiteConnection connection, string createString)
        {
            SQLiteCommand cmd;

            cmd = connection.CreateCommand();
            cmd.CommandText = createString;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Inserir dados numa tabela
        /// </summary>
        /// <param name="connection">SQLite connection</param>
        /// <param name="insertString">Insert string</param>
        static void InserirDados(SQLiteConnection connection, string insertString)
        {
            SQLiteCommand cmd;

            cmd = connection.CreateCommand();
            cmd.CommandText = insertString;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Ler dados de uma tabela
        /// </summary>
        /// <param name="connection">SQLite connection</param>
        /// <param name="readString">Read string</param>
        /// <returns></returns>
        static DataTable LerDados(SQLiteConnection connection, string readString)
        {
            DataTable dt = new DataTable();

            using (SQLiteDataAdapter comm = new SQLiteDataAdapter(readString, connection))
            {
                comm.Fill(dt);
            }

            return dt;
        }


        #region Métodos & Funções da Tabela Utilizadores

        /// <summary>
        /// Adicionar Novo Utilizador
        /// </summary>
        /// <param name="login">Login</param>
        /// <param name="password">Password</param>
        /// <param name="idAluno">ID do Aluno</param>
        public static void AdicionarNovoUtilizador(string login, string password, int idAluno)
        {
            string insertString = $"INSERT INTO utilizadores (nome, password, id_aluno) VALUES('{login}', '{password}', {idAluno});";

            using var connection = new SQLiteConnection(ConnectionString);

            connection.Open();

            InserirDados(connection, insertString);

            connection.Close();
        }

        /// <summary>
        /// Obter dados de utilizador através do ID de Aluno
        /// </summary>
        /// <param name="idAluno">ID do Aluno</param>
        /// <returns>Dados de Utilizador de um determinado aluno</returns>
        public static DataTable ObterDadosUtilizador(int idAluno)
        {
            string readString = $"SELECT * FROM utilizadores WHERE id_aluno = {idAluno}";

            using var connection = new SQLiteConnection(ConnectionString);

            connection.Open();

            DataTable dtAux = LerDados(connection, readString);

            connection.Close();

            return dtAux;
        }
        #endregion

        #region Métodos & Funções da Tabela Alunos
        public static void AdicionarNovoAluno(string nome, DateOnly data_nascimento,
                                       string morada, string codPostal,
                                       int nif, int contacto, string pais, string email)
        {
            string insertString = "INSERT OR IGNORE INTO alunos (nome, data_nascimento, morada, codigo_postal, nif, contacto, pais, email) " +
                                        $"VALUES('{nome}', '{data_nascimento:yyyy-MM-dd}', '{morada}', '{codPostal}', {nif}, {contacto}, '{pais}', '{email}');";

            using var connection = new SQLiteConnection(ConnectionString);

            connection.Open();

            InserirDados(connection, insertString);

            connection.Close();
        }

        public static DataTable ObterDadosAluno(int idAluno)
        {
            string readString = $"SELECT * FROM alunos WHERE id = {idAluno}";

            using var connection = new SQLiteConnection(ConnectionString);

            connection.Open();

            DataTable dtAux = LerDados(connection, readString);

            connection.Close();

            return dtAux;
        }
        #endregion

    }
}
