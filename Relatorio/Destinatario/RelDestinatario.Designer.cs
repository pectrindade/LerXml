namespace LerXML.Relatorio.Destinatario
{
    partial class RelDestinatario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DsDestinatario = new LerXML.Relatorio.Destinatario.DsDestinatario();
            this.RelCompraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RelCompraTableAdapter = new LerXML.Relatorio.Destinatario.DsDestinatarioTableAdapters.RelCompraTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DsDestinatario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RelCompraBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsDestinatario";
            reportDataSource1.Value = this.RelCompraBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LerXML.Relatorio.Destinatario.RelDestinatario.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // DsDestinatario
            // 
            this.DsDestinatario.DataSetName = "DsDestinatario";
            this.DsDestinatario.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // RelCompraBindingSource
            // 
            this.RelCompraBindingSource.DataMember = "RelCompra";
            this.RelCompraBindingSource.DataSource = this.DsDestinatario;
            // 
            // RelCompraTableAdapter
            // 
            this.RelCompraTableAdapter.ClearBeforeFill = true;
            // 
            // RelDestinatario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RelDestinatario";
            this.Text = "Destinatario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RelDestinatario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DsDestinatario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RelCompraBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource RelCompraBindingSource;
        private DsDestinatario DsDestinatario;
        private DsDestinatarioTableAdapters.RelCompraTableAdapter RelCompraTableAdapter;
    }
}