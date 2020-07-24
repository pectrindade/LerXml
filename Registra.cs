using LerXML.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LerXML
{
    public partial class Registra : Form
    {
        public Registra()
        {
            InitializeComponent();
        }

        private void Registra_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;

            var hd = Funcoes.BuscarDiscoLogico("");
            var data = date.ToString("dd/MM/yyyy");

            var registro = hd + data;

            txtNumeroRegistro.Text = Funcoes.Criptografar(registro);

        }



        private void btnVerifica_Click(object sender, EventArgs e)
        {
            var registro = Funcoes.Decriptar(txtNumeroRegistro1.Text.Trim());

            int caract = registro.Length;
            caract = caract - 10;
            //menos 10
            var numHD1 = registro.Substring(0, caract);
            var data1 = registro.Substring(caract, 10);

            txtNumHD.Text = numHD1;
            txtData.Text = data1;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = this.dateTimePicker2.Value;

            this.maskedTextBox2.Text = date.ToString("dd/MM/yyyy");
        }

        private void btnNovoRegistro_Click(object sender, EventArgs e)
        {
            var novoRegistro = txtNumHD.Text.Trim() + maskedTextBox2.Text.Trim();

            txtNovoNumeroRegistro.Text = Funcoes.Criptografar(novoRegistro);

        }

        private void btnRegistra_Click(object sender, EventArgs e)
        {

            Funcoes.GravaRegistro(txtChaveRegistro.Text);
            txtChaveRegistro.Text = "";

            var resposta = Funcoes.ValidaRegistro();

            if (resposta == false)
            {
                Parametros.Aprovado = "N";
            }
            else
            {
                Parametros.Aprovado = "S";
            }
            Close();

        }

        private void Registra_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.Control && e.KeyCode == Keys.T)
            {
                Senha senha = new Senha();
                senha.ShowDialog();
                if (Parametros.Valor == "@cpdrede12")
                {
                    ActiveForm.Width = 944;
                    ActiveForm.Height = 440;
                    ActiveForm.FormBorderStyle = FormBorderStyle.Sizable;
                }
            }
            if (e.Control && e.KeyCode == Keys.M)
            {
                ActiveForm.Width = 414;
                ActiveForm.Height = 260;

                ActiveForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            }

        }
    }
}
