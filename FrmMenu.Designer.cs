namespace LerXML
{
    partial class FrmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.menu1 = new System.Windows.Forms.MenuStrip();
            this.MFcadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MFIlogof = new System.Windows.Forms.ToolStripMenuItem();
            this.MFIsair = new System.Windows.Forms.ToolStripMenuItem();
            this.MFcontrole = new System.Windows.Forms.ToolStripMenuItem();
            this.MFClerxml = new System.Windows.Forms.ToolStripMenuItem();
            this.MFconsultas = new System.Windows.Forms.ToolStripMenuItem();
            this.MFrelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.MFutilitarios = new System.Windows.Forms.ToolStripMenuItem();
            this.MFutilitariosRegistra = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu1
            // 
            this.menu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MFcadastro,
            this.MFcontrole,
            this.MFconsultas,
            this.MFrelatorios,
            this.MFutilitarios,
            this.helpMenu});
            this.menu1.Location = new System.Drawing.Point(0, 0);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(889, 24);
            this.menu1.TabIndex = 0;
            this.menu1.Text = "MenuStrip";
            // 
            // MFcadastro
            // 
            this.MFcadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.MFIlogof,
            this.MFIsair});
            this.MFcadastro.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.MFcadastro.Name = "MFcadastro";
            this.MFcadastro.Size = new System.Drawing.Size(66, 20);
            this.MFcadastro.Text = "&Cadastro";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(107, 6);
            // 
            // MFIlogof
            // 
            this.MFIlogof.Name = "MFIlogof";
            this.MFIlogof.Size = new System.Drawing.Size(110, 22);
            this.MFIlogof.Text = "Log Of";
            this.MFIlogof.Click += new System.EventHandler(this.MFIlogof_Click);
            // 
            // MFIsair
            // 
            this.MFIsair.Name = "MFIsair";
            this.MFIsair.Size = new System.Drawing.Size(110, 22);
            this.MFIsair.Text = "E&xit";
            this.MFIsair.Click += new System.EventHandler(this.MFIsair_Click);
            // 
            // MFcontrole
            // 
            this.MFcontrole.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MFClerxml});
            this.MFcontrole.Name = "MFcontrole";
            this.MFcontrole.Size = new System.Drawing.Size(65, 20);
            this.MFcontrole.Text = "&Controle";
            // 
            // MFClerxml
            // 
            this.MFClerxml.Name = "MFClerxml";
            this.MFClerxml.Size = new System.Drawing.Size(114, 22);
            this.MFClerxml.Text = "Ler Xml";
            this.MFClerxml.Click += new System.EventHandler(this.MFClerxml_Click);
            // 
            // MFconsultas
            // 
            this.MFconsultas.Name = "MFconsultas";
            this.MFconsultas.Size = new System.Drawing.Size(66, 20);
            this.MFconsultas.Text = "&Consulta";
            // 
            // MFrelatorios
            // 
            this.MFrelatorios.Name = "MFrelatorios";
            this.MFrelatorios.Size = new System.Drawing.Size(66, 20);
            this.MFrelatorios.Text = "&Relatório";
            // 
            // MFutilitarios
            // 
            this.MFutilitarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MFutilitariosRegistra});
            this.MFutilitarios.Name = "MFutilitarios";
            this.MFutilitarios.Size = new System.Drawing.Size(69, 20);
            this.MFutilitarios.Text = "&Utilitários";
            // 
            // MFutilitariosRegistra
            // 
            this.MFutilitariosRegistra.Name = "MFutilitariosRegistra";
            this.MFutilitariosRegistra.Size = new System.Drawing.Size(116, 22);
            this.MFutilitariosRegistra.Text = "Registra";
            this.MFutilitariosRegistra.Click += new System.EventHandler(this.MFutilitariosRegistra_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(44, 20);
            this.helpMenu.Text = "&Help";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(889, 453);
            this.Controls.Add(this.menu1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menu1;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ler XML ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.menu1.ResumeLayout(false);
            this.menu1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menu1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem MFcadastro;
        private System.Windows.Forms.ToolStripMenuItem MFIsair;
        private System.Windows.Forms.ToolStripMenuItem MFcontrole;
        private System.Windows.Forms.ToolStripMenuItem MFconsultas;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem MFrelatorios;
        private System.Windows.Forms.ToolStripMenuItem MFutilitarios;
        private System.Windows.Forms.ToolStripMenuItem MFIlogof;
        private System.Windows.Forms.ToolStripMenuItem MFClerxml;
        private System.Windows.Forms.ToolStripMenuItem MFutilitariosRegistra;
    }
}




