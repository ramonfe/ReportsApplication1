namespace ReportsApplication1
{
    partial class frmRct
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
            this.CentrosTrabajosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EficienDataSet = new ReportsApplication1.EficienDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CentrosTrabajosTableAdapter = new ReportsApplication1.EficienDataSetTableAdapters.CentrosTrabajosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CentrosTrabajosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EficienDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // CentrosTrabajosBindingSource
            // 
            this.CentrosTrabajosBindingSource.DataMember = "CentrosTrabajos";
            this.CentrosTrabajosBindingSource.DataSource = this.EficienDataSet;
            // 
            // EficienDataSet
            // 
            this.EficienDataSet.DataSetName = "EficienDataSet";
            this.EficienDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "EficienDataSet_CentrosTrabajos";
            reportDataSource1.Value = this.CentrosTrabajosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReportsApplication1.repCenTrab.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(836, 505);
            this.reportViewer1.TabIndex = 0;
            // 
            // CentrosTrabajosTableAdapter
            // 
            this.CentrosTrabajosTableAdapter.ClearBeforeFill = true;
            // 
            // frmRct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 505);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRct";
            this.Text = "Listado de Centros de Trabajo";
            this.Load += new System.EventHandler(this.rep2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CentrosTrabajosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EficienDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private EficienDataSet EficienDataSet;
        private System.Windows.Forms.BindingSource CentrosTrabajosBindingSource;
        private ReportsApplication1.EficienDataSetTableAdapters.CentrosTrabajosTableAdapter CentrosTrabajosTableAdapter;

    }
}