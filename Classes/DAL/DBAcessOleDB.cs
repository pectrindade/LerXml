using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace LerXML.Classes.DAL
{

    public class DBAcessOleDB : IDisposable
    {


        private IDbCommand cmd = new OleDbCommand();
        private string strConnectionString = "";
        private bool handleErrors = false;
        private string strLastError = "";
        public CommandType Tipo = CommandType.Text;


        public DBAcessOleDB()
        {

            ConnectionStringSettings objConnectionStringSettings = ConfigurationManager.ConnectionStrings["MinhaStringAccess"];
            strConnectionString = objConnectionStringSettings.ConnectionString;

            OleDbConnection cnn = new OleDbConnection();
            cnn.ConnectionString = strConnectionString;
            cmd.Connection = cnn;
            cmd.CommandType = Tipo;
        }

        public DBAcessOleDB(string StringConexao)
        {
            strConnectionString = StringConexao;
            OleDbConnection cnn = new OleDbConnection();
            cnn.ConnectionString = strConnectionString;
            cmd.Connection = cnn;
            cmd.CommandType = Tipo;
        }

        public DBAcessOleDB(CommandType _Tipo)
        {

            ConnectionStringSettings objConnectionStringSettings = ConfigurationManager.ConnectionStrings["MinhaStringAccess"];
            strConnectionString = objConnectionStringSettings.ConnectionString;

            OleDbConnection cnn = new OleDbConnection();
            cnn.ConnectionString = strConnectionString;
            cmd.Connection = cnn;
            cmd.CommandType = _Tipo;
        }

        public void TipoMuda(CommandType Tipo)
        {
            cmd.CommandType = Tipo;
        }

        public IDataReader ExecuteReader()
        {
            IDataReader reader = null;
            try
            {
                this.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                if (handleErrors)
                    strLastError = ex.Message;

                else
                    throw;

            }

            return reader;
        }

        public IDataReader ExecuteReader(string commandtext)
        {
            IDataReader reader = null;
            try
            {
                cmd.CommandText = commandtext;
                reader = ExecuteReader();
            }
            catch (Exception ex)
            {
                if (handleErrors)
                    strLastError = ex.Message;
                else
                    throw;
            }

            return reader;
        }

        public object ExecuteScalar()
        {
            object obj = null;
            try
            {
                Open();
                obj = cmd.ExecuteScalar();
                Close();
            }
            catch (Exception ex)
            {
                if (handleErrors)
                    strLastError = ex.Message;
                else
                    throw;
            }


            return obj;
        }

        public object ExecuteScalar(string commandtext)
        {
            object obj = null;
            try
            {
                cmd.CommandText = commandtext;
                obj = ExecuteScalar();
            }
            catch (Exception ex)
            {
                if (handleErrors)
                    strLastError = ex.Message;
                else
                    throw;
            }


            return obj;
        }

        public int ExecuteNonQuery()
        {
            int i = -1;
            try
            {
                Open();
                i = cmd.ExecuteNonQuery();
                Close();
            }
            catch (Exception ex)
            {
                if (handleErrors)
                    strLastError = ex.Message;
                else
                    throw;
            }


            return i;
        }


        public int ExecuteNonQuery(string commandtext)
        {
            int i = -1;
            try
            {
                cmd.CommandText = commandtext;
                i = ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (handleErrors)
                    strLastError = ex.Message;
                else
                    throw;
            }

            return i;
        }


        public DataSet ExecuteDataSet()
        {

            OleDbDataAdapter da = null;

            DataSet ds = null;
            try
            {

                da = new OleDbDataAdapter();

                da.SelectCommand = (OleDbCommand)cmd;
                ds = new DataSet();
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                if (handleErrors)
                    strLastError = ex.Message;
                else
                    throw;
            }


            return ds;
        }


        public DataSet ExecuteDataSet(string commandtext)
        {
            DataSet ds = null;
            try
            {
                cmd.CommandText = commandtext;
                ds = ExecuteDataSet();
            }
            catch (Exception ex)
            {
                if (handleErrors)
                    strLastError = ex.Message;
                else
                    throw;
            }

            return ds;
        }

        public DataSet ExecuteDataSet(OleDbCommand commandtext)
        {
            DataSet ds = null;
            try
            {
                cmd = commandtext;
                ds = ExecuteDataSet();
            }
            catch (Exception ex)
            {
                if (handleErrors)
                    strLastError = ex.Message;
                else
                    throw;
            }

            return ds;
        }

        public string CommandText
        {
            get
            {
                return cmd.CommandText;
            }
            set
            {
                cmd.CommandText = value;
                cmd.Parameters.Clear();
            }
        }

        public IDataParameterCollection Parameters
        {
            get
            {
                return cmd.Parameters;
            }
        }

        public void AddParameter(string paramname, object paramvalue)
        {
            try
            {

                OleDbParameter param = new OleDbParameter(paramname, paramvalue);
                cmd.Parameters.Add(param);
            }
            catch
            {
                throw;
            }
        }

        public void AddParameter(IDataParameter param)
        {
            cmd.Parameters.Add(param);
        }


        public string ConnectionString
        {
            get
            {
                return strConnectionString;
            }
            set
            {
                strConnectionString = value;
            }
        }

        private void Open()
        {
            cmd.Connection.Open();
        }

        private void Close()
        {
            cmd.Connection.Close();
        }

        public bool HandleExceptions
        {
            get
            {
                return handleErrors;
            }
            set
            {
                handleErrors = value;
            }
        }

        public string LastError
        {
            get
            {
                return strLastError;
            }
        }

        public void Dispose()
        {
            cmd.Dispose();
        }
    }

}
