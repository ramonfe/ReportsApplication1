namespace ReportsApplication1
{
    partial class frmRco
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
            this.CodigosDeOperacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EficienDataSet = new ReportsApplication1.EficienDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CodigosDeOperacionTableAdapter = new ReportsApplication1.EficienDataSetTableAdapters.CodigosDeOperacionTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CodigosDeOperacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EficienDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // CodigosDeOperacionBindingSource
            // 
            this.CodigosDeOperacionBindingSource.DataMember = "CodigosDeOperacion";
            this.CodigosDeOperacionBindingSource.DataSource = this.EficienDataSet;
            // 
            // EficienDataSet
            // 
            this.EficienDataSet.DataSetName = "EficienDataSet";
            this.EficienDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "EficienDataSet_CodigosDeOperacion";
            reportDataSource1.Value = this.CodigosDeOperacionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReportsApplication1.repCodOp.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(956, 621);
            this.reportViewer1.TabIndex = 0;
            // 
            // CodigosDeOperacionTableAdapter
            // 
            this.CodigosDeOperacionTableAdapter.ClearBeforeFill = true;
            // 
            // frmRco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 621);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRco";
            this.Text = "Listado de Codigos de Operacion";
            this.Load += new System.EventHandler(this.frmRco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CodigosDeOperacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EficienDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource CodigosDeOperacionBindingSource;
        private EficienDataSet EficienDataSet;
        private ReportsApplication1.EficienDataSetTableAdapters.CodigosDeOperacionTableAdapter CodigosDeOperacionTableAdapter;
    }
}