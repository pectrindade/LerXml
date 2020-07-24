using LerXML.Classes;
using LerXML.Forms.Movimento;
using LerXML.Relatorio.RelCompra;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Management;
using System.Windows.Forms;

namespace LerXML
{
    public partial class FrmMenu : Form
    {
        private int childFormNumber = 0;

        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            VerificaRegistro();
            VerificaAcesso();

        }


        private void VerificaRegistro()
        {
            var codigo = Usuario.Codusuario.ToString();

            if (codigo != "")
            {
                var resposta = Funcoes.ValidaRegistro();

                if (resposta == false)
                {

                    MessageBox.Show("Entre em Contato com o Desenvolvedor !",
                    "Programa sem Registro ou expirado",
                    MessageBoxButtons.OK);

                    BloqueiaMenu();
                    AbreTelaRegistro();

                }
                else { DesBloqueiaMenu(); }
            }
        }

        private void VerificaAcesso()
        {

            var codigo = Usuario.Codusuario.ToString();
            var nome = Usuario.Login.ToString();

            if (codigo == "")
            {
                Close();
            }

        }

        public void BloqueiaMenu()
        {
            menu1.Enabled = false;
        }
        public void DesBloqueiaMenu()
        {
            menu1.Enabled = true;
        }

        private void MFIsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MFIlogof_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
        }

        private void MFClerxml_Click(object sender, EventArgs e)
        {
            bool open = false;
            foreach (Form form in this.MdiChildren)
            {
                if (form is frmSerializarXml)
                {
                    form.BringToFront();
                    open = true;
                }
            }
            if (!open)
            {
                Form tela = new frmSerializarXml();
                tela.MdiParent = this;
                tela.Show();
            }
        }

        private void chaveToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        public void Registro()
        {



        }

        public void AbreTelaRegistro()
        {
            Registra registra = new Registra();
            registra.ShowDialog();
            if (Parametros.Aprovado == "S")
            {
                DesBloqueiaMenu();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            


        }

        private void MFutilitariosRegistra_Click(object sender, EventArgs e)
        {
            //bool open = false;
            //foreach (Form form in this.MdiChildren)
            //{
            //    if (form is Registra)
            //    {
            //        form.BringToFront();
            //        open = true;
            //    }
            //}
            //if (!open)
            //{
            //    Form tela = new Registra();
            //    tela.MdiParent = this;
            //    tela.Show();
            //}

            AbreTelaRegistro();
        }
    }
}
