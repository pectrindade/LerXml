using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LerXML.Classes.DAL
{

    class Global
    {
        public static class Usuario
        {

            private static string glb_empresa = "";
            public static string Empresa
            {
                get { return glb_empresa; }
                set { glb_empresa = value; }
            }

            private static string glb_codusuario = "";
            public static string CodUsuario
            {
                get { return glb_codusuario; }
                set { glb_codusuario = value; }
            }

            private static string glb_nome = "";
            public static string Nome
            {
                get { return glb_nome; }
                set { glb_nome = value; }
            }

            private static string _login = "";
            public static string Login
            {
                get { return _login; }
                set { _login = value; }
            }


            //Variaveis para Controlar os acessos na tela 
            private static string autorizacaoincluir = "";
            public static string Autorizacaoincluir
            {
                get { return autorizacaoincluir; }
                set { autorizacaoincluir = value; }
            }

            private static string autorizacaoAlterar = "";
            public static string AutorizacaoAlterar
            {
                get { return autorizacaoAlterar; }
                set { autorizacaoAlterar = value; }
            }

            private static string autorizacaoExcluir = "";
            public static string AutorizacaoExcluir
            {
                get { return autorizacaoExcluir; }
                set { autorizacaoExcluir = value; }
            }

            private static string autorizacaoListar = "";
            public static string AutorizacaoListar
            {
                get { return autorizacaoListar; }
                set { autorizacaoListar = value; }
            }
            //---------------------------------------------
        }

        public static class Cliente
        {

            private static string glb_codcliente = "";
            public static string Codcliente
            {
                get { return glb_codcliente; }
                set { glb_codcliente = value; }
            }


        }
    }
}
