namespace ReportsApplication1
{
    partial class frmVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVoucher));
            this.dgEmpleados = new System.Windows.Forms.DataGridView();
            this.colEmp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eficienDataSet = new ReportsApplication1.EficienDataSet();
            this.eficienDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eficienDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tbTurno = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtBox_conteo = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dgVoucher = new dgv.dgv();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpleados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eficienDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eficienDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eficienDataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVoucher)).BeginInit();
            this.SuspendLayout();
            // 
            // dgEmpleados
            // 
            this.dgEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmpleados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEmp,
            this.colNom});
            this.dgEmpleados.Enabled = false;
            this.dgEmpleados.Location = new System.Drawing.Point(11, 50);
            this.dgEmpleados.Name = "dgEmpleados";
            this.dgEmpleados.Size = new System.Drawing.Size(556, 159);
            this.dgEmpleados.TabIndex = 1;
            this.dgEmpleados.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEmpleados_RowEnter);
            this.dgEmpleados.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEmpleados_CellEndEdit);
            this.dgEmpleados.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgEmpleados_RowsRemoved);
            // 
            // colEmp
            // 
            this.colEmp.HeaderText = "Empleado";
            this.colEmp.Name = "colEmp";
            this.colEmp.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colEmp.Width = 70;
            // 
            // colNom
            // 
            this.colNom.HeaderText = "Nombre";
            this.colNom.Name = "colNom";
            this.colNom.ReadOnly = true;
            this.colNom.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNom.Width = 400;
            // 
            // eficienDataSet
            // 
            this.eficienDataSet.DataSetName = "EficienDataSet";
            this.eficienDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eficienDataSetBindingSource
            // 
            this.eficienDataSetBindingSource.DataSource = this.eficienDataSet;
            this.eficienDataSetBindingSource.Position = 0;
            // 
            // eficienDataSetBindingSource1
            // 
            this.eficienDataSetBindingSource1.DataSource = this.eficienDataSet;
            this.eficienDataSetBindingSource1.Position = 0;
            // 
            // tbTurno
            // 
            this.tbTurno.Location = new System.Drawing.Point(54, 23);
            this.tbTurno.MaxLength = 3;
            this.tbTurno.Name = "tbTurno";
            this.tbTurno.Size = new System.Drawing.Size(78, 20);
            this.tbTurno.TabIndex = 2;
            this.tbTurno.Leave += new System.EventHandler(this.tbTurno_Leave);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(195, 23);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(108, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // txtBox_conteo
            // 
            this.txtBox_conteo.Location = new System.Drawing.Point(511, 215);
            this.txtBox_conteo.Name = "txtBox_conteo";
            this.txtBox_conteo.ReadOnly = true;
            this.txtBox_conteo.Size = new System.Drawing.Size(57, 20);
            this.txtBox_conteo.TabIndex = 114;
            this.txtBox_conteo.Text = "0";
            this.txtBox_conteo.TextChanged += new System.EventHandler(this.txtBox_conteo_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.ImageIndex = 0;
            this.btnAdd.ImageList = this.imageList1;
            this.btnAdd.Location = new System.Drawing.Point(291, 411);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 32);
            this.btnAdd.TabIndex = 116;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "GRABAR_.ICO");
            this.imageList1.Images.SetKeyName(1, "salir_.ico");
            this.imageList1.Images.SetKeyName(2, "delete.png");
            this.imageList1.Images.SetKeyName(3, "search.png");
            this.imageList1.Images.SetKeyName(4, "FloppyDisk.ico");
            this.imageList1.Images.SetKeyName(5, "NEW.BMP");
            this.imageList1.Images.SetKeyName(6, "NOTE16.ICO");
            this.imageList1.Images.SetKeyName(7, "NEW.BMP");
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.ImageIndex = 2;
            this.btnDel.ImageList = this.imageList1;
            this.btnDel.Location = new System.Drawing.Point(235, 411);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(28, 32);
            this.btnDel.TabIndex = 117;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.ImageIndex = 3;
            this.btnSearch.ImageList = this.imageList1;
            this.btnSearch.Location = new System.Drawing.Point(319, 411);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(28, 32);
            this.btnSearch.TabIndex = 118;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(423, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 119;
            this.label1.Text = "No. Empleados:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 120;
            this.label2.Text = "Turno:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(147, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 121;
            this.label3.Text = "Fecha:";
            // 
            // btnExit
            // 
            this.btnExit.ImageIndex = 1;
            this.btnExit.ImageList = this.imageList1;
            this.btnExit.Location = new System.Drawing.Point(347, 411);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(28, 32);
            this.btnExit.TabIndex = 122;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNew
            // 
            this.btnNew.AutoSize = true;
            this.btnNew.ImageIndex = 7;
            this.btnNew.ImageList = this.imageList1;
            this.btnNew.Location = new System.Drawing.Point(207, 411);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(28, 32);
            this.btnNew.TabIndex = 0;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.bntNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.ImageIndex = 6;
            this.btnEdit.ImageList = this.imageList1;
            this.btnEdit.Location = new System.Drawing.Point(263, 411);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(28, 32);
            this.btnEdit.TabIndex = 124;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dgVoucher
            // 
            this.dgVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVoucher.Enabled = false;
            this.dgVoucher.Location = new System.Drawing.Point(11, 241);
            this.dgVoucher.Name = "dgVoucher";
            this.dgVoucher.Size = new System.Drawing.Size(556, 164);
            this.dgVoucher.TabIndex = 4;
            this.dgVoucher.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgVoucher_RowsAdded);
            this.dgVoucher.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVoucher_CellEndEdit);
            // 
            // frmVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 452);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgVoucher);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbTurno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtBox_conteo);
            this.Controls.Add(this.dgEmpleados);
            this.Name = "frmVoucher";
            this.Text = "Alta Vouchers";
            this.Load += new System.EventHandler(this.altaV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpleados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eficienDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eficienDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eficienDataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVoucher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgEmpleados;
        private System.Windows.Forms.BindingSource eficienDataSetBindingSource;
        private EficienDataSet eficienDataSet;
        private System.Windows.Forms.BindingSource eficienDataSetBindingSource1;
        private System.Windows.Forms.TextBox tbTurno;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtBox_conteo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExit;
        private dgv.dgv dgVoucher;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ImageList imageList1;
        //private ReportsApplication1.dgv dgv1;
    }
}