namespace ReportsApplication1
{
    partial class frmConcTress
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
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.oFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.btnFile = new System.Windows.Forms.Button();
            this.txtFileSel = new System.Windows.Forms.TextBox();
            this.btnCarga = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblErr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progBar
            // 
            this.progBar.Location = new System.Drawing.Point(25, 51);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(400, 23);
            this.progBar.TabIndex = 0;
            // 
            // oFileDlg
            // 
            this.oFileDlg.Filter = "csv files|*.csv";
            // 
            // btnFile
            // 
            this.btnFile.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile.Location = new System.Drawing.Point(350, 22);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 23);
            this.btnFile.TabIndex = 1;
            this.btnFile.Text = "Archivo..";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // txtFileSel
            // 
            this.txtFileSel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileSel.Location = new System.Drawing.Point(25, 25);
            this.txtFileSel.Name = "txtFileSel";
            this.txtFileSel.Size = new System.Drawing.Size(324, 21);
            this.txtFileSel.TabIndex = 2;
            // 
            // btnCarga
            // 
            this.btnCarga.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarga.Location = new System.Drawing.Point(146, 80);
            this.btnCarga.Name = "btnCarga";
            this.btnCarga.Size = new System.Drawing.Size(75, 23);
            this.btnCarga.TabIndex = 3;
            this.btnCarga.Text = "Cargar";
            this.btnCarga.UseVisualStyleBackColor = true;
            this.btnCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(227, 80);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblErr
            // 
            this.lblErr.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErr.Location = new System.Drawing.Point(22, 106);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(403, 13);
            this.lblErr.TabIndex = 5;
            this.lblErr.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmConcTress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 128);
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCarga);
            this.Controls.Add(this.txtFileSel);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.progBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConcTress";
            this.Text = "Cargando checadas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progBar;
        private System.Windows.Forms.OpenFileDialog oFileDlg;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox txtFileSel;
        private System.Windows.Forms.Button btnCarga;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblErr;
    }
}