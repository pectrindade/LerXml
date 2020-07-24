using System;
using System.ComponentModel;
using System.Data;
using LerXML.Classes.DAL;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace LerXML.Classes.MySQL
{
    [DataObject(true)]
    public class UsuariosAccess
    {
        //-> Construtor para inserção e edição
        public UsuariosAccess(string login, string senha, string ativo, string tipo
        )
        {

            Login = login;
            Senha = senha;
            Ativo = ativo;
            Tipo = tipo;

        }

        public UsuariosAccess(string login)
        {
            Login = login;

        }

        public UsuariosAccess(string login, string acesso)
        {
            Login = login;
            Acesso = acesso;
        }


        private int Codusuario { get; set; }
        private string Login { get; set; }
        private string Acesso { get; set; }
        private string Senha { get; set; }
        private string Ativo { get; set; }
        private string Tipo { get; set; }

        public static string Acessar(string login, string senha)
        {


            DBAcessOleDB db = new DBAcessOleDB();

            const string select = "SELECT * ";
            const string from = " FROM usuarios ";
            const string where = " WHERE (LOGIN = @login) " +
                                 " AND (SENHA = @senha) ";


            try
            {
                db.CommandText = select + from + where;

                db.AddParameter("@login", login);
                db.AddParameter("@Senha", senha);

                string R = Convert.ToString(db.ExecuteScalar());
                return R;
            }
            catch
            {
                throw;
            }
        }

        public int Insert()
        {
            var db = new DBAcessOleDB();
            const string insert = " INSERT INTO tbusuario(" +
           " Codpessoa, Codcoligada, Codperfil, Datahoracriacao, Respcriacao, Login, " +
           " Senha, Datasenha, Respsenha, Ultimoacesso, Tipo, Alteralogin, Datahoralogin, Ativo " +
           ")";
            const string values = " VALUES (" +
           " @Codpessoa, @Codcoligada, @Codperfil, @Datahoracriacao, @Respcriacao, @Login, " +
           " @Senha, @Datasenha, @Respsenha, @Ultimoacesso, @Tipo, @Alteralogin, @Datahoralogin, @Ativo " +
           ");";

            // RETORNA O ULTIMO ITEM ADICIONADO 
            const string select = " SELECT MAX(CODUSUARIO) FROM tbusuario ";

            db.CommandText = insert + values + select;
            db.AddParameter("@Codusuario", Codusuario);

            db.AddParameter("@Login", Login);
            db.AddParameter("@Senha", Senha);

            db.AddParameter("@Ativo", Ativo);
            db.AddParameter("@tipo", Tipo);



            try
            {
                return Convert.ToInt32(db.ExecuteScalar());
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool Update()
        {
            var db = new DBAcessOleDB();
            const string update = " UPDATE `tbusuario` ";
            const string set = "SET " +
            "Codusuario = @Codusuario, Codpessoa = @Codpessoa, Codcoligada = @Codcoligada, Codperfil = @Codperfil, Datahoracriacao = @Datahoracriacao, " +
            "Respcriacao = @Respcriacao, Login = @Login, Senha = @Senha, Datasenha = @Datasenha, Respsenha = @Respsenha, Ultimoacesso = @Ultimoacesso, " +
            "Tipo = @Tipo, Alteralogin = @Alteralogin, Datahoralogin = @Datahoralogin, Ativo = @Ativo ";

            const string where = " WHERE Codpessoa = @Codpessoa;";
            db.CommandText = update + set + where;
            db.AddParameter("@Codusuario", Codusuario);

            db.AddParameter("@Login", Login);
            db.AddParameter("@Senha", Senha);
            db.AddParameter("@Ativo", Ativo);
            db.AddParameter("@Tipo", Tipo);



            try
            {
                db.ExecuteNonQuery();
                return true;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool fechaBanco()
        {

            return true;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public OleDbDataReader SelectAcesso()
        {
            DBAcessOleDB db = new DBAcessOleDB();

            const string select = "select * ";
            const string from = " from Oficio0603 ";

            const string where = " WHERE USUARIO = @Login ";

            try
            {
                db.CommandText = select + from + where;
                db.AddParameter("@Login", Convert.ToInt32(Login).ToString());
                OleDbDataReader dr = (OleDbDataReader)db.ExecuteReader();
                return dr;
                db.Dispose();
            }
            catch
            {
                throw;
                db.Dispose();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public OleDbDataReader SelectUsuario()
        {
            Login = Login;

            DBAcessOleDB db = new DBAcessOleDB();

            var Mysql = "SELECT * ";
            Mysql = Mysql + " FROM usuarios ";
            Mysql = Mysql + " WHERE (CODUSUARIO = @CODUSUARIO) ";

            try
            {
                db.CommandText = Mysql;
                db.AddParameter("@Login", Login);
                OleDbDataReader dr = (OleDbDataReader)db.ExecuteReader();
                return dr;
            }
            catch
            {
                throw;
            }
        }

        public bool UpdateExclusao()
        {
            var db = new DBAcessOleDB();
            const string update = " UPDATE `tbusuario` ";
            const string set = " SET EXCLUIDO = @Excluido, DATAHORAEXCLUSAO = @datahoraexclusao, datahoraexclusao = @respexclusao";
            const string where = " WHERE Codusuario = @Codusuario;";
            db.CommandText = update + set + where;
            db.AddParameter("@Codusuario", Codusuario);

            try
            {
                db.ExecuteNonQuery();
                return true;
            }
            finally
            {
                db.Dispose();
            }
        }

        //-> Tem de definir quais as buscas 
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet Select(string por, string valor, bool todas)
        {
            var db = new DBAcessOleDB();
            const string select = " SELECT * ";
            const string from = " FROM tbusuario ";
            var where = " WHERE EXCLUIDO = 'N'   ";
            const string order = " ORDER BY DESCRICAO ASC ; ";
            switch (por)
            {
                case "NOME":
                    {
                        where += " AND (NOME LIKE CONCAT(@valor)) ";
                    }
                    break;
                case "DESCRICAO":
                    {
                        where += " AND (DESCRICAO LIKE CONCAT(@valor)) ";
                    }
                    break;
                case "CODIGO":
                    {
                        where += " AND CODTIPOCURSO=@valor ";
                    }
                    break;
            }

            if (todas)
                valor = '%' + valor + "%";

            db.CommandText = select + from + where + order;
            db.AddParameter("@valor", valor);
            try
            {
                var ds = db.ExecuteDataSet();
                return ds;
            }
            finally
            {
                db.Dispose();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet VerificaUsuario(int codigo)
        {
            var db = new DBAcessOleDB();
            const string select = "SELECT DISTINCT(ACESSO) ";
            const string from = " from oficio0603 ";

            const string where = " WHERE USUARIO = @Codusuario ";

            db.CommandText = select + from + where;
            db.AddParameter("@Codusuario", codigo);

            try
            {
                var ds = db.ExecuteDataSet();
                return ds;
            }
            finally
            {
                db.Dispose();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public OleDbDataReader SelectAcessoPorTela()
        {

            //Global.Usuario.Autorizacaoincluir = "N";
            //Global.Usuario.AutorizacaoAlterar = "N";
            //Global.Usuario.AutorizacaoExcluir = "N";
            //Global.Usuario.AutorizacaoListar = "N";

            DBAcessOleDB db = new DBAcessOleDB();

            const string select = "select * ";
            const string from = " from Oficio0603 ";

            const string where = " WHERE USUARIO = @Login ";
            const string and = " AND Acesso = @Acesso ";

            try
            {
                db.CommandText = select + from + where + and;
                db.AddParameter("@Login", Login);
                db.AddParameter("@Acesso", Acesso);
                OleDbDataReader dr = (OleDbDataReader)db.ExecuteReader();

                //var dr = (OleDbDataReader)Command.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var incluir = dr.GetString(dr.GetOrdinal("incluir")).ToString();
                        var alterar = dr.GetString(dr.GetOrdinal("alterar")).ToString();
                        var excluir = dr.GetString(dr.GetOrdinal("excluir")).ToString();
                        var listar = dr.GetString(dr.GetOrdinal("listar")).ToString();

                        //Global.Usuario.Autorizacaoincluir = incluir;
                        //Global.Usuario.AutorizacaoAlterar = alterar;
                        //Global.Usuario.AutorizacaoExcluir = excluir;
                        //Global.Usuario.AutorizacaoListar = listar;
                    }

                }

                dr.Close();
                dr.Dispose();
                db.Dispose();
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

    }
}