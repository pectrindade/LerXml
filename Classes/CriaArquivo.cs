using LerXML.Classes.DAL;
using System.ComponentModel;

namespace LerXML.Classes
{
    [DataObject(true)]
    public class CriaArquivo
    {

        public CriaArquivo()
        {

        }


        public bool Cria_RelBase()
        {

            Inicio:

            var db = new DBAcessOleDB();

            var tableName = "RelBase";

            var Mysql = "CREATE TABLE " + tableName + "( ";

            Mysql = Mysql + " [ANO] varchar(4), ";
            Mysql = Mysql + " [NUMERONF] varchar(10), ";
            Mysql = Mysql + " [DATAEMISSAO]  DATETIME, ";
            Mysql = Mysql + " [EMICNPJ]  varchar(20), ";
            Mysql = Mysql + " [EMINOME]  varchar(255), ";
            Mysql = Mysql + " [DESTCNPJ]  varchar(20), ";
            Mysql = Mysql + " [DESTNOME]  varchar(255), ";
            Mysql = Mysql + " [CHAVE]  varchar(200), ";
            Mysql = Mysql + " [NOMEPRODUTO]  varchar(200), ";
            Mysql = Mysql + " [QUANTIDADE]  varchar(20), ";
            Mysql = Mysql + " [VALORUNITARIO]  varchar(20), ";
            Mysql = Mysql + " [NCM]  varchar(50) ";

            Mysql = Mysql + " )";

            db.CommandText = Mysql;

            try
            {
                db.ExecuteNonQuery();
                return true;
            }
            catch
            {

                db.Dispose();
                db = new DBAcessOleDB();

                Mysql = "DROP TABLE " + tableName;
                db.CommandText = Mysql;
                try
                {
                    db.ExecuteNonQuery();
                }
                finally
                {
                    db.Dispose();
                }

                goto Inicio;

            }
            finally
            {
                db.Dispose();
            }
        }

        public bool Cria_RelCompras()
        {

            Inicio:

            var db = new DBAcessOleDB();

            var tableName = "RelCompra";

            var Mysql = "CREATE TABLE " + tableName + "( ";

            Mysql = Mysql + " [NUMERONF] varchar(10), ";
            Mysql = Mysql + " [DATAEMISSAO]  varchar(20), ";
            Mysql = Mysql + " [CNPJ]  varchar(20), ";
            Mysql = Mysql + " [NOMEEMPRESA]  varchar(255), ";
            Mysql = Mysql + " [CHAVE]  varchar(200), ";
            Mysql = Mysql + " [NOMEPRODUTO]  varchar(200), ";
            Mysql = Mysql + " [QUANTIDADE]  varchar(20), ";
            Mysql = Mysql + " [VALORUNITARIO]  varchar(20), ";
            Mysql = Mysql + " [NCM]  varchar(50) ";

            Mysql = Mysql + " )";

            db.CommandText = Mysql;

            try
            {
                db.ExecuteNonQuery();
                return true;
            }
            catch
            {

                db.Dispose();
                db = new DBAcessOleDB();

                Mysql = "DROP TABLE " + tableName;
                db.CommandText = Mysql;
                try
                {
                    db.ExecuteNonQuery();
                }
                finally
                {
                    db.Dispose();
                }

                goto Inicio;

            }
            finally
            {
                db.Dispose();
            }
        }

    }
}
