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

            string sqlTabAlunoUC = "CREATE TABLE IF NOT EXISTS aluno_uc (id_aluno INTEGER NOT NULL, " +
                                                                        "id_uc INTEGER NOT NULL," +
                                                                        "CONSTRAINT fk_aluno_uc_aluno FOREIGN KEY (id_aluno) " +
                                                                        "REFERENCES alunos (id) ON DELETE CASCADE ON UPDATE NO ACTION, " +
                                                                        "CONSTRAINT fk_aluno_uc_uc FOREIGN KEY (id_uc) " +
                                                                        "REFERENCES ucs (id) ON DELETE CASCADE ON UPDATE NO ACTION," +
                                                                        "PRIMARY KEY (id_aluno, id_uc))";
            CriarTabela(connection, sqlTabAlunoUC);


            //Adicionar alunos no início se não existirem
            AdicionarAlunosPorDefeito();
            //Adicioanr UCs no início se não existirem
            AdicionarUcsPorDefeito();

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
            string insertString = $"INSERT INTO utilizadores (login, password, id_aluno) VALUES('{login}', '{password}', {idAluno});";

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

        /// <summary>
        /// Verificar se login e password inseridos correspondem a um Utilizador existente
        /// </summary>
        /// <param name="login">Login a verificar</param>
        /// <param name="pw">Password a verificar</param>
        /// <returns>
        /// True: Existe
        /// False: Não existe
        /// </returns>
        public static bool VerificarLogin(string login, string pw)
        {
            string sql = $"SELECT " +
                            $"CASE " +
                                $"WHEN EXISTS(SELECT * " +
                                            $"FROM utilizadores AS u " +
                                            $"WHERE u.login = '{login}' AND u.password = '{pw}') " +
                                $"THEN 1 " +
                                $"ELSE 0 " +
                        $"END";
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Open();

            SQLiteCommand cmd;

            cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            bool resultado = Convert.ToBoolean(cmd.ExecuteScalar());
            
            connection.Close();

            return resultado;
        }
        #endregion

        #region Métodos & Funções da Tabela Alunos

        private static void AdicionarAlunosPorDefeito()
        {
            AdicionarNovoAluno("Bruno", new DateOnly(1993, 1, 21), "Lisboa", "1234-123", 123789456, 918765432, "Portugal", "teste@mail.com");
            AdicionarNovoAluno("Daniel", new DateOnly(1993, 1, 21), "Alcobaça", "2460-557", 123456789, 911111111, "Portugal", "teste@mail.com");
            AdicionarNovoAluno("Jorge", new DateOnly(1993, 1, 21), "Funchal", "4321-987", 987654321, 912345678, "Portugal", "teste@mail.com");
            AdicionarNovoAluno("Sara", new DateOnly(1993, 1, 21), "Leiria", "9874-123", 123789456, 918765432, "Portugal", "teste@mail.com");
        }

        /// <summary>
        /// Adicionar um novo aluno
        /// </summary>
        /// <param name="nome">Nome</param>
        /// <param name="data_nascimento">Data de nascimento</param>
        /// <param name="morada">Morada</param>
        /// <param name="codPostal">Código-Postal</param>
        /// <param name="nif">NIF</param>
        /// <param name="contacto">Contacto</param>
        /// <param name="pais">País</param>
        /// <param name="email">E-mail</param>
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

        #region Métodos & Funções da Tabela UCs

        private static void AdicionarUcsPorDefeito()
        {
            

            AdicionarNovaUC("Linguagens de Programação", "LP", 6, 2, 2, new DateTime(2023,4,17,23,59,0), 
                            new DateTime(2023,4,15,23,59,0), new DateTime(2023,6,16,10,0,0));

            AdicionarNovaUC("Introdução à Inteligência Artificial", "IIA", 6, 2, 2, new DateTime(2023,4,17,23,59,0),
                            new DateTime(2023,5,22,23,59,0), new DateTime(2023,6,12,15,0,0));

            AdicionarNovaUC("Laboratório de Desenvolvimento de Software", "LDS", 6, 2, 2, new DateTime(2023,4,17,23,59,0),
                            new DateTime(2023,5,22,23,59,0), new DateTime(2023,6,12,15,0,0));
        }

        public static void AdicionarNovaUC(string nome, string sigla, short escts, 
                                           short ano, short semestre, DateTime efolioA, 
                                           DateTime efolioB, DateTime efolioGlobal)
        {
            string insertString = "INSERT OR IGNORE INTO ucs (nome, sigla, escts, ano, semestre, efolio_a, efolio_b, efolio_global) " +
                                        $"VALUES('{nome}', '{sigla}', {escts}, {ano}, {semestre}, " +
                                               $"'{efolioA:yyyy-MM-dd HH:mm:ss}', '{efolioB:yyyy-MM-dd HH:mm:ss}', '{efolioGlobal:yyyy-MM-dd HH:mm:ss}');";

            using var connection = new SQLiteConnection(ConnectionString);

            connection.Open();

            InserirDados(connection, insertString);

            connection.Close();
        }

        /// <summary>
        /// Obter todas as UCs
        /// </summary>
        /// <returns>Datatable com todas as UCs</returns>
        public static DataTable ObterUCs()
        {
            string readString = $"SELECT * FROM ucs";

            using var connection = new SQLiteConnection(ConnectionString);

            connection.Open();

            DataTable dtAux = LerDados(connection, readString);

            connection.Close();

            return dtAux;
        }
        #endregion

        #region Métodos & Funções da Tabela Aluno_UC

        public static void InscreverAlunoUC(int idAluno, int idUc)
        {
            string insertString = $"INSERT INTO aluno_uc (id_aluno, id_uc) VALUES('{idAluno}', '{idUc}');";

            using var connection = new SQLiteConnection(ConnectionString);

            connection.Open();

            InserirDados(connection, insertString);

            connection.Close();
        }

        #endregion
    }
}
