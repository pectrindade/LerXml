using System;
using System.Data;
using System.Windows.Forms;
using LerXML.Classes.MySQL;
using LerXML.Classes.MySQL;
using LerXML.Classes.DAL;

namespace LerXML
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
           
        }
       

        private void BtnEntrar_Click(object sender, EventArgs e)
        {

            if (txtUsuario.Text.Trim() == "")
            {
                DivMensagem.Visible = true;
                txtUsuario.Focus();
                return;
            }
            if (txtSenha.Text.Trim() == "")
            {
                DivMensagem.Visible = true;
                txtUsuario.Focus();
                txtSenha.Focus();
                return;
            }


            var codigo = UsuariosAccess.Acessar(txtUsuario.Text.Trim(), txtSenha.Text.Trim());
            if (codigo.Trim() != "")
            {

                var dr = new UsuariosAccess(codigo).SelectUsuario();

                var nome = ""; var cpf = ""; var login = "";
                var primeiroacesso = "";

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        // Recolhe as Informações do Usuario
                        var codUsuario = dr.GetInt32(dr.GetOrdinal("CODUSUARIO")).ToString();
                        var codEmpresa = dr.GetInt32(dr.GetOrdinal("CODEMPRESA"));
                        nome = dr.GetString(dr.GetOrdinal("Nome"));
                        //cpf = dr.GetString(dr.GetOrdinal("CPF"));
                        login = dr.GetString(dr.GetOrdinal("Nome"));
                        //var email = dr.GetString(dr.GetOrdinal("email"));
                        //primeiroacesso = dr.GetString(dr.GetOrdinal("PRIMEIROACESSO"));

                        // e Coloca elas em uma variavel global...
                        Usuario.Codusuario = codUsuario.ToString();

                        this.Close();


                    }
                }
                dr.Dispose();
                dr.Close();




            }
            else
            {
                DivMensagem.Visible = true;
                txtSenha.Focus();
            }

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            DivMensagem.Visible = false;
        }

        private void cmbEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DivMensagem.Visible = false;
           
        }

        private void Acesso_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void BtnSair_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");

            }
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");

            }
        }

        private void btnsai_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
