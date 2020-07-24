using LerXML.Classes.DAL;
using System;
using System.ComponentModel;
using System.Data.OleDb;

namespace LerXML.Classes.MySQL
{
    [DataObject(true)]
    public class RelCompra
    {
        
        public  RelCompra()
        {

        }

        public bool DeleteAccess()
        {
            var db = new DBAcessOleDB();
            var Mysql = " DELETE FROM RelCompra ";

            db.CommandText = Mysql;

            try
            {
                db.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public static OleDbDataReader BuscaBaseCompras()
        {

            var db = new DBAcessOleDB();
            string Mysql = "SELECT  * ";
            Mysql = Mysql + " FROM RelBase ";
            //Mysql = Mysql + " ORDER BY E.DATAMOVIMENTO, E.NOMEPRODUTO, E.CODMOVIMENTO ";

            db.CommandText = Mysql;
            var dr = (OleDbDataReader)db.ExecuteReader();
            return dr;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public static OleDbDataReader BuscaCompras(string ano, string dtinicial, string dtfinal, string emicnpj, string destcnpj, string chave, string ncm)
        {

            var db = new DBAcessOleDB();
            string Mysql = "SELECT  * ";
            Mysql = Mysql + " FROM RelBase ";
            Mysql = Mysql + " WHERE ANO = '" + ano + "'";
            if (dtinicial != "") { Mysql = Mysql + " AND DATAEMISSAO BETWEEN #" + dtinicial  + "# AND #" + dtfinal + "#"; }
            if (emicnpj != "") { Mysql = Mysql + " AND EMICNPJ = '" + emicnpj + "'"; }
            if (destcnpj != "") { Mysql = Mysql + " AND DESTCNPJ = '" + destcnpj +"'"; }
            if (chave != "") { Mysql = Mysql + " AND CHAVE = '" + chave + "'"; }
            if (ncm != "") {  Mysql = Mysql + " AND NCM = '" + ncm + "'"; }




            db.CommandText = Mysql;

            //db.AddParameter("@ANO", ano);
            //if (dtinicial != "") { db.AddParameter("@DATAINICIAL", Convert.ToDateTime(dtinicial)); }
            //if (dtinicial != "") { db.AddParameter("@DATAFINAL", Convert.ToDateTime(dtfinal)); }
           

            var dr = (OleDbDataReader)db.ExecuteReader();
            return dr;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static OleDbDataReader BuscaEmitente()
        {

            var db = new DBAcessOleDB();
            string Mysql = "SELECT DISTINCT (EMICNPJ) AS CODEMITENTE, relbase.EMINOME AS NOMEEMITENTE ";
            Mysql = Mysql + " FROM RelBase ";

            db.CommandText = Mysql;

            var dr = (OleDbDataReader)db.ExecuteReader();
            return dr;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static OleDbDataReader BuscaDestinatario()
        {

            var db = new DBAcessOleDB();
            string Mysql = "SELECT DISTINCT (DESTCNPJ) AS CODDESTINATARIO, relbase.DESTNOME AS NOMEDESTINATARIO ";
            Mysql = Mysql + " FROM RelBase ";
            Mysql = Mysql + " ORDER BY DESTCNPJ ";

            db.CommandText = Mysql;

            var dr = (OleDbDataReader)db.ExecuteReader();
            return dr;
        }


        public int InsertAccess_RelCompra(string numeronf, string dataemissao, string cnpj, string nomeempresa, string chave, string nomeproduto, string quantidade,
                                                string valorunitario, string ncm)
        {
            var db = new DBAcessOleDB();

            var Mysql = " INSERT INTO RelCompra(";
            Mysql = Mysql + " NUMERONF, DATAEMISSAO, CNPJ, NOMEEMPRESA, CHAVE, NOMEPRODUTO, QUANTIDADE, VALORUNITARIO, NCM ";

            Mysql = Mysql + ") ";
            Mysql = Mysql + " VALUES(";
            Mysql = Mysql + " @NUMERONF, @DATAEMISSAO, @CNPJ, @NOMEEMPRESA, @CHAVE, @NOMEPRODUTO, @QUANTIDADE, @VALORUNITARIO, @NCM ";
            Mysql = Mysql + "); ";

            db.CommandText = Mysql;

            db.AddParameter("@NUMERONF", numeronf);
            db.AddParameter("@DATAEMISSAO", dataemissao);
            db.AddParameter("@CNPJ", cnpj);
            db.AddParameter("@NOMEEMPRESA", nomeempresa);
            db.AddParameter("@CHAVE", chave);
            db.AddParameter("@NOMEPRODUTO", nomeproduto);
            db.AddParameter("@QUANTIDADE", quantidade);
            db.AddParameter("@VALORUNITARIO", valorunitario);
            db.AddParameter("@NCM", ncm);
                     
            try
            {
                return Convert.ToInt32(db.ExecuteScalar());
            }
            finally
            {
                db.Dispose();
            }
        }

    }
}
