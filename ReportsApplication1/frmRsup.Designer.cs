namespace ReportsApplication1
{
    partial class frmRsup
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
            this.SupervisoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EficienDataSet = new ReportsApplication1.EficienDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SupervisoresTableAdapter = new ReportsApplication1.EficienDataSetTableAdapters.SupervisoresTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SupervisoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EficienDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // SupervisoresBindingSource
            // 
            this.SupervisoresBindingSource.DataMember = "Supervisores";
            this.SupervisoresBindingSource.DataSource = this.EficienDataSet;
            // 
            // EficienDataSet
            // 
            this.EficienDataSet.DataSetName = "EficienDataSet";
            this.EficienDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "EficienDataSet_Supervisores";
            reportDataSource1.Value = this.SupervisoresBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReportsApplication1.repSup.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(763, 652);
            this.reportViewer1.TabIndex = 0;
            // 
            // SupervisoresTableAdapter
            // 
            this.SupervisoresTableAdapter.ClearBeforeFill = true;
            // 
            // frmRsup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 652);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRsup";
            this.Text = "Listado de Supervisores";
            this.Load += new System.EventHandler(this.rep2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SupervisoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EficienDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private EficienDataSet EficienDataSet;
        private System.Windows.Forms.BindingSource SupervisoresBindingSource;
        private ReportsApplication1.EficienDataSetTableAdapters.SupervisoresTableAdapter SupervisoresTableAdapter;

    }
}