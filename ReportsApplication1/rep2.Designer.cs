namespace ReportsApplication1
{
    partial class rep2
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
            this.EficienDataSet = new ReportsApplication1.EficienDataSet();
            this.DepartamentosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DepartamentosTableAdapter = new ReportsApplication1.EficienDataSetTableAdapters.DepartamentosTableAdapter();
            this.SupervisoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SupervisoresTableAdapter = new ReportsApplication1.EficienDataSetTableAdapters.SupervisoresTableAdapter();
            this.EmpleadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EmpleadosTableAdapter = new ReportsApplication1.EficienDataSetTableAdapters.EmpleadosTableAdapter();
            this.CentrosTrabajosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CentrosTrabajosTableAdapter = new ReportsApplication1.EficienDataSetTableAdapters.CentrosTrabajosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.EficienDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartamentosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupervisoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpleadosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CentrosTrabajosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "EficienDataSet_CentrosTrabajos";
            reportDataSource1.Value = this.CentrosTrabajosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReportsApplication1.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(679, 331);
            this.reportViewer1.TabIndex = 0;
            // 
            // EficienDataSet
            // 
            this.EficienDataSet.DataSetName = "EficienDataSet";
            this.EficienDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DepartamentosBindingSource
            // 
            this.DepartamentosBindingSource.DataMember = "Departamentos";
            this.DepartamentosBindingSource.DataSource = this.EficienDataSet;
            // 
            // DepartamentosTableAdapter
            // 
            this.DepartamentosTableAdapter.ClearBeforeFill = true;
            // 
            // SupervisoresBindingSource
            // 
            this.SupervisoresBindingSource.DataMember = "Supervisores";
            this.SupervisoresBindingSource.DataSource = this.EficienDataSet;
            // 
            // SupervisoresTableAdapter
            // 
            this.SupervisoresTableAdapter.ClearBeforeFill = true;
            // 
            // EmpleadosBindingSource
            // 
            this.EmpleadosBindingSource.DataMember = "Empleados";
            this.EmpleadosBindingSource.DataSource = this.EficienDataSet;
            // 
            // EmpleadosTableAdapter
            // 
            this.EmpleadosTableAdapter.ClearBeforeFill = true;
            // 
            // CentrosTrabajosBindingSource
            // 
            this.CentrosTrabajosBindingSource.DataMember = "CentrosTrabajos";
            this.CentrosTrabajosBindingSource.DataSource = this.EficienDataSet;
            // 
            // CentrosTrabajosTableAdapter
            // 
            this.CentrosTrabajosTableAdapter.ClearBeforeFill = true;
            // 
            // rep2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 331);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rep2";
            this.Text = "rep2";
            this.Load += new System.EventHandler(this.rep2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EficienDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartamentosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupervisoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpleadosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CentrosTrabajosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DepartamentosBindingSource;
        private EficienDataSet EficienDataSet;
        private System.Windows.Forms.BindingSource SupervisoresBindingSource;
        private ReportsApplication1.EficienDataSetTableAdapters.DepartamentosTableAdapter DepartamentosTableAdapter;
        private ReportsApplication1.EficienDataSetTableAdapters.SupervisoresTableAdapter SupervisoresTableAdapter;
        private System.Windows.Forms.BindingSource EmpleadosBindingSource;
        private ReportsApplication1.EficienDataSetTableAdapters.EmpleadosTableAdapter EmpleadosTableAdapter;
        private System.Windows.Forms.BindingSource CentrosTrabajosBindingSource;
        private ReportsApplication1.EficienDataSetTableAdapters.CentrosTrabajosTableAdapter CentrosTrabajosTableAdapter;

    }
}