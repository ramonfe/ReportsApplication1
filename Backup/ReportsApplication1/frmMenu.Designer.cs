namespace ReportsApplication1
{
    partial class frmMenu
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
            this.btnV = new System.Windows.Forms.Button();
            this.btnRep = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.stTrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnMi = new System.Windows.Forms.Button();
            this.btnPriv = new System.Windows.Forms.Button();
            this.btnConTress = new System.Windows.Forms.Button();
            this.btnEmp = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stTrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnV
            // 
            this.btnV.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnV.Location = new System.Drawing.Point(39, 139);
            this.btnV.Name = "btnV";
            this.btnV.Size = new System.Drawing.Size(189, 46);
            this.btnV.TabIndex = 1;
            this.btnV.Text = "&Vouchers";
            this.btnV.UseVisualStyleBackColor = true;
            this.btnV.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnRep
            // 
            this.btnRep.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRep.Location = new System.Drawing.Point(39, 295);
            this.btnRep.Name = "btnRep";
            this.btnRep.Size = new System.Drawing.Size(189, 46);
            this.btnRep.TabIndex = 2;
            this.btnRep.Text = "&Reportes y Listados";
            this.btnRep.UseVisualStyleBackColor = true;
            this.btnRep.Click += new System.EventHandler(this.button8_Click);
            // 
            // btnOut
            // 
            this.btnOut.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnOut.Location = new System.Drawing.Point(39, 400);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(189, 46);
            this.btnOut.TabIndex = 3;
            this.btnOut.Text = "Salir";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.button16_Click);
            // 
            // stTrip
            // 
            this.stTrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.stTrip.Location = new System.Drawing.Point(0, 474);
            this.stTrip.Name = "stTrip";
            this.stTrip.Size = new System.Drawing.Size(532, 22);
            this.stTrip.TabIndex = 15;
            this.stTrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "zxczxc";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "mdb";
            this.openFileDialog1.Filter = "Access Files|*.mdb";
            this.openFileDialog1.Title = "Selecciona la Base de datos con la que trabajaras";
            // 
            // btnMi
            // 
            this.btnMi.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMi.Location = new System.Drawing.Point(39, 35);
            this.btnMi.Name = "btnMi";
            this.btnMi.Size = new System.Drawing.Size(189, 46);
            this.btnMi.TabIndex = 0;
            this.btnMi.Text = "&Modulo Ingenieria";
            this.btnMi.UseVisualStyleBackColor = true;
            this.btnMi.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPriv
            // 
            this.btnPriv.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPriv.Location = new System.Drawing.Point(39, 87);
            this.btnPriv.Name = "btnPriv";
            this.btnPriv.Size = new System.Drawing.Size(189, 46);
            this.btnPriv.TabIndex = 16;
            this.btnPriv.Text = "&Privilegios";
            this.btnPriv.UseVisualStyleBackColor = true;
            this.btnPriv.Click += new System.EventHandler(this.btnPriv_Click);
            // 
            // btnConTress
            // 
            this.btnConTress.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConTress.Location = new System.Drawing.Point(39, 243);
            this.btnConTress.Name = "btnConTress";
            this.btnConTress.Size = new System.Drawing.Size(189, 46);
            this.btnConTress.TabIndex = 17;
            this.btnConTress.Text = "&Conciliación Tress";
            this.btnConTress.UseVisualStyleBackColor = true;
            this.btnConTress.Click += new System.EventHandler(this.btnConTress_Click);
            // 
            // btnEmp
            // 
            this.btnEmp.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmp.Location = new System.Drawing.Point(39, 191);
            this.btnEmp.Name = "btnEmp";
            this.btnEmp.Size = new System.Drawing.Size(189, 46);
            this.btnEmp.TabIndex = 18;
            this.btnEmp.Text = "&Empleados";
            this.btnEmp.UseVisualStyleBackColor = true;
            this.btnEmp.Click += new System.EventHandler(this.btnEmp_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(532, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 496);
            this.Controls.Add(this.btnEmp);
            this.Controls.Add(this.btnConTress);
            this.Controls.Add(this.btnPriv);
            this.Controls.Add(this.btnMi);
            this.Controls.Add(this.stTrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnRep);
            this.Controls.Add(this.btnV);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMenu";
            this.Text = "Menu Principal. Ver 1.0.0.22";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.stTrip.ResumeLayout(false);
            this.stTrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnV;
        private System.Windows.Forms.Button btnRep;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.StatusStrip stTrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnMi;
        private System.Windows.Forms.Button btnPriv;
        private System.Windows.Forms.Button btnConTress;
        private System.Windows.Forms.Button btnEmp;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}