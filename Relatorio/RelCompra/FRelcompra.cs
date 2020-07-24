using System;
using System.Windows.Forms;

namespace LerXML.Relatorio.RelCompra
{
    public partial class FRelcompra : Form
    {
        public FRelcompra()
        {
            InitializeComponent();
        }

        private void FRelcompra_Load(object sender, EventArgs e)
        {
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            reportViewer1.ZoomPercent = 100;
           

            // TODO: esta linha de código carrega dados na tabela 'DsRelcompra.RelCompra'. Você pode movê-la ou removê-la conforme necessário.
            this.RelCompraTableAdapter.Fill(this.DsRelcompra.RelCompra);

            this.reportViewer1.RefreshReport();

            if (Application.OpenForms["Espera"] != null)

                Application.OpenForms["Espera"].Close();

        }
    }
}
