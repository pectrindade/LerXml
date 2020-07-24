using LerXML.Classes.DAL;
using System;
using System.ComponentModel;

namespace LerXML.Classes.MySQL
{
    [DataObject(true)]
    public class RelBase
    {

        public RelBase()
        {

        }


        public int InsertAccess_RelBase(string ano, string numeronf, string dataemissao, string emicnpj, string eminome, string destcnpj, string destnome, string chave, string nomeproduto, string quantidade,
                                                string valorunitario, string ncm)
        {
            var db = new DBAcessOleDB();

            var Mysql = " INSERT INTO RelBase(";
            Mysql = Mysql + " ANO, NUMERONF, DATAEMISSAO, EMICNPJ, EMINOME, DESTCNPJ, DESTNOME, CHAVE, NOMEPRODUTO, QUANTIDADE, VALORUNITARIO, NCM ";

            Mysql = Mysql + ") ";
            Mysql = Mysql + " VALUES(";
            Mysql = Mysql + " @ANO, @NUMERONF, @DATAEMISSAO, @EMICNPJ, @EMINOME, @DESTCNPJ, @DESTNOME, @CHAVE, @NOMEPRODUTO, @QUANTIDADE, @VALORUNITARIO, @NCM ";
            Mysql = Mysql + "); ";

            db.CommandText = Mysql;

            db.AddParameter("@ANO", ano);
            db.AddParameter("@NUMERONF", numeronf);
            db.AddParameter("@DATAEMISSAO", Convert.ToDateTime(dataemissao));
            db.AddParameter("@EMICNPJ", emicnpj);
            db.AddParameter("@EMINOME", eminome);
            db.AddParameter("@DESTCNPJ", destcnpj);
            db.AddParameter("@DESTNOME", destnome);
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
