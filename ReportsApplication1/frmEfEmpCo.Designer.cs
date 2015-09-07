namespace ReportsApplication1
{
    partial class frmEfEmpCo
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
            this.efByDeptoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EficienDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efByDeptoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "EficienDataSet_efByDepto";
            reportDataSource1.Value = this.efByDeptoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReportsApplication1.repEfEmpCo.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(994, 643);
            this.reportViewer1.TabIndex = 0;
            // 
            // EficienDataSet
            // 
            this.EficienDataSet.DataSetName = "EficienDataSet";
            this.EficienDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // efByDeptoBindingSource
            // 
            this.efByDeptoBindingSource.DataMember = "efByDepto";
            this.efByDeptoBindingSource.DataSource = this.EficienDataSet;
            // 
            // frmEfEmpCo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 643);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmEfEmpCo";
            this.Text = "Reporte de Eficiencia";
            this.Load += new System.EventHandler(this.rep2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EficienDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efByDeptoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource efByDeptoBindingSource;
        private EficienDataSet EficienDataSet;

    }
}