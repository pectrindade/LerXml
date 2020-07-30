using System;
using System.Windows.Forms;

namespace LerXML.Relatorio.Emitente
{
    public partial class RelEmitente : Form
    {
        public RelEmitente()
        {
            InitializeComponent();
        }

        private void RelEmitente_Load(object sender, EventArgs e)
        {
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            reportViewer1.ZoomPercent = 100;

            reportViewer1.PrinterSettings.DefaultPageSettings.Landscape = true;


            // TODO: esta linha de código carrega dados na tabela 'DsEmitente.RelCompra'. Você pode movê-la ou removê-la conforme necessário.
            this.RelCompraTableAdapter.Fill(this.DsEmitente.RelCompra);

            this.reportViewer1.RefreshReport();

            if (Application.OpenForms["Espera"] != null)

                Application.OpenForms["Espera"].Close();
        }
    }
}
