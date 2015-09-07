namespace ReportsApplication1
{
    partial class frmPriv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPriv));
            this.label1 = new System.Windows.Forms.Label();
            this.grpPriv = new System.Windows.Forms.GroupBox();
            this.chkPriv = new System.Windows.Forms.CheckBox();
            this.chkRep = new System.Windows.Forms.CheckBox();
            this.chkV = new System.Windows.Forms.CheckBox();
            this.chkMi = new System.Windows.Forms.CheckBox();
            this.txtUid = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnEsc = new System.Windows.Forms.Button();
            this.btn_dEdit = new System.Windows.Forms.Button();
            this.btn_dNew = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btn_dAdd = new System.Windows.Forms.Button();
            this.btn_dSearch = new System.Windows.Forms.Button();
            this.btn_dDel = new System.Windows.Forms.Button();
            this.grpP = new System.Windows.Forms.GroupBox();
            this.chkMod = new System.Windows.Forms.CheckBox();
            this.txtP3 = new System.Windows.Forms.TextBox();
            this.lblP3 = new System.Windows.Forms.Label();
            this.txtP2 = new System.Windows.Forms.TextBox();
            this.txtP1 = new System.Windows.Forms.TextBox();
            this.lblP2 = new System.Windows.Forms.Label();
            this.lblP1 = new System.Windows.Forms.Label();
            this.chkEmp = new System.Windows.Forms.CheckBox();
            this.grpPriv.SuspendLayout();
            this.grpP.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Id:";
            // 
            // grpPriv
            // 
            this.grpPriv.Controls.Add(this.chkEmp);
            this.grpPriv.Controls.Add(this.chkPriv);
            this.grpPriv.Controls.Add(this.chkRep);
            this.grpPriv.Controls.Add(this.chkV);
            this.grpPriv.Controls.Add(this.chkMi);
            this.grpPriv.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPriv.Location = new System.Drawing.Point(12, 133);
            this.grpPriv.Name = "grpPriv";
            this.grpPriv.Size = new System.Drawing.Size(305, 163);
            this.grpPriv.TabIndex = 3;
            this.grpPriv.TabStop = false;
            this.grpPriv.Text = "Privilegios de Acceso";
            // 
            // chkPriv
            // 
            this.chkPriv.AutoSize = true;
            this.chkPriv.Enabled = false;
            this.chkPriv.Location = new System.Drawing.Point(68, 109);
            this.chkPriv.Name = "chkPriv";
            this.chkPriv.Size = new System.Drawing.Size(95, 21);
            this.chkPriv.TabIndex = 3;
            this.chkPriv.Text = "Privilegios";
            this.chkPriv.UseVisualStyleBackColor = true;
            this.chkPriv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkPriv_KeyPress);
            // 
            // chkRep
            // 
            this.chkRep.AutoSize = true;
            this.chkRep.Enabled = false;
            this.chkRep.Location = new System.Drawing.Point(68, 82);
            this.chkRep.Name = "chkRep";
            this.chkRep.Size = new System.Drawing.Size(107, 21);
            this.chkRep.TabIndex = 2;
            this.chkRep.Text = "Conciliación";
            this.chkRep.UseVisualStyleBackColor = true;
            this.chkRep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkRep_KeyPress);
            // 
            // chkV
            // 
            this.chkV.AutoSize = true;
            this.chkV.Enabled = false;
            this.chkV.Location = new System.Drawing.Point(68, 55);
            this.chkV.Name = "chkV";
            this.chkV.Size = new System.Drawing.Size(83, 21);
            this.chkV.TabIndex = 1;
            this.chkV.Text = "Captura";
            this.chkV.UseVisualStyleBackColor = true;
            this.chkV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkV_KeyPress);
            // 
            // chkMi
            // 
            this.chkMi.AutoSize = true;
            this.chkMi.Enabled = false;
            this.chkMi.Location = new System.Drawing.Point(68, 28);
            this.chkMi.Name = "chkMi";
            this.chkMi.Size = new System.Drawing.Size(150, 21);
            this.chkMi.TabIndex = 0;
            this.chkMi.Text = "Modulo Ingenieria";
            this.chkMi.UseVisualStyleBackColor = true;
            this.chkMi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkMi_KeyPress);
            // 
            // txtUid
            // 
            this.txtUid.Enabled = false;
            this.txtUid.Location = new System.Drawing.Point(150, 12);
            this.txtUid.MaxLength = 10;
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(100, 20);
            this.txtUid.TabIndex = 0;
            this.txtUid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUid_KeyPress);
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
            this.imageList1.Images.SetKeyName(8, "48x48-undo.png");
            // 
            // btnEsc
            // 
            this.btnEsc.Enabled = false;
            this.btnEsc.ImageIndex = 8;
            this.btnEsc.ImageList = this.imageList1;
            this.btnEsc.Location = new System.Drawing.Point(177, 302);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Size = new System.Drawing.Size(28, 32);
            this.btnEsc.TabIndex = 6;
            this.btnEsc.UseVisualStyleBackColor = true;
            this.btnEsc.Click += new System.EventHandler(this.btnEsc_Click);
            // 
            // btn_dEdit
            // 
            this.btn_dEdit.Enabled = false;
            this.btn_dEdit.ImageIndex = 6;
            this.btn_dEdit.ImageList = this.imageList1;
            this.btn_dEdit.Location = new System.Drawing.Point(121, 302);
            this.btn_dEdit.Name = "btn_dEdit";
            this.btn_dEdit.Size = new System.Drawing.Size(28, 32);
            this.btn_dEdit.TabIndex = 4;
            this.btn_dEdit.UseVisualStyleBackColor = true;
            this.btn_dEdit.Click += new System.EventHandler(this.btn_dEdit_Click);
            // 
            // btn_dNew
            // 
            this.btn_dNew.AutoSize = true;
            this.btn_dNew.ImageIndex = 7;
            this.btn_dNew.ImageList = this.imageList1;
            this.btn_dNew.Location = new System.Drawing.Point(65, 302);
            this.btn_dNew.Name = "btn_dNew";
            this.btn_dNew.Size = new System.Drawing.Size(28, 32);
            this.btn_dNew.TabIndex = 2;
            this.btn_dNew.UseVisualStyleBackColor = true;
            this.btn_dNew.Click += new System.EventHandler(this.btn_dNew_Click);
            // 
            // btnExit
            // 
            this.btnExit.ImageIndex = 1;
            this.btnExit.ImageList = this.imageList1;
            this.btnExit.Location = new System.Drawing.Point(236, 302);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(28, 32);
            this.btnExit.TabIndex = 8;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btn_dAdd
            // 
            this.btn_dAdd.Enabled = false;
            this.btn_dAdd.ImageIndex = 0;
            this.btn_dAdd.ImageList = this.imageList1;
            this.btn_dAdd.Location = new System.Drawing.Point(149, 302);
            this.btn_dAdd.Name = "btn_dAdd";
            this.btn_dAdd.Size = new System.Drawing.Size(28, 32);
            this.btn_dAdd.TabIndex = 5;
            this.btn_dAdd.UseVisualStyleBackColor = true;
            this.btn_dAdd.Click += new System.EventHandler(this.btn_dAdd_Click);
            // 
            // btn_dSearch
            // 
            this.btn_dSearch.ImageIndex = 3;
            this.btn_dSearch.ImageList = this.imageList1;
            this.btn_dSearch.Location = new System.Drawing.Point(208, 302);
            this.btn_dSearch.Name = "btn_dSearch";
            this.btn_dSearch.Size = new System.Drawing.Size(28, 32);
            this.btn_dSearch.TabIndex = 7;
            this.btn_dSearch.UseVisualStyleBackColor = true;
            this.btn_dSearch.Click += new System.EventHandler(this.btn_dSearch_Click);
            // 
            // btn_dDel
            // 
            this.btn_dDel.Enabled = false;
            this.btn_dDel.ImageIndex = 2;
            this.btn_dDel.ImageList = this.imageList1;
            this.btn_dDel.Location = new System.Drawing.Point(93, 302);
            this.btn_dDel.Name = "btn_dDel";
            this.btn_dDel.Size = new System.Drawing.Size(28, 32);
            this.btn_dDel.TabIndex = 3;
            this.btn_dDel.UseVisualStyleBackColor = true;
            this.btn_dDel.Click += new System.EventHandler(this.btn_dDel_Click);
            // 
            // grpP
            // 
            this.grpP.Controls.Add(this.chkMod);
            this.grpP.Controls.Add(this.txtP3);
            this.grpP.Controls.Add(this.lblP3);
            this.grpP.Controls.Add(this.txtP2);
            this.grpP.Controls.Add(this.txtP1);
            this.grpP.Controls.Add(this.lblP2);
            this.grpP.Controls.Add(this.lblP1);
            this.grpP.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpP.Location = new System.Drawing.Point(12, 38);
            this.grpP.Name = "grpP";
            this.grpP.Size = new System.Drawing.Size(305, 89);
            this.grpP.TabIndex = 1;
            this.grpP.TabStop = false;
            this.grpP.Text = "Clave de Acceso:";
            // 
            // chkMod
            // 
            this.chkMod.AutoSize = true;
            this.chkMod.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMod.ForeColor = System.Drawing.Color.Blue;
            this.chkMod.Location = new System.Drawing.Point(131, 1);
            this.chkMod.Name = "chkMod";
            this.chkMod.Size = new System.Drawing.Size(77, 17);
            this.chkMod.TabIndex = 30;
            this.chkMod.Text = "Modificar";
            this.chkMod.UseVisualStyleBackColor = true;
            this.chkMod.Visible = false;
            this.chkMod.CheckedChanged += new System.EventHandler(this.chkMod_CheckedChanged);
            // 
            // txtP3
            // 
            this.txtP3.Enabled = false;
            this.txtP3.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtP3.Location = new System.Drawing.Point(163, 62);
            this.txtP3.MaxLength = 15;
            this.txtP3.Name = "txtP3";
            this.txtP3.PasswordChar = '*';
            this.txtP3.Size = new System.Drawing.Size(100, 20);
            this.txtP3.TabIndex = 3;
            this.txtP3.Visible = false;
            this.txtP3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP3_KeyPress);
            // 
            // lblP3
            // 
            this.lblP3.AutoSize = true;
            this.lblP3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP3.Location = new System.Drawing.Point(38, 63);
            this.lblP3.Name = "lblP3";
            this.lblP3.Size = new System.Drawing.Size(125, 17);
            this.lblP3.TabIndex = 11;
            this.lblP3.Text = "Confirmar Clave:";
            this.lblP3.Visible = false;
            // 
            // txtP2
            // 
            this.txtP2.Enabled = false;
            this.txtP2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtP2.Location = new System.Drawing.Point(163, 40);
            this.txtP2.MaxLength = 15;
            this.txtP2.Name = "txtP2";
            this.txtP2.PasswordChar = '*';
            this.txtP2.Size = new System.Drawing.Size(100, 20);
            this.txtP2.TabIndex = 2;
            this.txtP2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP2_KeyPress);
            // 
            // txtP1
            // 
            this.txtP1.Enabled = false;
            this.txtP1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtP1.Location = new System.Drawing.Point(163, 18);
            this.txtP1.MaxLength = 15;
            this.txtP1.Name = "txtP1";
            this.txtP1.PasswordChar = '*';
            this.txtP1.Size = new System.Drawing.Size(100, 20);
            this.txtP1.TabIndex = 1;
            this.txtP1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP1_KeyPress);
            // 
            // lblP2
            // 
            this.lblP2.AutoSize = true;
            this.lblP2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP2.Location = new System.Drawing.Point(38, 43);
            this.lblP2.Name = "lblP2";
            this.lblP2.Size = new System.Drawing.Size(125, 17);
            this.lblP2.TabIndex = 8;
            this.lblP2.Text = "Confirmar Clave:";
            // 
            // lblP1
            // 
            this.lblP1.AutoSize = true;
            this.lblP1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP1.Location = new System.Drawing.Point(38, 22);
            this.lblP1.Name = "lblP1";
            this.lblP1.Size = new System.Drawing.Size(51, 17);
            this.lblP1.TabIndex = 7;
            this.lblP1.Text = "Clave:";
            // 
            // chkEmp
            // 
            this.chkEmp.AutoSize = true;
            this.chkEmp.Enabled = false;
            this.chkEmp.Location = new System.Drawing.Point(68, 134);
            this.chkEmp.Name = "chkEmp";
            this.chkEmp.Size = new System.Drawing.Size(103, 21);
            this.chkEmp.TabIndex = 4;
            this.chkEmp.Text = "Empleados";
            this.chkEmp.UseVisualStyleBackColor = true;
            this.chkEmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkEmp_KeyPress);
            // 
            // frmPriv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 340);
            this.Controls.Add(this.grpP);
            this.Controls.Add(this.btnEsc);
            this.Controls.Add(this.btn_dEdit);
            this.Controls.Add(this.btn_dNew);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btn_dAdd);
            this.Controls.Add(this.btn_dSearch);
            this.Controls.Add(this.btn_dDel);
            this.Controls.Add(this.txtUid);
            this.Controls.Add(this.grpPriv);
            this.Controls.Add(this.label1);
            this.Name = "frmPriv";
            this.Text = "Privilegios de Usuarios";
            this.grpPriv.ResumeLayout(false);
            this.grpPriv.PerformLayout();
            this.grpP.ResumeLayout(false);
            this.grpP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpPriv;
        private System.Windows.Forms.CheckBox chkV;
        private System.Windows.Forms.CheckBox chkMi;
        private System.Windows.Forms.CheckBox chkPriv;
        private System.Windows.Forms.CheckBox chkRep;
        private System.Windows.Forms.TextBox txtUid;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnEsc;
        private System.Windows.Forms.Button btn_dEdit;
        private System.Windows.Forms.Button btn_dNew;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btn_dAdd;
        private System.Windows.Forms.Button btn_dSearch;
        private System.Windows.Forms.Button btn_dDel;
        private System.Windows.Forms.GroupBox grpP;
        private System.Windows.Forms.TextBox txtP2;
        private System.Windows.Forms.TextBox txtP1;
        private System.Windows.Forms.Label lblP2;
        private System.Windows.Forms.Label lblP1;
        private System.Windows.Forms.TextBox txtP3;
        private System.Windows.Forms.Label lblP3;
        private System.Windows.Forms.CheckBox chkMod;
        private System.Windows.Forms.CheckBox chkEmp;
    }
}