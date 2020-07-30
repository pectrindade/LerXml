namespace LerXML.Relatorio.Emitente
{
    partial class RelEmitente
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
            this.RelCompraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsEmitente = new LerXML.Relatorio.Emitente.DsEmitente();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.RelCompraTableAdapter = new LerXML.Relatorio.Emitente.DsEmitenteTableAdapters.RelCompraTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.RelCompraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsEmitente)).BeginInit();
            this.SuspendLayout();
            // 
            // RelCompraBindingSource
            // 
            this.RelCompraBindingSource.DataMember = "RelCompra";
            this.RelCompraBindingSource.DataSource = this.DsEmitente;
            // 
            // DsEmitente
            // 
            this.DsEmitente.DataSetName = "DsEmitente";
            this.DsEmitente.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsEmitente";
            reportDataSource1.Value = this.RelCompraBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LerXML.Relatorio.Emitente.RelEmitente.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.ShowProgress = false;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // RelCompraTableAdapter
            // 
            this.RelCompraTableAdapter.ClearBeforeFill = true;
            // 
            // RelEmitente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RelEmitente";
            this.Text = "Relatório de Emitente";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RelEmitente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RelCompraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsEmitente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource RelCompraBindingSource;
        private DsEmitente DsEmitente;
        private DsEmitenteTableAdapters.RelCompraTableAdapter RelCompraTableAdapter;
    }
}