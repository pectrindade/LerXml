using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LerXML
{
    class Global
    {
    }

    public static class Parametros
    {
        private static string _form = "";
        public static string Form
        {
            get { return _form; }
            set { _form = value; }
        }

        private static string _valor = "";
        public static string Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        private static string _codigo = "";
        public static string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private static string _nome = "";
        public static string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private static string _pesq = "";
        public static string Pesq
        {
            get { return _pesq; }
            set { _pesq = value; }
        }

        private static string _tipo = "";
        public static string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private static string _aprovado = "";
        public static string Aprovado
        {
            get { return _aprovado; }
            set { _aprovado = value; }
        }

        private static string _coddepartamento = "";
        public static string Coddepartamento
        {
            get { return _coddepartamento; }
            set { _coddepartamento = value; }
        }

        private static string _data = "";
        public static string Data
        {
            get { return _data; }
            set { _data = value; }
        }


    }

    public static class Usuario
    {
        private static string _codempresa = "";
        public static string Codempresa
        {
            get { return _codempresa; }
            set { _codempresa = value; }
        }

        private static string _coddepartamento = "";
        public static string Coddepartamento
        {
            get { return _coddepartamento; }
            set { _coddepartamento = value; }
        }

        private static string _codunidade = "";
        public static string Codunidade
        {
            get { return _codunidade; }
            set { _codunidade = value; }
        }

        private static string _codusuario = "";
        public static string Codusuario
        {
            get { return _codusuario; }
            set { _codusuario = value; }
        }
        private static string _nomeusuario = "";
        public static string Nomeusuario
        {
            get { return _nomeusuario; }
            set { _nomeusuario = value; }
        }
        private static string _funcao = "";
        public static string Funcao
        {
            get { return _funcao; }
            set { _funcao = value; }
        }
        private static string _lotado = "";
        public static string Lotado
        {
            get { return _lotado; }
            set { _lotado = value; }
        }
        private static string _cpf = "";
        public static string Cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }
        private static string _login = "";
        public static string Login
        {
            get { return _login; }
            set { _login = value; }
        }
        private static string _email = "";
        public static string Email
        {
            get { return _email; }
            set { _email = value; }
        }
    }

}
