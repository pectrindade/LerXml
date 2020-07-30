using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LerXML.Relatorio.Destinatario
{
    public partial class RelDestinatario : Form
    {
        public RelDestinatario()
        {
            InitializeComponent();
        }

        private void RelDestinatario_Load(object sender, EventArgs e)
        {

            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            reportViewer1.ZoomPercent = 100;

            reportViewer1.PrinterSettings.DefaultPageSettings.Landscape = true;

            // TODO: esta linha de código carrega dados na tabela 'DsDestinatario.RelCompra'. Você pode movê-la ou removê-la conforme necessário.
            this.RelCompraTableAdapter.Fill(this.DsDestinatario.RelCompra);

            this.reportViewer1.RefreshReport();

            if (Application.OpenForms["Espera"] != null)

                Application.OpenForms["Espera"].Close();

        }
    }
}
