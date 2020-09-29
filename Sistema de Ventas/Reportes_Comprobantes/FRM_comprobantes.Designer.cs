namespace Sistema_de_Ventas.Reportes_Comprobantes
{
    partial class FRM_comprobantes
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_comprobantes));
            this.Boletas_electronicaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DS_comprobates = new Sistema_de_Ventas.Reportes_Comprobantes.DS_comprobates();
            this.Boletas_electronicaTableAdapter = new Sistema_de_Ventas.Reportes_Comprobantes.DS_comprobatesTableAdapters.Boletas_electronicaTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_minimi = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new Klik.Windows.Forms.v1.EntryLib.ELRichPanel();
            ((System.ComponentModel.ISupportInitialize)(this.Boletas_electronicaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_comprobates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_titu)).BeginInit();
            this.pnl_titu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Boletas_electronicaBindingSource
            // 
            this.Boletas_electronicaBindingSource.DataMember = "Boletas_electronica";
            this.Boletas_electronicaBindingSource.DataSource = this.DS_comprobates;
            // 
            // DS_comprobates
            // 
            this.DS_comprobates.DataSetName = "DS_comprobates";
            this.DS_comprobates.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Boletas_electronicaTableAdapter
            // 
            this.Boletas_electronicaTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.Boletas_electronicaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sistema_de_Ventas.Reportes_Comprobantes.Report_comprobantes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 25);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(343, 763);
            this.reportViewer1.TabIndex = 0;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // btn_minimi
            // 
            this.btn_minimi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_minimi.FlatAppearance.BorderSize = 0;
            this.btn_minimi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_minimi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_minimi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_minimi.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_minimi.ForeColor = System.Drawing.Color.White;
            this.btn_minimi.Image = ((System.Drawing.Image)(resources.GetObject("btn_minimi.Image")));
            this.btn_minimi.Location = new System.Drawing.Point(284, 1);
            this.btn_minimi.Name = "btn_minimi";
            this.btn_minimi.Size = new System.Drawing.Size(20, 20);
            this.btn_minimi.TabIndex = 7;
            this.btn_minimi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btn_minimi, "Minimizar");
            this.btn_minimi.UseVisualStyleBackColor = true;
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_cerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cerrar.ForeColor = System.Drawing.Color.White;
            this.btn_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cerrar.Image")));
            this.btn_cerrar.Location = new System.Drawing.Point(317, 0);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(20, 20);
            this.btn_cerrar.TabIndex = 6;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btn_cerrar, "Cerrar Ventana");
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titu
            // 
            this.pnl_titu.ContainerStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_titu.ContainerStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.pnl_titu.ContainerStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.pnl_titu.ContainerStyle.BackgroundStyle.SolidColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_titu.ContainerStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.pnl_titu.ContainerStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.pnl_titu.ContainerStyle.BorderStyle.SolidColor = System.Drawing.Color.DimGray;
            this.pnl_titu.ContainerStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.pnl_titu.Controls.Add(this.btn_minimi);
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Expanded = true;
            this.pnl_titu.FooterStyle.BackgroundStyle.GradientAngle = 45F;
            this.pnl_titu.FooterStyle.FlashStyle.GradientAngle = 0F;
            this.pnl_titu.FooterStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.pnl_titu.FooterStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.pnl_titu.FooterStyle.Height = 0;
            this.pnl_titu.FooterStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.pnl_titu.HeaderStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.DimGray;
            this.pnl_titu.HeaderStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.pnl_titu.HeaderStyle.BackgroundStyle.SolidColor = System.Drawing.Color.DimGray;
            this.pnl_titu.HeaderStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.pnl_titu.HeaderStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.pnl_titu.HeaderStyle.Height = 23;
            this.pnl_titu.HeaderStyle.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl_titu.HeaderStyle.TextStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnl_titu.HeaderStyle.TextStyle.Text = "Comprobante";
            this.pnl_titu.HeaderStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Padding = new System.Windows.Forms.Padding(1, 23, 1, 0);
            this.pnl_titu.Size = new System.Drawing.Size(343, 25);
            this.pnl_titu.TabIndex = 51;
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
            // 
            // FRM_comprobantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(343, 788);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_comprobantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_comprobantes";
            this.Load += new System.EventHandler(this.FRM_comprobantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Boletas_electronicaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_comprobates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_titu)).EndInit();
            this.pnl_titu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource Boletas_electronicaBindingSource;
        private DS_comprobates DS_comprobates;
        private DS_comprobatesTableAdapters.Boletas_electronicaTableAdapter Boletas_electronicaTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btn_minimi;
        private System.Windows.Forms.Button btn_cerrar;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Klik.Windows.Forms.v1.EntryLib.ELRichPanel pnl_titu;
    }
}