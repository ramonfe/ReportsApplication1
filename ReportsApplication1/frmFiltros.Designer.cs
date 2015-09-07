namespace ReportsApplication1
{
    partial class frmFiltros
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbF = new System.Windows.Forms.ListBox();
            this.dtPick1 = new System.Windows.Forms.DateTimePicker();
            this.dtPick2 = new System.Windows.Forms.DateTimePicker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(432, 408);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtPick2);
            this.tabPage1.Controls.Add(this.dtPick1);
            this.tabPage1.Controls.Add(this.lbF);
            this.tabPage1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(424, 377);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Filtros";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbF
            // 
            this.lbF.FormattingEnabled = true;
            this.lbF.ItemHeight = 16;
            this.lbF.Items.AddRange(new object[] {
            "Departamento",
            "Turno",
            "Eficencia",
            "MTM"});
            this.lbF.Location = new System.Drawing.Point(8, 6);
            this.lbF.Name = "lbF";
            this.lbF.Size = new System.Drawing.Size(120, 84);
            this.lbF.TabIndex = 0;
            // 
            // dtPick1
            // 
            this.dtPick1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPick1.Location = new System.Drawing.Point(153, 6);
            this.dtPick1.Name = "dtPick1";
            this.dtPick1.Size = new System.Drawing.Size(95, 23);
            this.dtPick1.TabIndex = 1;
            // 
            // dtPick2
            // 
            this.dtPick2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPick2.Location = new System.Drawing.Point(153, 35);
            this.dtPick2.Name = "dtPick2";
            this.dtPick2.Size = new System.Drawing.Size(95, 23);
            this.dtPick2.TabIndex = 2;
            // 
            // frmFiltros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 420);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmFiltros";
            this.Text = "frmFiltros";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox lbF;
        private System.Windows.Forms.DateTimePicker dtPick2;
        private System.Windows.Forms.DateTimePicker dtPick1;
    }
}