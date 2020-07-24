namespace LerXML.Relatorio.RelCompra
{
    partial class FRelcompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRelcompra));
            this.RelCompraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsRelcompra = new LerXML.Relatorio.RelCompra.DsRelcompra();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.RelCompraTableAdapter = new LerXML.Relatorio.RelCompra.DsRelcompraTableAdapters.RelCompraTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.RelCompraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsRelcompra)).BeginInit();
            this.SuspendLayout();
            // 
            // RelCompraBindingSource
            // 
            this.RelCompraBindingSource.DataMember = "RelCompra";
            this.RelCompraBindingSource.DataSource = this.DsRelcompra;
            // 
            // DsRelcompra
            // 
            this.DsRelcompra.DataSetName = "DsRelcompra";
            this.DsRelcompra.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsRelcompra";
            reportDataSource1.Value = this.RelCompraBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LerXML.Relatorio.RelCompra.RelaRelcompra.rdlc";
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
            // FRelcompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRelcompra";
            this.Text = "Relatório de NCM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRelcompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RelCompraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsRelcompra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource RelCompraBindingSource;
        private DsRelcompra DsRelcompra;
        private DsRelcompraTableAdapters.RelCompraTableAdapter RelCompraTableAdapter;
    }
}