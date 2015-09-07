namespace ReportsApplication1
{
    partial class frmRlin
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
            this.LineasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EficienDataSet = new ReportsApplication1.EficienDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.LineasTableAdapter = new ReportsApplication1.EficienDataSetTableAdapters.LineasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.LineasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EficienDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // LineasBindingSource
            // 
            this.LineasBindingSource.DataMember = "Lineas";
            this.LineasBindingSource.DataSource = this.EficienDataSet;
            // 
            // EficienDataSet
            // 
            this.EficienDataSet.DataSetName = "EficienDataSet";
            this.EficienDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "EficienDataSet_Lineas";
            reportDataSource1.Value = this.LineasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReportsApplication1.repLin.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(911, 592);
            this.reportViewer1.TabIndex = 0;
            // 
            // LineasTableAdapter
            // 
            this.LineasTableAdapter.ClearBeforeFill = true;
            // 
            // frmRlin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 592);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRlin";
            this.Text = "Listado de Lineas";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LineasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EficienDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private EficienDataSet EficienDataSet;
        private System.Windows.Forms.BindingSource LineasBindingSource;
        private ReportsApplication1.EficienDataSetTableAdapters.LineasTableAdapter LineasTableAdapter;
    }
}