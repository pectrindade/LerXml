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
    public partial class Senha : Form
    {
        public Senha()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEntra_Click(object sender, EventArgs e)
        {
            if(txtsenha.Text.Trim() != "")
            {
                Parametros.Valor = txtsenha.Text.Trim();
            }
            Close();
        }
    }
}
