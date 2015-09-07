namespace ReportsApplication1
{
    partial class frmRdep
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DepartamentosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EficienDataSet = new ReportsApplication1.EficienDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DepartamentosTableAdapter = new ReportsApplication1.EficienDataSetTableAdapters.DepartamentosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DepartamentosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EficienDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // DepartamentosBindingSource
            // 
            this.DepartamentosBindingSource.DataMember = "Departamentos";
            this.DepartamentosBindingSource.DataSource = this.EficienDataSet;
            // 
            // EficienDataSet
            // 
            this.EficienDataSet.DataSetName = "EficienDataSet";
            this.EficienDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "EficienDataSet_Departamentos";
            reportDataSource2.Value = this.DepartamentosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReportsApplication1.repDeptos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(679, 331);
            this.reportViewer1.TabIndex = 0;
            // 
            // DepartamentosTableAdapter
            // 
            this.DepartamentosTableAdapter.ClearBeforeFill = true;
            // 
            // frmRdep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 331);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRdep";
            this.Text = "Listado de Departamentos";
            this.Load += new System.EventHandler(this.rep2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DepartamentosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EficienDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private EficienDataSet EficienDataSet;
        private System.Windows.Forms.BindingSource DepartamentosBindingSource;
        private ReportsApplication1.EficienDataSetTableAdapters.DepartamentosTableAdapter DepartamentosTableAdapter;

    }
}